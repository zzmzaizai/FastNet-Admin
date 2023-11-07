﻿





namespace FastNet.SqlSugar;

/// <summary>
/// 仓储模式对象
/// </summary>
[SuppressSniffer]
public partial class DatabaseRepository<T> : SimpleClient<T> where T : class, new()
{
    protected ITenant itenant = null;//多租户事务、GetConnection、IsAnyConnection等功能
    /// <summary>
    /// 用户数据
    /// </summary>
    public AuthManager authManager { get; set; }



    /// <summary>
    /// 仓储构造
    /// </summary>
    /// <param name="context"></param>
    public DatabaseRepository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
    {
        Context = DatabaseContext.Db.GetConnectionScopeWithAttr<T>();//ioc注入的对象
        itenant = DatabaseContext.Db;
        authManager = authManager = App.GetService<AuthManager>();
    }

    #region 仓储方法拓展

    #region 插入

    /// <summary>
    /// 批量插入判断走普通导入还是大数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <param name="threshold">阈值</param>
    /// <returns></returns>
    public virtual async Task<int> InsertOrBulkCopy(List<T> data, int threshold = 10000)
    {
        if (data.Count > threshold)
            return await Context.Fastest<T>().BulkCopyAsync(data);//大数据导入
        else
            return await Context.Insertable(data).ExecuteCommandAsync();//普通导入
    }

    #endregion 插入

    #region 列表

    /// <summary>
    /// 获取列表指定多个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    public virtual Task<List<T>> GetListAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, T>> selectExpression)
    {
        return Context.Queryable<T>().Where(whereExpression).Select(selectExpression).ToListAsync();
    }

    /// <summary>
    /// 获取列表指定单个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    public virtual Task<List<string>> GetListAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, string>> selectExpression)
    {
        return Context.Queryable<T>().Where(whereExpression).Select(selectExpression).ToListAsync();
    }

    /// <summary>
    /// 获取列表指定单个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    public virtual Task<List<long>> GetListAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, long>> selectExpression)
    {
        return Context.Queryable<T>().Where(whereExpression).Select(selectExpression).ToListAsync();
    }

    #endregion 列表

    #region 单查

    /// <summary>
    /// 获取指定表的单个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    public virtual Task<string> GetFirstAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, string>> selectExpression)
    {
        return Context.Queryable<T>().Where(whereExpression).Select(selectExpression).FirstAsync();
    }

    /// <summary>
    /// 获取指定表的单个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    public virtual Task<long> GetFirstAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, long>> selectExpression)
    {
        return Context.Queryable<T>().Where(whereExpression).Select(selectExpression).FirstAsync();
    }

    #endregion 单查

    #endregion 仓储方法拓展
}