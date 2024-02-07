using Microsoft.AspNetCore.Mvc;
using XinYiAPI.Common;
using XinYiAPI.Eneities;
using XinYiAPI.InputDto;
using XinYiAPI.Services;
using XinYiAPI.ReturnDto;
using XinYiAPI.Resources;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private UserService UserService;
        private JwtService JwtService;
        public UserController(UserService userService, JwtService jwtService)
        {
            this.UserService = userService;
            JwtService = jwtService;
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
        [HttpPost]
        public IActionResult login(UserVertifyInfo user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            try
            {
                var userInfo = UserService.GetUserByName(user.username);
                if( userInfo !=null && userInfo.password == user.password)
                {
                    if (!string.IsNullOrEmpty(userInfo.role)) {
                        var jwt = JwtService.GenerateToken(userInfo.role);

                        return Ok(new ReturnModel(){code=200,msg="success",data=jwt });
                    } else
                    {
                        return Ok(new ReturnModel() { code = 200, msg = "false", data = "当前用户没有权限" });
                    }
                }
                else
                {
                     return Ok(new ReturnModel() { code = 200, msg = "false", data = "当前用户不存在" });
                }
            }
            catch
            {
                return Ok(new ReturnModel() { code = 200, msg = "false", data = "当前用户不存在" });
            }   
          
        }
    }
}
