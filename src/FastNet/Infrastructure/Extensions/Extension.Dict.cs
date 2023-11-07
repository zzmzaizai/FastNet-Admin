using StackExchange.Profiling.Internal;


namespace FastNet.Infrastructure;

public static partial class Extensions
{

    /// <summary>
    /// 获取 Hashtable 中的值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hash"></param>
    /// <param name="key"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static T Get<T>(this Hashtable hash, object key, T defaultValue)
    {
        return ConvertChangeType<T>(hash[key] != null ? hash[key] : defaultValue, defaultValue);
    }

    public static T Get<T>(this IDictionary<string, string> hash, string key, T defaultValue)
    {
        return ConvertChangeType<T>(hash.ContainsKey(key) && hash[key] != null ? hash[key] : defaultValue, defaultValue);
    }

    public static T Get<T>(this IDictionary<object, object> hash, string key, T defaultValue)
    {
        return ConvertChangeType<T>(hash.ContainsKey(key) && hash[key] != null ? hash[key] : defaultValue, defaultValue);
    }

    public static T Get<T>(this IDictionary hash, object key, T defaultValue)
    {
        return ConvertChangeType<T>(hash.Contains(key) && hash[key] != null ? hash[key] : defaultValue, defaultValue);
    }



    /// <summary>
    /// 转换类型，某些情况下空数据的处理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static T ConvertChangeType<T>(object value, object defaultValue)
    {
        if (Convert.ToString(value).IsNullOrWhiteSpace())
        {
            var Types = new Type[] { typeof(bool), typeof(int), typeof(float), typeof(double) };
            if (Types.Contains(typeof(T)))
            {
                value = defaultValue;
            }
        }
        return (T)Convert.ChangeType(value, typeof(T));
    }

    /// <summary>
    /// 设置 Hashtable
    /// key 存在则更新，不存在则新增
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void Set(this Hashtable hash, object key, object value)
    {
        if (hash.ContainsKey(key))
        {
            hash[key] = value;
        }
        else
        {
            hash.Add(key, value);
        }
    }

    /// <summary>
    /// 设置 Hashtable
    /// key 存在则更新，不存在则新增
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void Set(this IDictionary<object, object> hash, object key, object value)
    {
        if (hash.ContainsKey(key.ToString()))
        {
            hash[key] = value;
        }
        else
        {
            hash.Add(key, value);
        }
    }

    /// <summary>
    /// 设置 Hashtable
    /// key 存在则更新，不存在则新增
    /// </summary>
    /// <param name="hash"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void Set(this IDictionary hash, object key, object value)
    {
        if (hash.Contains(key))
        {
            hash[key] = value;
        }
        else
        {
            hash.Add(key, value);
        }
    }

    /// <summary>
    /// 把 Hashtable 转换成 Dictionary
    /// </summary>
    /// <param name="hash"></param>
    /// <returns></returns>
    public static Dictionary<string, string> ToDictionary(this Hashtable hash)
    {
        var Dicts = new Dictionary<string, string>();
        if (hash != null && hash.Count > 0)
        {
            foreach (var key in hash.Keys)
            {
                Dicts.Add(key.ToString(), hash[key].ToString());

            }
        }
        return Dicts;
    }
}
