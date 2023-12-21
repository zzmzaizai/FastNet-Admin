namespace FastNet.Repository;



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


    /// <summary>
    /// 获取用户菜单列表
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<SysMenu>> GetMenuListAsync(long userId)
    {
        //var cache = await _easyCachingProvider.GetAsync($"{CacheConst.PermissionButtonCodeKey}{userId}", async () =>
        //{
        var queryable = Context.Queryable<SysRole>()
            .InnerJoin<SysRelation>((role, userRole) => role.Id == userRole.TargetId && userRole.RelationType == DataRelationType.UserRole)
            .InnerJoin<SysRelation>((role, userRole, roleMenu) => role.Id == roleMenu.SourceId && userRole.RelationType == DataRelationType.RoleMenu)
            .Where(role => role.Status == DataStatus.Enable)
            .Select((role, userRole, roleMenu) => roleMenu);


        var list = await Context.Queryable<SysMenu>().LeftJoin(queryable, (menu, roleMenu) => menu.Id == roleMenu.TargetId && roleMenu.RelationType == DataRelationType.RoleMenu)
               .Where(menu => menu.Type == DataMenuType.Catalog || menu.Type == DataMenuType.Menu)
               .Select((menu, roleMenu) => menu).ToListAsync();
        return list.Distinct().ToList();
        //}, TimeSpan.FromDays(1));
        //return cache.Value;
    }


    /// <summary>
    /// 获取用户菜单树形列表
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<SysMenu>> GetMenuTreeAsync(long userId)
    {
        //这里未完工
        return await GetMenuListAsync(userId);
    }



        /// <summary>
        /// 根据菜单Id获取菜单
        /// </summary>
        /// <param name="MenuId">菜单编号</param>
        /// <returns></returns>
        public async Task<SysMenu> GetMenuAsync(long MenuId)
    {
        return await Context.Queryable<SysMenu>().FirstAsync(x => x.Id == MenuId);
    }

    /// <summary>
    /// 插入菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysMenu> InsertMenuAsync(InsertMenuInput dto)
    {
        var user = dto.Adapt<SysMenu>();
        await InsertAsync(user);
        return user;
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<SysMenu> UpdateMenuAsync(UpdateMenuInput dto)
    {
        var role = dto.Adapt<SysMenu>();

        var dbRole = await GetMenuAsync(dto.Id);
        if (dbRole != null)
        {
            role.CreateUserId = dbRole.CreateUserId;
            role.CreateTime = dbRole.CreateTime;
            role.TenantId = dbRole.TenantId;
            role.IsDelete = dbRole.IsDelete;
        }
        await UpdateAsync(role);
        return role;
    }
}

