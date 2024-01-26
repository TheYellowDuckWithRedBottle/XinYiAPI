using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XinYiAPI.Eneities;
using XinYiAPI.ReturnDto;
using XinYiAPI.Services;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProvinceController : ControllerBase
    {
        private ProvinceService ProvinceService;
        private CityService CityService;
        private DistrictService DistrictService;
        public ProvinceController(ProvinceService provinceService, CityService cityService, DistrictService districtService)
        {
            this.ProvinceService = provinceService;
            this.CityService = cityService;
            this.DistrictService = districtService;
        }
        [HttpGet]
        public IActionResult provinces()
        {
            return Ok(ProvinceService.GetProvinces());
        }
        [HttpGet]
        // 根据省获取省下面的城市
        public IActionResult cities([FromQuery] string provinceName)
        {
            // 获取省下面的城市
            var newCityList = this.getCities(provinceName);
            return Ok(newCityList);
        }
        // 根据省获取城市下面的区县
        [HttpGet]
        public IActionResult counties([FromQuery] string provinceName)
        {
            // 获取省下面的区县
            var newDistrictList = GetDistricts(provinceName);
            return Ok(newDistrictList);
        }
        // 根据省获取省的tree
        [HttpGet]
        public IActionResult provinceTree([FromQuery] string provinceName)
        {
            // 获取省下面的城市
            var province = ProvinceService.GetProvinceByName(provinceName);
            // 获取省下面的城市
            var newCityList = getCities(provinceName);

            // 把cityList塞给RetProvince
            var RetProvince = new RetProvince(province.id, province.name, province.code);
            List<RetCity> RetCityList = new List<RetCity>();
            RetProvince.Children = RetCityList;

            foreach (var item in newCityList)
            {
                var RetCity = new RetCity(item.id, item.name, item.code);
                // 获取城市下面的区县
                var newDistrictList = GetDistrictsByCityName(item.name);
                List<RetDistrict> RetDistrictList = new List<RetDistrict>();
                foreach (var district in newDistrictList)
                {
                    var RetDistrict = new RetDistrict(district.Id, district.name, district.code);
                    RetDistrictList.Add(RetDistrict);
                }
                RetCity.Children = RetDistrictList;
                RetCityList.Add(RetCity);
            }

            return Ok(RetProvince);
        }
        [HttpGet]
        public IActionResult testAuto() {
            return Ok("测试成功");
        }





        // 根据省获取省的城市
        private List<City> getCities(string provinceName)
        {
            var cityList = CityService.GetCities();
            var newCityList = new List<City>();
            for (int i = 0; i < cityList.Count; i++)
            {
                // 模糊查询
                if (cityList[i].province.Contains(provinceName))
                {
                    newCityList.Add(cityList[i]);
                }
            }
            return newCityList;
        }
        // 根据省获取省的区县
        private List<District> GetDistricts(string provinceName)
        {
            var districtList = DistrictService.GetDistricts();
            var newDistrictList = new List<District>();
            for (int i = 0; i < districtList.Count; i++)
            {
                // 模糊查询
                if (districtList[i].province.Contains(provinceName))
                {
                    newDistrictList.Add(districtList[i]);
                }
            }
            return newDistrictList;
        }
        // 根据市获取市的区县
        private List<District> GetDistrictsByCityName(string cityName)
        {
            var districtList = DistrictService.GetDistricts();
            var newDistrictList = new List<District>();
            for (int i = 0; i < districtList.Count; i++)
            {
                // 模糊查询
                if (districtList[i].city.Contains(cityName))
                {
                    newDistrictList.Add(districtList[i]);
                }
            }
            return newDistrictList;
        }
    }
}
