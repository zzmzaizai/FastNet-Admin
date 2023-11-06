using AntDesign;
using FastNet.BlazorCore.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace FastNet.BlazorCore.Pages.Account.Center
{
    public partial class Projects
    {
        private readonly ListGridType _listGridType = new ListGridType
        {
            Gutter = 24,
            Column = 4
        };

        [Parameter]
        public IList<ListItemDataType> List { get; set; }
    }
}