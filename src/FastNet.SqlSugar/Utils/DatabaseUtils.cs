using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yitter.IdGenerator;

namespace FastNet.SqlSugar
{
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
}
