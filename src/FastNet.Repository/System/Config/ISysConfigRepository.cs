﻿namespace FastNet.Repository;


/// <summary>
/// 系统配置仓储接口
/// </summary>
public interface ISysConfigRepository : IDatabaseRepository<SysConfig>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysConfigPageOutput>> GetPageListAsync(QueryConfigPagedInput dto);
}

