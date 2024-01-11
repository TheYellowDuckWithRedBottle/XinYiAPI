﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using XinYiAPI.Services;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CityController : ControllerBase
    {
        private CityService CityService;
        public CityController(CityService cityService)
        {
            this.CityService = cityService;
        }
        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="pageIndex"> 页码</param>
        /// <param name="pageSize">每页多少个</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCities([FromQuery] int pageIndex = 0,int pageSize=10)
        {
            return Ok(CityService.GetCities());
        }
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = 10)]
        [Authorize]
        public IActionResult reandom()
        {
            Random random = new Random();
            int a = random.Next(1, 1000);
            return Ok(a);
        }
    }
}
