﻿namespace FastNet.Repository;


/// <summary>
/// 客户端APP仓储接口
/// </summary>
public interface ISysClientAppRepository : IDatabaseRepository<SysClientApp>, ITransient
{
    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SqlSugarPagedList<SysClientAppPageOutput>> GetPageListAsync(QueryClientAppPagedInput dto);



    /// <summary>
    /// 根据客户端APPId获取客户端APP
    /// </summary>
    /// <param name="ClientAppId">客户端APP编号</param>
    /// <returns></returns>
    Task<SysClientApp> GetClientAppAsync(long ClientAppId);

    /// <summary>
    /// 插入客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysClientApp> InsertClientAppAsync(InsertClientAppInput dto);

    /// <summary>
    /// 更新客户端APP
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysClientApp> UpdateClientAppAsync(UpdateClientAppInput dto);

    /// <summary>
    /// 重置客户端APP的SecretKey
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<SysClientApp> ResetClientAppSecretAsync(ResetClientAppSecretInput dto);
}

