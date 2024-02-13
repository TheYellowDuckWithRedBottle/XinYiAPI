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
            var result = new ReturnModel() { code = 200,msg="success",data=UserService.GetUsers() };
            return Ok(result);
        }
        [HttpGet]
        public IActionResult user(string id)
        {
            var result = new ReturnModel() { code = 200, msg="success",data= UserService.GetUserById(id) };
            return Ok(result);
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
            var result = new ReturnModel() {code = 200,msg="success",data = UserService.CreateUser(user) };
            return Ok(result);
        }
        [HttpPost]
        public IActionResult updateUserAvatar(User user)
        {
            // 更新用户的头像信息
            if (user == null)
            { return BadRequest(); }
            if(!string.IsNullOrEmpty(user.id))
            {
                var findedUser = UserService.GetUserById(user.id);
                if (findedUser == null)
                {
                    if (!string.IsNullOrEmpty(user.username))
                    {
                        findedUser = UserService.GetUserByName(user.username);
                        if (findedUser == null)
                        {
                            return Ok(new ReturnModel() { code = 200, msg = "false", data = "未获取到用户信息" });
                        }
                    }
                }
                if (user.avatar != null)
                {
                    findedUser.avatar = user.avatar;
                }
                else
                {
                    return Ok(new ReturnModel() { code = 200, msg = "false", data = "未获取到上传的头像" });
                }
                UserService.UpdateUser(findedUser);
                var result = new ReturnModel() { code = 200, msg = "true", data = findedUser };
                return Ok(result);
            }
            return Ok(new ReturnModel() { code = 200, msg = "false", data = "未获取到用户信息" });

        }

        [HttpPost]
        public IActionResult updateUser(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            user.updateTime = System.DateTime.Now;
            var result = new ReturnModel() { code =200,msg="success",data = UserService.UpdateUser(user) };
            return Ok(result);
        }
        [HttpPost]
        public IActionResult deleteUser(string id)
        {
            var result = new ReturnModel() { code = 200, msg = "success", data = UserService.DeleteUser(id) };
            return Ok(result);
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
