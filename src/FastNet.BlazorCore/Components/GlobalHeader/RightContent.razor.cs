﻿using AntDesign;
using AntDesign.ProLayout;
using FastNet.BlazorCore.Models;
using FastNet.BlazorCore.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastNet.BlazorCore.Components
{
    public partial class RightContent
    {
        private SigninToken _signinUser = new SigninToken();
        private CurrentUser _currentUser = new CurrentUser();
        private NoticeIconData[] _notifications = { };
        private NoticeIconData[] _messages = { };
        private NoticeIconData[] _events = { };
        private int _count = 0;

        private List<AutoCompleteDataItem<string>> DefaultOptions { get; set; } = new List<AutoCompleteDataItem<string>>
        {
            new AutoCompleteDataItem<string>
            {
                Label = "umi ui",
                Value = "umi ui"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Table",
                Value = "Pro Table"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Layout",
                Value = "Pro Layout"
            }
        };

        public AvatarMenuItem[] AvatarMenuItems { get; set; } = new AvatarMenuItem[]
        {
            new() { Key = "center", IconType = "user", Option = "个人中心"},
            new() { Key = "setting", IconType = "setting", Option = "个人设置"},
            new() { IsDivider = true },
            new() { Key = "logout", IconType = "logout", Option = "退出登录"}
        };

        [Inject] protected NavigationManager NavigationManager { get; set; }

        [Inject] protected IUserService UserService { get; set; }
        [Inject] protected IProjectService ProjectService { get; set; }
        [Inject] protected MessageService MessageService { get; set; }

        [Inject]
        JwtAuthenticationStateProvider AuthStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            SetClassMap();
            _signinUser = await AuthStateProvider.GetCurrentUserAsync();
            _currentUser = await UserService.GetCurrentUserAsync();
            var notices = await ProjectService.GetNoticesAsync();
            _notifications = notices.Where(x => x.Type == "notification").Cast<NoticeIconData>().ToArray();
            _messages = notices.Where(x => x.Type == "message").Cast<NoticeIconData>().ToArray();
            _events = notices.Where(x => x.Type == "event").Cast<NoticeIconData>().ToArray();
            _count = notices.Length;
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("right");
        }

        public async Task HandleSelectUser(MenuItem item)
        {
            switch (item.Key)
            {
                case "center":
                    NavigationManager.NavigateTo("/account/center");
                    break;
                case "setting":
                    NavigationManager.NavigateTo("/account/settings");
                    break;
                case "logout":
                   await HandleLogout(item);
                    break;
            }
        }


        public async Task HandleLogout(MenuItem item)
        {
            var CurrentUser = await AuthStateProvider.GetCurrentUserAsync();
            var LoginData = await AuthStateProvider.Logout();
            if (LoginData.Succeeded)
            {
                await MessageService.Success($"尊贵的用户{CurrentUser?.UserName}已经离开");
                NavigationManager.NavigateTo("/user/login");
            }
            else
            {
                await MessageService.Warning(LoginData.Errors.ToString());
            }
           
        }

        public void HandleSelectLang(MenuItem item)
        {
        }

        public async Task HandleClear(string key)
        {
            switch (key)
            {
                case "notification":
                    _notifications = new NoticeIconData[] { };
                    break;
                case "message":
                    _messages = new NoticeIconData[] { };
                    break;
                case "event":
                    _events = new NoticeIconData[] { };
                    break;
            }
            await MessageService.Success($"清空了{key}");
        }

        public async Task HandleViewMore(string key)
        {
            await MessageService.Info("Click on view more");
        }



    }
}