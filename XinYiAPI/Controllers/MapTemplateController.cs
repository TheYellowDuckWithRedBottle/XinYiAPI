using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XinYiAPI.Eneities;
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
        [Authorize(Policy = "admin")]
        public IActionResult mapTemplates()
        {
            return Ok(MapTemplateService.GetMaptemplates());
        }

        [HttpPost]
        public IActionResult deleleMapTemplate(string id)
        {
            return Ok(MapTemplateService.DeleteMapTemplate(id));
        }
        [HttpPost]
        public IActionResult createMapTemplate(MapTemplate mapTemplate)
        {
            if(mapTemplate == null)
            {
                return BadRequest();
            }
            mapTemplate.createTime = System.DateTime.Now;
            mapTemplate.updateTime = System.DateTime.Now;
            mapTemplate.id = System.Guid.NewGuid().ToString();
            return Ok(MapTemplateService.CreateMapTemplate(mapTemplate));
        }
    }
}
