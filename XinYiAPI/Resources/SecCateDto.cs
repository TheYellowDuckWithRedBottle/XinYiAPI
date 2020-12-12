using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinYiAPI.Models;

namespace XinYiAPI.Resources
{
    public class SecCateDto:SecCate
    {
        public double area { get; set; }
        public double percent { get; set; }
    }
}
