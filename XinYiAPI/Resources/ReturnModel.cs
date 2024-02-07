using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XinYiAPI.Resources
{
    public class ReturnModel
    {
        public int code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// Token信息
        /// </summary>
      
    }
}
