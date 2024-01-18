using System.Collections;
using System.Collections.Generic;
using XinYiAPI.Eneities;

namespace XinYiAPI.DataAccess.Interface
{
    public interface ICityDao
    {
        IEnumerable<City> GetCities();
        City GetCityById(string id);
        bool CreateCity(City city);
        bool UpdateCity(City city);
        bool DeleteCity(string id);
    }
}
