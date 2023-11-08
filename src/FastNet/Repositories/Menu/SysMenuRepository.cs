namespace FastNet.Repositories;



/// <summary>
/// 
/// </summary>
public class SysMenuRepository : DatabaseRepository<SysMenu>, ISysMenuRepository
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<SqlSugarPagedList<SysMenuPageOutput>> GetPageListAsync([FromQuery] QueryMenuPagedInput dto)
    {
        return await Context.Queryable<SysMenu>()
            .Where(x => x.Id > 0)
            .FiltersConditions(dto.SearchFilterConditions)
            .OrderConditions(dto.OrderConditions)
            //.Select(x => x.Adapt<SysMenuPageOutput>())
            .ToPagedListAsync<SysMenuPageOutput, SysMenu>(dto.Index, dto.Size);
    }

    /// <summary>
    /// 校验权限
    /// </summary>
    /// <param name="code">权限标识</param>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public async Task<bool> CheckPermission(long UserId,  string code)
    {
        var cache = await GetAuthButtonCodeList(UserId);
        var output = cache.FirstOrDefault(x => x.Code.Contains(code, StringComparison.CurrentCultureIgnoreCase));
        return output?.Access ?? true;
    }

    /// <summary>
    /// 获取指定用户的访问权限集合
    /// </summary>
    /// <param name="userId">系统用户id</param>
    /// <returns></returns>
    public async Task<List<CheckPermissionOutput>> GetAuthButtonCodeList(long userId)
    {
        //var cache = await _easyCachingProvider.GetAsync($"{CacheConst.PermissionButtonCodeKey}{userId}", async () =>
        //{
            var queryable = Context.Queryable<SysRole>()
                .InnerJoin<SysRelation>((role, userRole) => role.Id == userRole.TargetId && userRole.RelationType == DataRelationType.UserRole)
                .InnerJoin<SysRelation>((role, userRole, roleMenu) => role.Id == roleMenu.SourceId && userRole.RelationType == DataRelationType.RoleMenu)
                .Where(role => role.Status == DataStatus.Enable)
                .Select((role, userRole, roleMenu) => roleMenu);


            List<CheckPermissionOutput> list = await Context.Queryable<SysMenu>().LeftJoin(queryable, (menu, roleMenu) => menu.Id == roleMenu.TargetId && roleMenu.RelationType == DataRelationType.RoleMenu)
                   .Where(menu => menu.Type == DataMenuType.Button)
                   .Select((menu, roleMenu) => new CheckPermissionOutput
                   {
                       Code = menu.Router,
                       Access = SqlFunc.IIF(SqlFunc.IsNull(roleMenu.Id, 0) > 0 || menu.Status == DataStatus.Disable, true, false)
                   }).ToListAsync();
            return list.Distinct().ToList();
        //}, TimeSpan.FromDays(1));
        //return cache.Value;
    }
}

