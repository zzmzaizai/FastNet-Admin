namespace FastNet.Repository;


/// <summary>
/// 数据关系仓储接口
/// </summary>
public interface ISysRelationRepository : IDatabaseRepository<SysRelation>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysRelationPageOutput>> GetPageListAsync(QueryRelationPagedInput dto);
}

