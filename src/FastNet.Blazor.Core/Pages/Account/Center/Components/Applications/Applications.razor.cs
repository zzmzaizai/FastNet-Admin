using AntDesign;
using FastNet.Blazor.Core.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace FastNet.Blazor.Core.Pages.Account.Center
{
    public partial class Applications
    {
        private readonly ListGridType _listGridType = new ListGridType
        {
            Gutter = 24,
            Column = 4
        };

        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}