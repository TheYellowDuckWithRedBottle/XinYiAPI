using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XinYiAPI.Eneities
{
    [Table("mapTemplate")]
    public class MapTemplate
    {
        [Column("id")]
        public string id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("Title")]
        public string title { get; set; }
        [Column("desc")]
        public string desc { get; set; }
        [Column("cover")]
        public string cover { get; set; }
        [Column("epsg")]
        public string EPSG { get; set; }
        [Column("create_at")]
        public DateTime createTime { get; set; }
        [Column("update_at")]
        public DateTime updateTime { get; set; }
        [Column("create_user")]
        public string createUser { get; set; }

    }
}
