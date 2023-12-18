using AntDesign;
using Microsoft.AspNetCore.Components;
using StackExchange.Profiling.Internal;
using System.ComponentModel.DataAnnotations;

namespace FastNet.BlazorCore.Pages.User
{
 
    /// <summary>
    /// 用户注册
    /// </summary>
    public partial class Register
    {
        private readonly RegisterInput _user = new RegisterInput();

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public MessageService Message { get; set; }

        [Inject] public AuthService authService { get; set; }

        /// <summary>
        /// 用户注册按钮触发
        /// </summary>
        public void HandleSubmit()
        {
            if (!_user.UserName.IsNullOrWhiteSpace())
            {

                var RegData = authService.Register(_user);



                NavigationManager.NavigateTo("/");
                return;
            }

            
        }
    }
}