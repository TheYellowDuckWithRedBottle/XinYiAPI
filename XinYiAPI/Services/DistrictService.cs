using System.Collections.Generic;
using System.Linq;
using XinYiAPI.DataAccess.Base;
using XinYiAPI.DataAccess.Interface;
using XinYiAPI.Eneities;

namespace XinYiAPI.Services
{
    public class DistrictService : IDistrictDao
    {
        private readonly AlanContext districtContext;
        public DistrictService(AlanContext AlanContext)
        {
            this.districtContext = AlanContext;
        }
        public bool CreateDistrict(District district)
        {
            districtContext.districts.Add(district);
            return districtContext.SaveChanges() > 0;
        }

        public bool DeleteDistrict(int id)
        {
            District district = districtContext.districts.SingleOrDefault(s => s.Id == id);
            districtContext.Remove(district);
            return  districtContext.SaveChanges() > 0;
        }

        public District GetDistrictById(int id)
        {
            District district = districtContext.districts.SingleOrDefault(s => s.Id == id);
            return district;
        }

        public IEnumerable<District> GetDistricts()
        {
            return districtContext.districts.ToList();
        }

        public bool UpdateDistrict(District district)
        {
            districtContext.districts.Update(district);
            return districtContext.SaveChanges() > 0;
        }
    }
}
