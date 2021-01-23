using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azeroth.Util {
    public class ApiResult<T>
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public System.Net.HttpStatusCode code { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 正常处理的结果
        /// </summary>
        public T data { get; set; }


    }
}
