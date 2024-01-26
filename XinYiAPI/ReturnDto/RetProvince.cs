using System.Collections.Generic;

namespace XinYiAPI.ReturnDto
{
    public class RetProvince
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IList<RetCity> Children { get; set; }
        public RetProvince(string id,string Name,string Code)
        {
            this.Id = id;
            this.Name = Name;
            this.Code = Code;
        }
        public RetProvince()
        {
            
        }
    }
}
