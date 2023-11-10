
namespace FastNet.Model.Dto;

/// <summary>
/// API资源更新DTO
/// </summary>
public class UpdateApiResourceInput
{
    /// <summary>
    /// API资源编号
    /// </summary>
    public long Id { get; set; }


    /// <summary>
    /// 名称
    ///</summary>
    public string Name { get; set; }


    /// <summary>
    /// 分组 - 用字典定义资源分组
    ///</summary>
    public string Group { get; set; }

    /// <summary>
    /// API路由
    ///</summary>
    public string Router { get; set; }
 
    /// <summary>
    /// API资源路径
    ///</summary>
    public string Path { get; set; }
 
    /// <summary>
    /// API请求方法 - GET、POST
    ///</summary>
    public string Method { get; set; }

    /// <summary>
    /// 摘要
    ///</summary>
    public string Summary { get; set; }

    /// <summary>
    /// 备注
    ///</summary>
    public string Remark { get; set; }


    /// <summary>
    /// 排序
    ///</summary>
    public int Order { get; set; } = 0;
    /// <summary>
    /// 状态
    /// </summary>
    public DataStatus Status { get; set; }
}
