﻿using Newtonsoft.Json.Converters;
using System.Data;

namespace FastNet.Infrastructure;

public static class JsonExtensions
{
    public static object ToJson(this string Json)
    {
        return Json == null ? null : JsonConvert.DeserializeObject(Json);
    }
    public static string ToJson(this object obj)
    {
        var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss", Culture = new System.Globalization.CultureInfo("zh-CN") };
        return JsonConvert.SerializeObject(obj, Formatting.Indented, timeConverter);
    }

    public static string ToJson(this object obj, string datetimeformats)
    {
        var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss", Culture = new System.Globalization.CultureInfo("zh-CN") };
        return JsonConvert.SerializeObject(obj, Formatting.Indented, timeConverter);
    }
    public static T ToObject<T>(this string Json)
    {
        return Json == null ? default : JsonConvert.DeserializeObject<T>(Json);
    }
    public static List<T> ToList<T>(this string Json)
    {
        return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json);
    }
    public static DataTable ToTable(this string Json)
    {
        return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json);
    }
    public static JObject ToJObject(this string Json)
    {
        return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
    }


}
