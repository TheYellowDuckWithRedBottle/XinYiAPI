using Microsoft.AspNetCore.Mvc;
using XinYiAPI.DataAccess.Interface;
using XinYiAPI.Services;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProvinceController:ControllerBase
    {
        private ProvinceService ProvinceService;
        public ProvinceController(ProvinceService provinceService)
        {
            this.ProvinceService = provinceService;
        }
        [HttpGet]
        public IActionResult GetProvinces()
        {

            return Ok(ProvinceService.GetProvinces());
        }
    }
}
