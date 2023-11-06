using FastNet.BlazorCore.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace FastNet.BlazorCore.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}