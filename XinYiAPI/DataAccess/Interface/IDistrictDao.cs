using System.Collections;
using System.Collections.Generic;
using XinYiAPI.Eneities;

namespace XinYiAPI.DataAccess.Interface
{
    public interface IDistrictDao
    {
        IEnumerable<District> GetDistricts();
        District GetDistrictById(string id);
        bool CreateDistrict(District district);
        bool UpdateDistrict(District district);
        bool DeleteDistrict(string id);

    }
}
