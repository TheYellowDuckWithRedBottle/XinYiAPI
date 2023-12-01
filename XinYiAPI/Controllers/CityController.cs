using Microsoft.AspNetCore.Mvc;
using System;
using XinYiAPI.Services;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CityController : ControllerBase
    {
        private CityService CityService;
        public CityController(CityService cityService)
        {
            this.CityService = cityService;
        }
        [HttpGet]
        public IActionResult GetCities([FromQuery] int pageIndex = 0,int pageSize=10)
        {
            return Ok(CityService.GetCities());
        }
        [HttpGet]
        [ResponseCache(Duration = 10)]
        public IActionResult reandom()
        {
            Random random = new Random();
            int a = random.Next(1, 1000);
            return Ok(a);
        }
    }
}
