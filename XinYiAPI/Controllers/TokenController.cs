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
            _jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult token([FromQuery] string role)
        {
            return Ok(generateToken(role));
        }


        private string generateToken(string role)
        {
            return _jwtService.GenerateToken(role);
        }
    }
}
