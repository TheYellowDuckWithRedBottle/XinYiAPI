using System.Collections.Generic;
using System.Linq;
using XinYiAPI.DataAccess.Base;
using XinYiAPI.DataAccess.Interface;
using XinYiAPI.Eneities;

namespace XinYiAPI.Services
{
    public class CityService : ICityDao
    {
        private readonly AlanContext CityContext;
        public CityService(AlanContext alanContext)
        {
            this.CityContext = alanContext;
        }
        public bool CreateCity(City city)
        {
            CityContext.citys.Add(city);
            return CityContext.SaveChanges() > 0;
        }

        public bool DeleteCity(string id)
        {
            var city = CityContext.citys.SingleOrDefault(s => s.id == id);
            CityContext.citys.Remove(city);
            return CityContext.SaveChanges() > 0;
        }

        public IList<City> GetCities()
        {
           return CityContext.citys.ToList();
        }

        public City GetCityById(string id)
        {
            var city = CityContext.citys.SingleOrDefault(s => s.id == id);
            return city;
        }

        public bool UpdateCity(City city)
        {
            CityContext.citys.Update(city);
            return CityContext.SaveChanges() > 0;
        }
    }
}
