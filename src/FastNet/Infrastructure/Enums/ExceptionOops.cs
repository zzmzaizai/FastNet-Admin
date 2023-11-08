using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Infrastructure;

/// <summary>
/// 异常的提醒枚举
/// </summary>
public enum ExceptionOops
{
    /// <summary>
    /// 指定的属性“{0}”在类型“{1}”中不存在
    /// </summary>
    [Description("指定的属性“{0}”在类型“{1}”中不存在")]
    Field_In_Type_Not_Found,
}

