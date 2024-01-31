using System.ComponentModel.DataAnnotations;

namespace FastNet.BlazorCore.Models
{
    public class LoginParamsType
    {
        [Required] public string UserName { get; set; } = "admin";

        [Required] public string Password { get; set; } = "admin";

        public string Captcha { get; set; }

        public bool AutoLogin { get; set; }
    }
}