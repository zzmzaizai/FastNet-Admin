
namespace FastNet.Infrastructure;

    /// <summary>
    /// 搜索排序
    /// </summary>
    public class ListSortDirection
    {
        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; } = null!;
        /// <summary>
        /// 0 asc 
        /// 1 desc
        /// </summary>
        public ListSortType SortType { get; set; } = ListSortType.Desc;
    }

