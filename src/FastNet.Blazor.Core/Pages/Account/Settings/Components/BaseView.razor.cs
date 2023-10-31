using FastNet.Blazor.Core.Models;
using FastNet.Blazor.Core.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FastNet.Blazor.Core.Pages.Account.Settings
{
    public partial class BaseView
    {
        private CurrentUser _currentUser = new CurrentUser();

        [Inject] protected IUserService UserService { get; set; }

        private void HandleFinish()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _currentUser = await UserService.GetCurrentUserAsync();
        }
    }
}