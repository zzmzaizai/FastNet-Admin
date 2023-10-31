using Furion;
using System.Reflection;

namespace FastNet.Admin.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
             "FastNet.SqlSugar",
              "FastNet.Application",
            "FastNet.Application",
            "FastNet.Core",
            "FastNet.Web.Core"
        };
    }
}