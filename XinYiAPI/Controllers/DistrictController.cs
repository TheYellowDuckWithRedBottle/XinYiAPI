using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XinYiAPI.Services;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class DistrictController: ControllerBase
    {
        private DistrictService DistrictService;
        public DistrictController(DistrictService districtService)
        {
            this.DistrictService = districtService;
        }
        [HttpGet]
        public IActionResult GetDistricts()
        {
            return Ok(DistrictService.GetDistricts());
        }
    }
}
