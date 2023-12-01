using System.Collections.Generic;
using System.Linq;
using XinYiAPI.DataAccess.Base;
using XinYiAPI.DataAccess.Interface;
using XinYiAPI.Eneities;

namespace XinYiAPI.Services
{
    public class ProvinceService : IProvinceDao
    {
        public AlanContext provinceContext;
        public ProvinceService(AlanContext provinceContext)
        {
            this.provinceContext = provinceContext;
        }
        public bool CreateProvince(Province province)
        {
            provinceContext.provinces.Add(province);
            return provinceContext.SaveChanges() > 0;
        }

        public bool DeleteProvince(int id)
        {
            Province province = provinceContext.provinces.SingleOrDefault(s=> s.id == id);
            provinceContext.provinces.Remove(province);
            return provinceContext.SaveChanges() > 0;
        }

        public Province GetProvinceById(int id)
        {
            Province province = provinceContext.provinces.SingleOrDefault(s => s.id == id);
            return province;
        }

        public IEnumerable<Province> GetProvinces()
        {
            return provinceContext.provinces.ToList();
        }

        public bool UpdateProvince(Province province)
        {
            provinceContext.provinces.Update(province);
            return provinceContext.SaveChanges() > 0;
        }
    }
}
