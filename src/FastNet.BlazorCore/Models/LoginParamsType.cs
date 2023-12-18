using System.ComponentModel.DataAnnotations;

namespace FastNet.BlazorCore.Models
{
    public class LoginParamsType
    {
        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }

        public string Captcha { get; set; }

        public bool AutoLogin { get; set; }
    }
}