using Org.BouncyCastle.Bcpg.OpenPgp;

namespace XinYiAPI.ReturnDto
{
    public class RetDistrict
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public RetDistrict(string id,string name, string code )
        {
            Id = id;
            Name = name;
            Code = code;
        }
    }
}