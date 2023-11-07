namespace FastNet.SqlSugar;

public class DatabaseUtils
{
    /// <summary>
    /// 获取雪花Id
    /// </summary>
    /// <returns></returns>
    public static long GetDataId()
    {
        return SnowFlakeSingle.Instance.NextId();
    }
}
