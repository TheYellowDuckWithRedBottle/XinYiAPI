using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinYiAPI.Models;

namespace XinYiAPI.Resources
{
    public class LandSpaceDto
    {
        public LandSpace landSpace { get; set; }
        public string  code { get; set; }
        public string name { get; set; }
        public double Area { get; set; }
    }
}
