using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using XinYiAPI.Resources;
using XinYiAPI.Services;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
  //  [Authorize]
    public class DistrictController: ControllerBase
    {
        private DistrictService DistrictService;
        public DistrictController(DistrictService districtService)
        {
            this.DistrictService = districtService;
        }
        /// <summary>
        /// 获取地区列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult districts()
        {
            var result = new ReturnModel() { Code = 200, Msg = "success", Data = DistrictService.GetDistricts() };
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = new ReturnModel() { Code = 200, Msg = "success", Data = DistrictService.GetDistricts() };
            return Ok(result);
        }
    }
}
