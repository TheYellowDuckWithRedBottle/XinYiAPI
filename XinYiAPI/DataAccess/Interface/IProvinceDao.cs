using System.Collections;
using System.Collections.Generic;
using XinYiAPI.Eneities;

namespace XinYiAPI.DataAccess.Interface
{
    public interface IProvinceDao
    {
        bool CreateProvince(Province province);
        IEnumerable<Province> GetProvinces();
        Province GetProvinceById(int id);
        bool UpdateProvince(Province province);
        bool DeleteProvince(int id);

    }
}
