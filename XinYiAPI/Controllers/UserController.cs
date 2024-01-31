using Microsoft.AspNetCore.Mvc;
using XinYiAPI.Eneities;
using XinYiAPI.Services;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private UserService UserService;
        public UserController(UserService userService)
        {
            this.UserService = userService;
        }
        [HttpGet]
        public IActionResult users()
        {
            return Ok(UserService.GetUsers());
        }
        [HttpGet]
        public IActionResult user(string id)
        {
            return Ok(UserService.GetUserById(id));
        }
        [HttpPost]
        public IActionResult createUser(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            user.createTime = System.DateTime.Now;
            user.updateTime = System.DateTime.Now;
            user.id = System.Guid.NewGuid().ToString();
            return Ok(UserService.CreateUser(user));
        }
        [HttpPost]
        public IActionResult updateUser(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            user.updateTime = System.DateTime.Now;
            return Ok(UserService.UpdateUser(user));
        }
        [HttpPost]
        public IActionResult deleteUser(string id)
        {
            return Ok(UserService.DeleteUser(id));
        }
    }
}
