using AntDesign;
using FastNet.BlazorCore.Models;
using FastNet.BlazorCore.Services;
using Microsoft.AspNetCore.Components;
using StackExchange.Profiling.Internal;
using System.Threading.Tasks;

namespace FastNet.BlazorCore.Pages.User
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Login
    {
        private readonly LoginParamsType _model = new LoginParamsType();

        /// <summary>
        /// 
        /// </summary>
        [Inject] 
        public NavigationManager NavigationManager { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Inject] 
        public MessageService Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Inject]
        JwtAuthenticationStateProvider AuthStateProvider { get; set; }

        /// <summary>
        /// 返回值URL
        /// </summary>
        [Parameter]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 登录提交按钮处理
        /// </summary>
        public async Task HandleSubmit()
        {
            var LoginData = await AuthStateProvider.Login(_model.Adapt<LoginInput>());
            if (LoginData.Succeeded)
            {
                var CurrentUser = await AuthStateProvider.GetCurrentUserAsync();
                await Message.Success($"欢迎{CurrentUser?.UserName}回来");

                if (!string.IsNullOrWhiteSpace(ReturnUrl))
                {
                    NavigationManager.NavigateTo($"/{ReturnUrl}");
                }
                else
                {
                    NavigationManager.NavigateTo("/");
                }
            }
            else
            {
                await Message.Warning(LoginData.Errors.ToString());
            }

        }

        public async Task GetCaptcha()
        {
            //var captcha = await AccountService.GetCaptchaAsync(_model.Mobile);
            //await Message.Success($"Verification code validated successfully! The verification code is: {captcha}");
        }
    }
}