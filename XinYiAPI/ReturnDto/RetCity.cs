using System.Collections;
using System.Collections.Generic;

namespace XinYiAPI.ReturnDto
{
    public class RetCity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IList<RetDistrict> Children { get; set; }
        public RetCity(string id,string name, string code)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
        }

    }
}