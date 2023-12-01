using System.Collections;
using System.Collections.Generic;
using XinYiAPI.Eneities;

namespace XinYiAPI.DataAccess.Interface
{
    public interface ICityDao
    {
        IEnumerable<City> GetCities();
        City GetCityById(int id);
        bool CreateCity(City city);
        bool UpdateCity(City city);
        bool DeleteCity(int id);
    }
}
