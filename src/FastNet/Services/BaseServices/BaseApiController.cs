using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Services;

/// <summary>
/// 基础API控制器
/// </summary>
public abstract class BaseApiController : IDynamicApiController
{

    #region "注入的仓储属性"
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysUserRepository sysUserRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysTenantRepository sysTenantRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysApiResourceRepository sysApiResourceRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysClientAppRepository sysClientAppRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysConfigRepository sysConfigRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysDictDataRepository sysDictDataRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysDictTypeRepository sysDictTypeRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysMenuRepository sysMenuRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysOrganizationRepository sysOrganizationRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysRelationRepository sysRelationRep { get; set; }
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public ISysRoleRepository sysRoleRep { get; set; }



    #endregion


    #region "注入的系统对象属性"

    /// <summary>
    /// HTTP 上下文访问器
    /// </summary>
    public IHttpContextAccessor httpContextAccessor { get; set; }

    /// <summary>
    /// HTTP 上下文属性
    /// </summary>
    public HttpContext httpContext { get; set; }


    /// <summary>
    /// 用户数据
    /// </summary>
    public AuthManager authManager { get; set; }


    #endregion

    #region "默认的构造函数"

    /// <summary>
    /// 默认构造，初始化属性方式的注入仓储
    /// </summary>
    public BaseApiController()
    {
        #region "注入的仓储属性"
        sysUserRep = App.GetService<ISysUserRepository>();
        sysTenantRep = App.GetService<ISysTenantRepository>();
        sysApiResourceRep = App.GetService<ISysApiResourceRepository>();
        sysClientAppRep = App.GetService<ISysClientAppRepository>();
        sysConfigRep = App.GetService<ISysConfigRepository>();
        sysDictDataRep = App.GetService<ISysDictDataRepository>();
        sysDictTypeRep = App.GetService<ISysDictTypeRepository>();
        sysMenuRep = App.GetService<ISysMenuRepository>();
        sysOrganizationRep = App.GetService<ISysOrganizationRepository>();
        sysRelationRep = App.GetService<ISysRelationRepository>();
        sysRoleRep = App.GetService<ISysRoleRepository>();
        #endregion

        #region "注入的系统对象属性"
        httpContextAccessor = App.GetService<IHttpContextAccessor>();
        httpContext = httpContextAccessor.HttpContext;
        authManager = App.GetService<AuthManager>();
        #endregion
    }
    #endregion




    //#if DEBUG
    //    /// <summary>
    //    /// 获取当前时间
    //    /// </summary>
    //    /// <returns></returns>
    //    public string GetDateNow()
    //    {
    //        return $"现在时间是{DateTime.Now}";
    //    }

    //    /// <summary>
    //    /// 获取当前控制器的名称
    //    /// </summary>
    //    /// <returns></returns>
    //    public string GetClassName()
    //    {
    //        return this.GetType().FullName;
    //    }

    //    /// <summary>
    //    /// 获取当前控制器的方法集合
    //    /// </summary>
    //    /// <returns></returns>
    //    public object GetClassMethods()
    //    {
    //        return this.GetType().GetMethods().Where(x=>x.IsPublic && x.MemberType == System.Reflection.MemberTypes.Method).Select(x=> new { Name = x.Name, ReturnType = x.ReturnType.Name }).ToList();
    //    }

    //#endif




}

