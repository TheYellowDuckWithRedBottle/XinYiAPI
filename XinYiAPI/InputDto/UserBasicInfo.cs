using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace XinYiAPI.InputDto
{
    public class UserBasicInfo
    {
        public string id { get; set; }
       
        public string username { get; set; }
 
        public string email { get; set; }
    
        public string phone { get; set; }
     
        public string role { get; set; }
 
        public string avatar { get; set; }
    }
}
