﻿namespace FastNet.Infrastructure;

public static class StringExtension
{

    /// <summary>
    /// SQL条件拼接
    /// </summary>
    /// <param name="str"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    public static string If(this string str, bool condition)
    {
        return condition ? str : string.Empty;
    }
    /// <summary>
    /// 判断是否为空
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IfNotEmpty(this string str)
    {
        return !string.IsNullOrEmpty(str);
    }

    /// <summary>
    /// 注意：如果替换的旧值中有特殊符号，替换将会失败，解决办法 例如特殊符号是“(”：  要在调用本方法前加oldValue=oldValue.Replace("(","//(");
    /// </summary>
    /// <param name="input"></param>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public static string ReplaceFirst(this string input, string oldValue, string newValue)
    {
        var regEx = new Regex(oldValue, RegexOptions.Multiline);
        return regEx.Replace(input, newValue == null ? "" : newValue, 1);
    }

    /// <summary>
    /// 骆驼峰转下划线
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string ToSmallCamelCase(string name)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(name.Substring(0, 1).ToLower());

        for (var i = 0; i < name.Length; i++)
            if (i == 0)
                stringBuilder.Append(name.Substring(0, 1).ToLower());
            else
                if (name[i] >= 'A' && name[i] <= 'Z')
                    stringBuilder.Append($"_{name.Substring(i, 1).ToLower()}");
                else
                    stringBuilder.Append(name[i]);

        return stringBuilder.ToString();
    }

    /// <summary>
    /// 下划线命名转驼峰命名
    /// </summary>
    /// <param name="underscore"></param>
    /// <returns></returns>
    public static string UnderScoreToCamelCase(this string underscore)
    {
        var ss = underscore.Split("_");
        if (ss.Length == 1)
            return underscore;

        StringBuilder sb = new();
        sb.Append(ss[0]);
        for (var i = 1; i < ss.Length; i++)
            sb.Append(ss[i].FirstUpperCase());

        return sb.ToString();
    }

    /// <summary>
    /// 首字母转大写
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string FirstUpperCase(this string str)
    {
        return string.IsNullOrEmpty(str) ? str : str[..1].ToUpper() + str[1..];
    }

    /// <summary>
    /// 首字母转小写
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string FirstLowerCase(this string str)
    {
        return string.IsNullOrEmpty(str) ? str : str.Substring(0, 1).ToLower() + str[1..];
    }

    /// <summary>
    /// 截取指定字符串中间内容
    /// </summary>
    /// <param name="sourse"></param>
    /// <param name="startstr"></param>
    /// <param name="endstr"></param>
    /// <returns></returns>
    public static string SubStringBetween(this string sourse, string startstr, string endstr)
    {
        var result = string.Empty;
        int startindex, endindex;
        try
        {
            startindex = sourse.IndexOf(startstr);
            if (startindex == -1)
                return result;
            var tmpstr = sourse[(startindex + startstr.Length)..];
            endindex = tmpstr.IndexOf(endstr);
            if (endindex == -1)
                return result;
            result = tmpstr.Remove(endindex);
        }
        catch (Exception ex)
        {
            Console.WriteLine("MidStrEx Err:" + ex.Message);
        }
        return result;
    }

    /// <summary>
    /// 转换为Pascal风格-每一个单词的首字母大写
    /// </summary>
    /// <param name="fieldName">字段名</param>
    /// <param name="fieldDelimiter">分隔符</param>
    /// <returns></returns>
    public static string ConvertToPascal(this string fieldName, string fieldDelimiter)
    {
        var result = string.Empty;
        if (fieldName.Contains(fieldDelimiter))
        {
            //全部小写
            var array = fieldName.ToLower().Split(fieldDelimiter.ToCharArray());
            foreach (var t in array)
                //首字母大写
                result += t.Substring(0, 1).ToUpper() + t[1..];
        }
        else if (string.IsNullOrWhiteSpace(fieldName))
            result = fieldName;
        else if (fieldName.Length == 1)
            result = fieldName.ToUpper();
        else if (fieldName.Length == fieldName.CountUpper())
            result = fieldName[..1].ToUpper() + fieldName[1..].ToLower();
        else
            result = fieldName[..1].ToUpper() + fieldName[1..];
        return result;
    }

    /// <summary>
    /// 大写字母个数
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int CountUpper(this string str)
    {
        var count1 = 0;
        var chars = str.ToCharArray();
        foreach (var num in chars)
            if (num >= 'A' && num <= 'Z')
                count1++;
        return count1;
    }

    /// <summary>
    /// 转换为Camel风格-第一个单词小写，其后每个单词首字母大写
    /// </summary>
    /// <param name="fieldName">字段名</param>
    /// <param name="fieldDelimiter">分隔符</param>
    /// <returns></returns>
    public static string ConvertToCamel(this string fieldName, string fieldDelimiter)
    {
        //先Pascal
        var result = fieldName.ConvertToPascal(fieldDelimiter);
        //然后首字母小写
        if (result.Length == 1)
            result = result.ToLower();
        else
            result = result[..1].ToLower() + result[1..];

        return result;
    }


    #region 字符串分割
    /// <summary>
    /// 根据标志分割字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="sign">分割标识</param>
    /// <param name="option">分割结果去重方式</param>
    /// <returns></returns>

    public static string[] SplitBySign(this string str, string sign, StringSplitOptions option = StringSplitOptions.None) => str?.Split(new string[] { sign }, option) ?? new string[0];
    /// <summary>
    /// 根据标志分割字符串(不包含空字符串)
    /// </summary>
    /// <param name="str"></param>
    /// <param name="sign"></param>
    /// <returns></returns>
    public static string[] SplitBySignWithoutEmpty(this string str, string sign) => str.SplitBySign(sign, StringSplitOptions.RemoveEmptyEntries);
    /// <summary>
    /// 根据标志分割字符串后获得第一个字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="sign"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static string SplitThenGetFirst(this string str, string sign, StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries) => str?.SplitBySign(sign, option).FirstOrDefault();
    /// <summary>
    /// 根据标志分割字符串后获得最后一个字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="sign">分割标志</param>
    /// <param name="option">分割结果去重方式</param>
    /// <returns></returns>
    public static string SplitThenGetLast(this string str, string sign, StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries) => str?.SplitBySign(sign, option).LastOrDefault();

    /// <summary>
    /// 根据标志分割字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="signs">分割标识，多重标识</param>
    /// <returns></returns>
    public static string[] SplitByMultiSign(this string str, params string[] signs) => str?.Split(signs, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
    /// <summary>
    /// 根据 | \ / 、 ， , 空格 中文空格 制表符空格换行 分割字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="option">分割结果去重方式</param>
    /// <returns></returns>
    public static string[] SplitAuto(this string str, StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries) =>
        str.SplitByMultiSign("|", "\\", "/", "、", ":", "：", "，", ",", "　", " ", "\t");
    /// <summary>
    /// 根据换行符拆分字符串
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string[] SplitByLine(this string str) => str.SplitByMultiSign("\r\n", "\r", "\n");

    /// <summary>
    /// 根据竖线符 | 拆分字符串
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string[] SplitByYLine(this string str) => str.SplitByMultiSign("|");

    /// <summary>
    /// 根据逗号拆分字符串并转换成int
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int[] SplitToInts(this string str) => Array.ConvertAll(str.SplitByMultiSign(","), (s) => { return int.Parse(s); });
    #endregion
}
