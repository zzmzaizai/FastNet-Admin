
using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.BlazorCore
{
    /// <summary>
    /// 基础页面基类
    /// </summary>
    public class PageBase : LoadingBase, IReuseTabsPage
    {


        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public Error? Error { get; set; }


        protected string IndexUrl { get; set; }

        protected Pagination Pagination { get; set; } = new Pagination() {  PageSize = 20 };
        protected virtual Func<PaginationTotalContext, string> ShowTotal { get; set; } = ctx => $"总数：{ctx.Total}   当前：{ctx.Range.from}-{ctx.Range.to}";

        protected virtual async Task PageIndexChanged(PaginationEventArgs paginationEvent)
        {
            if (Pagination.Current != paginationEvent.Page)
            {
                Pagination.Current = paginationEvent.Page;
                await GetDataList();
            }
        }

        protected virtual async Task PageSizeChanged(PaginationEventArgs paginationEvent)
        {
            if (Pagination.PageSize != paginationEvent.PageSize)
            {
                Pagination.PageSize = paginationEvent.PageSize;
                await GetDataList();
            }
        }

        protected virtual async Task GetDataList()
        {
            await Task.CompletedTask;
        }

        protected virtual async Task Refresh()
        {
            Pagination.Current = 0;
            await GetDataList();
        }

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(IndexUrl))
            {
                IndexUrl = NavigationManager.Uri;
                var uri = new Uri(IndexUrl);
                IndexUrl = uri.LocalPath;
            }
            await Task.CompletedTask;
        }

        public virtual RenderFragment GetPageTitle() => builder =>
        {
            //var menu = Operator.Menus.FirstOrDefault(u => u.Url == IndexUrl && u.Type == Entity.ActionType.页面);
            //if (menu != null)
            //{
            //    var index = 0;
            //    builder.OpenElement(index++, "div");
            //    if (!string.IsNullOrEmpty(menu.Icon))
            //    {
            //        IEnumerable<KeyValuePair<string, object>> paramenter = new List<KeyValuePair<string, object>>()
            //        {
            //            new KeyValuePair<string, object>("Type", menu.Icon)
            //        };

            //        builder.OpenComponent(index++, typeof(Icon));
            //        builder.AddMultipleAttributes(index++, paramenter);
            //        builder.CloseComponent();
            //    }
            //    builder.AddMarkupContent(index++, menu.Text);
            //    builder.CloseElement();
            //}
        }
    }
}
