using System.ComponentModel.DataAnnotations.Schema;

namespace XinYiAPI.Eneities
{
    [Table("district")]
    public class District
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        public string code { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("type")]
        public string type { get; set; }
        [Column("city")]
        public string city { get; set; }
        [Column("prefecture_level")]
        public string prefectureLevel { get; set; }
        [Column("province")]
        public string province { get; set; }
        [Column("province_code")]
        public string provinceCode { get; set; }
        [Column("ENG_NAME")]
        public string engName { get; set; }
        [Column("NAME_2")]
        public string name2 { get; set; }
        [Column("VAR_NAME2")]
        public string varName2 { get; set; }    
    }
}
