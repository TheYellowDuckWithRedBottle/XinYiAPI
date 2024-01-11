using Microsoft.AspNetCore.Mvc;
using XinYiAPI.Common;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TokenController : ControllerBase
    {
        private readonly JwtService _jwtService;
        public TokenController(JwtService jwtService)
        {
            this._jwtService = jwtService;
        }
        [HttpGet]
        public IActionResult token([FromQuery] string userId)
        {
           var token =  _jwtService.GenerateToken(userId);
           return Ok(token);
        }
    }
}
