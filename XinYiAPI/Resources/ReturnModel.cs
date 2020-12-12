using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XinYiAPI.Resources
{
    public class ReturnModel
    {
        public int Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Token信息
        /// </summary>
      
    }
}
