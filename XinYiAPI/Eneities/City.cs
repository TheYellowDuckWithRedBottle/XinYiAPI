using System.ComponentModel.DataAnnotations.Schema;

namespace XinYiAPI.Eneities
{
    [Table("city")]
    public class City
    {
        [Column("id")]
        public string id { get; set; }
        [Column("code")]
        public string code { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("type")]
        public string type { get; set; }
        [Column("province")]
        public string province { get; set; }
        [Column("province_code")]
        public string provinceCode { get; set; }
        [Column("province_type")]
        public string provinceType { get; set; }
        [Column("ENG_NAME")]
        public string eng_name { get; set; }
        [Column("VAR_NAME")]
        public string var_name { get; set; }
        [Column("NAME_2")]
        public string name2 { get; set; }
        [Column("VAR_NAME2")]
        public string varName2 { get; set; }
    }
}
