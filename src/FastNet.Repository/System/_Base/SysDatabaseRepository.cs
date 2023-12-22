using Microsoft.Extensions.Logging;

namespace FastNet.SqlSugar;
/// <summary>
/// 系统-仓储模式对象
/// </summary>
[SuppressSniffer]
public partial class SysDatabaseRepository<T> : DatabaseRepository<T> where T : class, new()
{
    /// <summary>
    /// HTTP上下文访问器
    /// </summary>
    protected readonly IHttpContextAccessor _HttpContextAccessor;
    /// <summary>
    /// API资源仓储接口
    /// </summary>
    protected readonly ISysApiResourceRepository sysApiResourceRep;
    /// <summary>
    /// 客户端APP仓储接口
    /// </summary>
    protected readonly ISysClientAppRepository sysClientAppRep;
    /// <summary>
    /// 系统配置仓储接口
    /// </summary>
    protected readonly ISysConfigRepository sysConfigRep;
    /// <summary>
    /// 字典数据仓储接口
    /// </summary>
    protected readonly ISysDictDataRepository sysDictDataRep;
    /// <summary>
    /// 字典类型仓储接口
    /// </summary>
    protected readonly ISysDictTypeRepository sysDictTypeRep;
    /// <summary>
    /// 组织架构仓储接口
    /// </summary>
    protected readonly ISysOrganizationRepository sysOrganizationRep;
    /// <summary>
    /// 数据关系仓储接口
    /// </summary>
    protected readonly ISysRelationRepository sysRelationRep;
    /// <summary>
    /// 系统角色仓储接口
    /// </summary>
    protected readonly ISysRoleRepository sysRoleRep;
    /// <summary>
    /// 租户仓储接口
    /// </summary>
    protected readonly ISysTenantRepository sysTenantRep;
    /// <summary>
    /// 系统菜单仓储接口
    /// </summary>
    protected readonly ISysMenuRepository sysMenuRep;
    /// <summary>
    /// 系统用户仓储接口
    /// </summary>
    protected readonly ISysUserRepository sysUserRep;


    /// <summary>
    /// 仓储构造
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    public SysDatabaseRepository(ILogger<DatabaseRepository<T>> logger = null,ISqlSugarClient context = null) : base(logger,context)//注意这里要有默认值等于null
    {
        _HttpContextAccessor = App.GetService<IHttpContextAccessor>();
        sysApiResourceRep = App.GetService<ISysApiResourceRepository>();
        sysClientAppRep = App.GetService<ISysClientAppRepository>();
        sysConfigRep = App.GetService<ISysConfigRepository>();
        sysDictDataRep = App.GetService<ISysDictDataRepository>();
        sysDictTypeRep = App.GetService<ISysDictTypeRepository>();
        sysOrganizationRep = App.GetService<ISysOrganizationRepository>();
        sysRelationRep = App.GetService<ISysRelationRepository>();
        sysRoleRep = App.GetService<ISysRoleRepository>();
        sysTenantRep = App.GetService<ISysTenantRepository>();
        sysMenuRep = App.GetService<ISysMenuRepository>();
        sysUserRep = App.GetService<ISysUserRepository>();
    }

}