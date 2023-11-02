using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Web.Core.Controllers;

/// <summary>
/// 基础API控制器
/// </summary>
public abstract class BaseApiController : IDynamicApiController
{
 
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

    public IHttpContextAccessor httpContextAccessor;


    /// <summary>
    /// 默认构造，初始化属性方式的注入仓储
    /// </summary>
    public BaseApiController()
    {
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
        httpContextAccessor = App.GetService<IHttpContextAccessor>();


    }

    /// <summary>
    /// 获取当前时间
    /// </summary>
    /// <returns></returns>
    public string GetDateNow()
    {
        return $"现在时间是{DateTime.Now}";
    }
}

