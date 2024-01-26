using System.Collections.Generic;
using XinYiAPI.Eneities;

namespace XinYiAPI.ReturnDto
{
    // 包含省市区的树形结构
    public class RegionTree
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<Province> Children { get; set; }
        
    }
}
