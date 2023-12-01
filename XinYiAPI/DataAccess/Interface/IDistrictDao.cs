using System.Collections;
using System.Collections.Generic;
using XinYiAPI.Eneities;

namespace XinYiAPI.DataAccess.Interface
{
    public interface IDistrictDao
    {
        IEnumerable<District> GetDistricts();
        District GetDistrictById(int id);
        bool CreateDistrict(District district);
        bool UpdateDistrict(District district);
        bool DeleteDistrict(int id);

    }
}
