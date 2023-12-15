using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
            return Ok(DistrictService.GetDistricts());
        }
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
