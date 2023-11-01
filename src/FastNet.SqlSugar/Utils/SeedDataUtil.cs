
namespace FastNet.SqlSugar;

public class SeedDataUtil
{
    public static List<T> GetSeedData<T>(string jsonName)
    {
        var seedData = new List<T>();//种子数据结果
        var basePath = AppContext.BaseDirectory;//获取项目目录
        var json = Path.Combine("SeedData", "Json", jsonName); //获取文件路径
        var dataString = File.ReadAllText(json); ;//读取文件
        if (!string.IsNullOrEmpty(dataString))//如果有内容
        {
            //字段没有数据的替换成null
            dataString = dataString.Replace("\"\"", "null");
            //将json字符串转为实体，这里extjson可以正常转换为字符串
            var seedDataRecord1 = dataString.ToObject<SeedDataRecords<T>>();
 
            //种子数据赋值
            seedData = seedDataRecord1.Records;
        }

        return seedData;
    }
}

/// <summary>
/// 种子数据格式实体类,遵循Navicat导出json格式
/// </summary>
/// <typeparam name="T"></typeparam>
public class SeedDataRecords<T>
{
    /// <summary>
    /// 数据
    /// </summary>
    public List<T> Records { get; set; }
}
