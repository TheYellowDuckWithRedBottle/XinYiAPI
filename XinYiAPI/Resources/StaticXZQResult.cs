using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinYiAPI.Models;

namespace XinYiAPI.Resources
{
    public class StaticXZQResult
    {
        public string XZQMC { get; set; }
        public List<Dictionary<string, double>> Cate { get; set; }

        public List<cateArea> cateArea { get; set; }
    }
    public class cateArea
    {
        private double _area;
        public string cateCode { get; set; }
        public string cateName { get; set; }
        public double percent { get; set; }
        public double area { get { return _area; } set { _area = Math.Round(value, 2); } }

        public LandSpaceDto landSpaceDto { get; set; }
    }
}
