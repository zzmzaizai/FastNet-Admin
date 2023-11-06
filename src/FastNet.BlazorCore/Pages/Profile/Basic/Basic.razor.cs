using FastNet.BlazorCore.Models;
using FastNet.BlazorCore.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace FastNet.BlazorCore.Pages.Profile
{
    public partial class Basic
    {
        private BasicProfileDataType _data = new BasicProfileDataType();

        [Inject] protected IProfileService ProfileService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _data = await ProfileService.GetBasicAsync();
        }
    }
}