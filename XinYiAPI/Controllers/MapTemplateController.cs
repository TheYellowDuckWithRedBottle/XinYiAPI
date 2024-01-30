using Microsoft.AspNetCore.Mvc;
using XinYiAPI.Services;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MapTemplateController : Controller
    {
        private MapTemplateService MapTemplateService;
        public MapTemplateController(MapTemplateService mapTemplateService)
        {
            this.MapTemplateService = mapTemplateService;
        }
        [HttpGet]
        public IActionResult mapTemplates()
        {
            return Ok(MapTemplateService.GetMaptemplates());
        }
    }
}
