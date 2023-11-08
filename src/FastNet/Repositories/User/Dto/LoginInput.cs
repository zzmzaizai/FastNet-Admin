﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastNet.Repositories
{
    /// <summary>
    /// 用户登录输入项
    /// </summary>
    public class LoginInput
    {

        /// <summary>
        /// 账号
        ///</summary>
        public string UserName { get; set; }


        /// <summary>
        /// 密码
        ///</summary>
        public string Password { get; set; }

    }
}