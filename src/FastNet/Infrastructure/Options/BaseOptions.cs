﻿

namespace FastNet.Infrastructure;

/// <summary>
/// 基础设置
/// </summary>
public class BaseOptions
{
    /// <summary>
    /// 初始化表
    /// </summary>
    public bool InitTable { get; set; } = false;

    /// <summary>
    /// 初始化数据
    /// </summary>
    public bool InitSeedData { get; set; } = false;
}
