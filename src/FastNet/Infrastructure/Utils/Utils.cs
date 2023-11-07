
namespace FastNet.Infrastructure;

/// <summary>
/// 通用操作类
/// </summary>
public static class Utils
{


    /// <summary>
    /// Clones the entire given object into a new instance.
    /// </summary>
    /// <param name="obj">The object to clone</param>
    /// <typeparam name="T">The object type</typeparam>
    /// <returns>The cloned instance</returns>
    public static T DeepClone<T>(T obj)
    {
        if (obj == null)
        {
            // Null value does not need to be cloned.
            return default(T);
        }

        if (obj is ValueType)
        {
            // Value types do not need to be cloned.
            return obj;
        }

        var settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };
        var json = JsonConvert.SerializeObject(obj, settings);

        return JsonConvert.DeserializeObject<T>(json, settings);
    }
     
}
