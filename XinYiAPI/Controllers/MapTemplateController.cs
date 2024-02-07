using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XinYiAPI.Eneities;
using XinYiAPI.Resources;
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
            var result = new ReturnModel() { code = 200, msg = "success", data = MapTemplateService.GetMaptemplates() };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult deleleMapTemplate(string id)
        {
            var result = new ReturnModel() { code = 200, msg = "success", data = MapTemplateService.DeleteMapTemplate(id) };
            return Ok(result);
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
            var result = new ReturnModel() { code = 200, msg = "success", data = MapTemplateService.CreateMapTemplate(mapTemplate) };
            return Ok(result);
        }
    }
}
