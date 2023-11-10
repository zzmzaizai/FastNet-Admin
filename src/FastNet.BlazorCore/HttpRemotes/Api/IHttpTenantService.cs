﻿
using Furion.DataEncryption.Extensions;
using Microsoft.AspNetCore.Http;
using SqlSugar;
using System.Text;

namespace FastNet.BlazorCore;


/// <summary>
/// 租户服务 - WEB API 远程请求接口封装
/// </summary>
[Client("system")]
public interface IHttpTenantService : IBaseHttpRemote
{

    /// <summary>
    /// 插入租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Post("/api/system/role")]
    Task<SysTenant> InsertAsync(InsertTenantInput dto);

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Put("/api/system/role")]
    Task<SysTenant> UpdateAsync(UpdateTenantInput dto);

    /// <summary>
    /// 根据主机名获取租户信息
    /// </summary>
    /// <param name="HostName">主机名</param>
    /// <returns>找不到时返回默认租户</returns>
    /// <returns></returns>
    [Get("/api/host/tenant/tenant-by-host-name/{hostname}")]
    Task<SysTenant> GetTenantByHostNameAsync(string HostName);

    /// <summary>
    /// 获取单个租户信息
    /// </summary>
    /// <param name="TenantId">租户Id</param>
    /// <returns></returns>
    [Get("/api/host/tenant/{tenantid}")]
    Task<SysTenant> GetAsync(long TenantId);

    /// <summary>
    /// 获取当前租户信息
    /// </summary>
    /// <returns></returns>
    [Get("/api/host/tenant/current")]
    Task<SysTenant> GetCurrent();



    /// <summary>
    /// 获取当前租户Id
    /// </summary>
    /// <returns></returns>
    [Get("/api/host/tenant/current-tenant-id")]
    public long GetCurrentTenantId();

    /// <summary>
    /// 填充一个默认租户
    /// </summary>
    /// <returns></returns>
    [Post("/api/host/tenant/fill-tenant/{isdefault}/{domainname}")]
    Task<SysTenant> FillTenant(bool IsDefault, string DomainName);

    /// <summary>
    /// 切换租户站点
    /// </summary>
    /// <param name="TenantId">租户编号</param>
    /// <returns></returns>
    [Post("/api/host/tenant/change-tenant-site/{tenantid}")]
    Task<bool> ChangeTenantSite(long TenantId);


    /// <summary>
    /// 分页列表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [Get("/api/host/tenant/page-list")]
    Task<SqlSugarPagedList<SysTenantPageOutput>> GetPageListAsync([FromQuery] QueryTenantPagedInput dto);




}
