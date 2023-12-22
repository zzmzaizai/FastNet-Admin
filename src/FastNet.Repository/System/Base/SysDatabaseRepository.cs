





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
    protected readonly ISysApiResourceRepository _SysApiResourceRep;
    /// <summary>
    /// 客户端APP仓储接口
    /// </summary>
    protected readonly ISysClientAppRepository _SysClientAppRep;
    /// <summary>
    /// 系统配置仓储接口
    /// </summary>
    protected readonly ISysConfigRepository _SysConfigRep;
    /// <summary>
    /// 字典数据仓储接口
    /// </summary>
    protected readonly ISysDictDataRepository _SysDictDataRep;
    /// <summary>
    /// 字典类型仓储接口
    /// </summary>
    protected readonly ISysDictTypeRepository _SysDictTypeRep;
    /// <summary>
    /// 组织架构仓储接口
    /// </summary>
    protected readonly ISysOrganizationRepository _SysOrganizationRep;
    /// <summary>
    /// 数据关系仓储接口
    /// </summary>
    protected readonly ISysRelationRepository _SysRelationRep;
    /// <summary>
    /// 系统角色仓储接口
    /// </summary>
    protected readonly ISysRoleRepository _SysRoleRep;
    /// <summary>
    /// 租户仓储接口
    /// </summary>
    protected readonly ISysTenantRepository _SysTenantRep;
    /// <summary>
    /// 系统用户仓储接口
    /// </summary>
    protected readonly ISysUserRepository _SysUserRep;


    /// <summary>
    /// 仓储构造
    /// </summary>
    /// <param name="context"></param>
    public SysDatabaseRepository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
    {
        _HttpContextAccessor = App.GetService<IHttpContextAccessor>();
        _SysApiResourceRep = App.GetService<ISysApiResourceRepository>();
        _SysClientAppRep = App.GetService<ISysClientAppRepository>();
        _SysConfigRep = App.GetService<ISysConfigRepository>();
        _SysDictDataRep = App.GetService<ISysDictDataRepository>();
        _SysDictTypeRep = App.GetService<ISysDictTypeRepository>();
        _SysOrganizationRep = App.GetService<ISysOrganizationRepository>();
        _SysRelationRep = App.GetService<ISysRelationRepository>();
        _SysRoleRep = App.GetService<ISysRoleRepository>();
        _SysTenantRep = App.GetService<ISysTenantRepository>();
        _SysUserRep = App.GetService<ISysUserRepository>();
    }

}