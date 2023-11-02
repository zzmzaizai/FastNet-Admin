using Furion.DataValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.SqlSugar
{
    /// <summary>
    /// 翻页基础输入项
    /// </summary>
    public class BasePagedInput : IValidatableObject
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        [DataValidation(ValidationTypes.Numeric)]
        public virtual int Index { get; set; } = 1;

        /// <summary>
        /// 每页条数
        /// </summary>
        [Range(1, 100, ErrorMessage = "页码容量超过最大限制")]
        [DataValidation(ValidationTypes.Numeric)]
        public virtual int Size { get; set; } = 10;

        /// <summary>
        /// 排序字段
        /// </summary>
        public virtual string SortField { get; set; }

        /// <summary>
        /// 排序方式，升序：ascend；降序：descend"
        /// </summary>
        public virtual string SortOrder { get; set; } = "desc";

        /// <summary>
        /// 搜索文本
        /// </summary>
        public virtual string SearchText { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //配合小诺排序参数
            if (SortOrder == "descend")
            {
                SortOrder = "desc";
            }
            else if (SortOrder == "ascend")
            {
                SortOrder = "asc";
            }
            if (!string.IsNullOrEmpty(SortField))
            {
                //分割排序字段
                var fields = SortField.Split(" ");
                if (fields.Length > 1)
                {
                    yield return new ValidationResult($"排序字段错误", new[]
                    {
                    nameof(SortField)
                });
                }
            }
            yield break;
        }
    }
}
