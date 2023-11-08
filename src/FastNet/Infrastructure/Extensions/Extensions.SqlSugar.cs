using Furion.LinqBuilder;
using StackExchange.Profiling.Internal;
using System.Security.Principal;

namespace FastNet.Infrastructure;

public static partial class Extensions
{
    /// <summary>
    /// 多字段排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="orderConditions"></param>
    /// <returns></returns>
    public static ISugarQueryable<T> OrderConditions<T>(this ISugarQueryable<T> query, System.Collections.Generic.List<OrderByModel> orderConditions)
    {
        if (orderConditions == null || !orderConditions.Any()) return query;
        return query.OrderConditions<T>(orderConditions.ToArray());
    }
    /// <summary>
    /// 多字段排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="orderConditions"></param>
    /// <returns></returns>
    public static ISugarQueryable<T> OrderConditions<T>(this ISugarQueryable<T> query, OrderByModel[] orderConditions)
    {
        if (orderConditions == null || !orderConditions.Any()) return query;
        return query.OrderConditions(orderConditions.ToList());
    }


    /// <summary>
    /// OR相连的筛选语句
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="filterConditions"></param>
    /// <returns></returns>
    public static ISugarQueryable<T> FiltersConditions<T>(this ISugarQueryable<T> query, Dictionary<string, string> filterConditions)
        where T : class, new()
    {
        if (filterConditions == null || !filterConditions.Any()) return query;


        var conModels = new List<IConditionalModel>();
        var ConditionalList = new List<KeyValuePair<WhereType, ConditionalModel>>();
        foreach (var filterCondition in filterConditions)
        {
            ConditionalList.Add(new KeyValuePair<WhereType, ConditionalModel>(WhereType.Or, new ConditionalModel() { FieldName = filterCondition.Key, ConditionalType = ConditionalType.Like, FieldValue = filterCondition.Value }));
        }

        conModels.Add(new ConditionalCollections()
        {
            ConditionalList = ConditionalList
        });
        return query.Where(conModels);
    }


    /// <summary>
    /// 分页拓展
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static SqlSugarPagedList<TEntity> ToPagedList<TEntity, InEntity>(this ISugarQueryable<InEntity> entity, int pageIndex, int pageSize)
        where TEntity : new()
    {
        var totalCount = 0;
        var items = entity.ToPageList(pageIndex, pageSize, ref totalCount);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        return new SqlSugarPagedList<TEntity>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Items = items.Adapt<List<TEntity>>(),
            TotalCount = (int)totalCount,
            TotalPages = totalPages,
            HasNextPages = pageIndex < totalPages,
            HasPrevPages = pageIndex - 1 > 0
        };
    }

    /// <summary>
    /// 分页拓展
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static async Task<SqlSugarPagedList<TEntity>> ToPagedListAsync<TEntity, InEntity>(this ISugarQueryable<InEntity> entity, int pageIndex, int pageSize)
        where TEntity : new()
    {
        RefAsync<int> totalCount = 0;
        var items = await entity.ToPageListAsync(pageIndex, pageSize, totalCount);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        return new SqlSugarPagedList<TEntity>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Items = items.Adapt<List<TEntity>>(),
            TotalCount = (int)totalCount,
            TotalPages = totalPages,
            HasNextPages = pageIndex < totalPages,
            HasPrevPages = pageIndex - 1 > 0
        };
    }



}