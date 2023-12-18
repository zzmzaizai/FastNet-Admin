using AntDesign;
using FastNet.BlazorCore.Models;
using FastNet.BlazorCore.Services;
using Microsoft.AspNetCore.Components;
using StackExchange.Profiling.Internal;
using System.Threading.Tasks;

namespace FastNet.BlazorCore.Pages.User
{
    public partial class Login
    {
        private readonly LoginParamsType _model = new LoginParamsType();

        [Inject] public NavigationManager NavigationManager { get; set; }

        //[Inject] public IAccountService AccountService { get; set; }

        [Inject] public MessageService Message { get; set; }

        [Inject] public AuthService authService { get; set; }

        public async Task HandleSubmit()
        {
            if ( !_model.Password.IsNullOrWhiteSpace())
            {

               var LoginData = await authService.SignIn(_model.Adapt<LoginInput>());



                //NavigationManager.NavigateTo("/");
                return;
            }

            if (_model.UserName == "user" && _model.Password == "ant.design") NavigationManager.NavigateTo("/");
        }

        public async Task GetCaptcha()
        {
            //var captcha = await AccountService.GetCaptchaAsync(_model.Mobile);
            //await Message.Success($"Verification code validated successfully! The verification code is: {captcha}");
        }
    }
}