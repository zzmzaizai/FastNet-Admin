using Microsoft.AspNetCore.Components;

namespace FastNet.BlazorCore
{
    /// <summary>
    /// 加载页面基类
    /// </summary>
    public class LoadingBase : ComponentBase, IDisposable, ILoading
    {  
        public bool Loading { get; set; }

        public virtual void Dispose()
        {
          
        }
    }

    public interface ILoading
    {
        bool Loading { get; set; }
    }
}
