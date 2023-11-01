﻿namespace FastNet.Infrastructure.Extensions;

public static partial class Extensions
{
    public static Exception GetOriginalException(this Exception ex)
    {
        if (ex.InnerException == null) return ex;

        return ex.InnerException.GetOriginalException();
    }
}
