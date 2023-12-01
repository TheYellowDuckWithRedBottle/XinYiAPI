using Org.BouncyCastle.Crypto.Engines;
using System.ComponentModel.DataAnnotations.Schema;

namespace XinYiAPI.Eneities
{
    [Table("province")]
    public class Province
    {
        [Column("id")]
        public int id { get; set; }
        [Column("code")]
        public string code { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("type")]
        public string type { get; set; }
        [Column("eng_name")]
        public string eng_name { get; set;}
        [Column("var_name")]
        public string var_name { get; set; }
        [Column("eng_type")]
        public string eng_type { get; set; }
    }
}
