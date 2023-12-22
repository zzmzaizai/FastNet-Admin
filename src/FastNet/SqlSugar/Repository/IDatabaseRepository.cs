using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.SqlSugar;

/// <summary>
/// 数据仓储接口
/// </summary>
public interface IDatabaseRepository<T> : ISimpleClient<T> where T : class, new()
{
    #region 插入

    /// <summary>
    /// 批量插入判断走普通导入还是大数据
    /// </summary>
    /// <param name="data">数据</param>
    /// <param name="threshold">阈值</param>
    /// <returns></returns>
    Task<int> InsertOrBulkCopy(List<T> data, int threshold = 10000);

    #endregion 插入

    #region 列表

    /// <summary>
    /// 获取列表指定多个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, T>> selectExpression);

    /// <summary>
    /// 获取列表指定单个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    Task<List<string>> GetListAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, string>> selectExpression);

    /// <summary>
    /// 获取列表指定单个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    Task<List<long>> GetListAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, long>> selectExpression);

    #endregion 列表

    #region 单查

    /// <summary>
    /// 获取指定表的单个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    Task<string> GetFirstAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, string>> selectExpression);

    /// <summary>
    /// 获取指定表的单个字段
    /// </summary>
    /// <param name="whereExpression">查询条件</param>
    /// <param name="selectExpression">查询字段</param>
    /// <returns></returns>
    Task<long> GetFirstAsync(Expression<Func<T, bool>> whereExpression, Expression<Func<T, long>> selectExpression);

    #endregion 单查



}
