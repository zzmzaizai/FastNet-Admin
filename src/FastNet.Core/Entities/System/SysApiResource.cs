namespace FastNet.Core;
/// <summary>
/// Api资源表实体
/// </summary>
[SugarTable("sys_apiresource", TableDescription = "Api资源表")]
[Tenant("FastNet")]
public class SysApiResource : DataEntityBase
{


    /// <summary>
    /// 名称
    ///</summary>
    [SugarColumn(ColumnDescription = "名称", Length = 200, IsNullable = false)]
    public virtual string Name { get; set; }


    /// <summary>
    /// 分组 - 用字典定义资源分组
    ///</summary>
    [SugarColumn(ColumnDescription = "分组", Length = 50, IsNullable = true)]
    public virtual string Group { get; set; }

    /// <summary>
    /// API路由
    ///</summary>
    [SugarColumn(ColumnDescription = "API路由", Length = 500, IsNullable = false)]
    public virtual string Router { get; set; }


    /// <summary>
    /// API资源路径
    ///</summary>
    [SugarColumn(ColumnDescription = "API资源路径", Length = 500, IsNullable = false)]
    public virtual string Path { get; set; }



    /// <summary>
    /// API请求方法 - GET、POST
    ///</summary>
    [SugarColumn(ColumnDescription = "API请求方法", Length = 10, IsNullable = false)]
    public virtual string Method { get; set; }

    /// <summary>
    /// 摘要
    ///</summary>
    [SugarColumn(ColumnDescription = "摘要", Length = 150, IsNullable = true)]
    public virtual string Summary { get; set; }

    /// <summary>
    /// 备注
    ///</summary>
    [SugarColumn(ColumnDescription = "备注", Length = 500, IsNullable = true)]
    public virtual string Remark { get; set; }


    /// <summary>
    /// 排序
    ///</summary>
    [SugarColumn(ColumnDescription = "排序", IsNullable = false)]
    public int Order { get; set; } = 0;
    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(ColumnDescription = "状态", IsNullable = false)]
    public virtual DataStatus Status { get; set; }
}
 
