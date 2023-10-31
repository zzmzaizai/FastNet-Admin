using FastNet.Blazor.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace FastNet.Blazor.Core.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}