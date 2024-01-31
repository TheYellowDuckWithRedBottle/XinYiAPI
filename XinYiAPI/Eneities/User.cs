using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XinYiAPI.Eneities
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public string id { get; set; }
        [Column("username")]
        public string username { get; set; }
        [Column("password")]
        public string password { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("phone")]
        public string phone { get; set; }
        [Column("role")]
        public string role { get; set; }
        [Column("status")]
        public string status { get; set; }
        [Column("create_at")]
        public DateTime createTime { get; set; }
        [Column("update_at")]
        public DateTime updateTime { get; set; }
        [Column("avatar")]
        public string avatar { get; set; }
    }
}
