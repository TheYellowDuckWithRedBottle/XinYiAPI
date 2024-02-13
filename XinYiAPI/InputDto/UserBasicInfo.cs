using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace XinYiAPI.InputDto
{
    public class UserBasicInfo
    {
        public string id { get; set; }
        [Column("username")]
        public string username { get; set; }
 
        [Column("email")]
        public string email { get; set; }
        [Column("phone")]
        public string phone { get; set; }
        [Column("role")]
        public string role { get; set; }
  
        [Column("avatar")]
        public string avatar { get; set; }
    }
}
