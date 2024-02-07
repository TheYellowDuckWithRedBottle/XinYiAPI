using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinYiAPI.Models;
using XinYiAPI.Resources;
using XinYiAPI.Services;

namespace XinYiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LandSpaceController:ControllerBase
    {
        private LandSpaceService _LandSpaceService;
        private List<LandSpace> landSpaces;
        public LandSpaceController(LandSpaceService landSpaceService)
        {
            this._LandSpaceService = landSpaceService;
            this.landSpaces = _LandSpaceService.GetAll();
        }

        [HttpGet]
        private List<PowerType> getQSXZList()
        {
            var QSXZCodeList = landSpaces.GroupBy(x => x.QSXZ).Select(x => x.Key).ToList();
            var powerTypeList = new List<PowerType>() { };

            foreach (var item in QSXZCodeList)
            {
                switch (item)
                {
                    case "10":
                        powerTypeList.Add(new PowerType() { Code = item, Name = "国有土地所有权" });
                        
                        break;
                    case "20":
                        powerTypeList.Add(new PowerType() { Code = item, Name = "国有土地使用权" });
                        break;
                    case "30":
                        powerTypeList.Add(new PowerType() { Code = item, Name = "集体土地所有权" });
                      
                        break;
                    case "40":
                        powerTypeList.Add(new PowerType() { Code = item, Name = "集体土地使用权" });
                        break;
                    default:
                        break;
                }
            }
            return powerTypeList;
        }

        /// <summary>
        /// 根据权属性质查询总的面积
        /// </summary>
        /// <returns>整个地区的权属性质的总面积</returns>
        [HttpGet]
        public ActionResult getStaticByQSXZ([FromQuery] string village)
        {
            if (!string.IsNullOrEmpty(village))
            {
                landSpaces = landSpaces.FindAll(item => item.QSDWMC == village);
            }
            var res = landSpaces.GroupBy(x => x.QSXZ).Select(x => new cateArea { cateCode = x.Key, area = x.Sum(t => t.SHAPE_Area) }).ToList();
            var powerTypeList= getQSXZList();//获取行政区名称和代码映射
            var totalSums = landSpaces.Sum(item => item.SHAPE_Area);
            foreach (var item in res)
            {
                item.cateName = powerTypeList.Find(x => x.Code == item.cateCode).Name;
                item.percent = item.area / totalSums*100;
            }
            
            return Ok(res);
        }
        [HttpGet]
        public ActionResult getXZQ()
        {
            var res = landSpaces.GroupBy(x => x.ZLDWMC).Select(x => x.Key).ToList();
            return Ok(res);
        }
        /// <summary>
        /// 获取整个区域的二级分类统计数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult getWholeStatic([FromQuery] string village)
        {
            if (!string.IsNullOrEmpty(village))
            {
                landSpaces = landSpaces.FindAll(item => item.QSDWMC == village);
            }
            SecCateService secCateService = new SecCateService();
            var res = landSpaces.GroupBy(x => new { x.ZRZYFLMC,x.ZRZYFLBM}).Select(x => new cateArea 
            { 
                cateName = x.Key.ZRZYFLMC, 
                area = x.Sum(t => t.SHAPE_Area),
                cateCode=x.Key.ZRZYFLBM,
                
            }).ToList();
            
            var res1 = res.GroupBy(x => x.cateCode.Substring(0, 4)).ToList();//29类分成12类
             // var res3 = res.GroupBy(x => x.cateCode.Substring(0, 4)).Select(item =>new {item.Key,item.ToList() }).ToList() ;//29类分成12类
            List<SecCateDto> secCateDtosList = new List<SecCateDto>();
            foreach (var item in res1)//遍历12个二级类
            {
                SecCateDto secCateDto = new SecCateDto();
                secCateDto.secLevelCode = item.Key;
              
                var key = item.Key;
                var areas= item.Sum(item => item.area);//某类的总面积
                var res2= item.Select(x => new { x.cateCode, x.cateName, areas }).ToList();
                
            }
            return Ok(res1);
        }
        
        /// <summary>
        /// 根据权属代码获取图斑分类
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult getStaticDataByQSXZ([FromQuery] string code)
        {
            var codeList = landSpaces.GroupBy(x => x.QSXZ).ToList();
            List<StaticXZQResult> staticXZQResultList = new List<StaticXZQResult>();
            foreach (var item in codeList)
            {
                StaticXZQResult staticXZQResults = new StaticXZQResult();
                var totalArea = item.Sum(x => x.SHAPE_Area);
                var res = item.GroupBy(x => x.ZRZYFLMC).Select(x => new cateArea
                {
                    cateName = x.Key,
                    area = x.Sum(t => t.SHAPE_Area),
                    percent = x.Sum(t => t.SHAPE_Area) / totalArea
                }).ToList();
                staticXZQResults.XZQMC = item.Key;

                staticXZQResults.cateArea = res;
                staticXZQResultList.Add(staticXZQResults);
            }
            var result = staticXZQResultList.Find(item => item.XZQMC == code);
            return Ok(result);
        }
        /// <summary>
        /// 根据村庄名获取分类数据
        /// </summary>
        /// <param name="village"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult getStaticFromLoaction([FromQuery] string village)
        {
            if (!string.IsNullOrEmpty(village))
            {
                landSpaces = landSpaces.FindAll(item => item.QSDWMC == village);
            }   
            var xzqList = landSpaces.GroupBy(x => x.QSDWMC).ToList();//按照权属单位名称分为村子一类的列表
            List<StaticXZQResult> list = new List<StaticXZQResult>();
            foreach (var item in xzqList)
            {
                StaticXZQResult staticXZQResult = new StaticXZQResult();
                var totalArea = item.Sum(x => x.SHAPE_Area);//求村子的总面积
                var res = item.GroupBy(x => x.ZRZYFLMC).Select(x =>
                 new cateArea
                 {
                     cateName = x.Key,
                     area = x.Sum(t => t.SHAPE_Area),
                     percent = x.Sum(t => t.SHAPE_Area) / totalArea * 100
                 }).ToList();
                staticXZQResult.XZQMC = item.Key;

                staticXZQResult.cateArea = res;
                list.Add(staticXZQResult);
            }
            var result = list.Find(item => item.XZQMC == village);

            return Ok(result);
        }
        //获取二级分类数据
        [HttpGet]
        public ActionResult getSecCate([FromQuery] string village)
        {
            List<LandSpaceDto> LandSpaceDtoList = new List<LandSpaceDto>();
            SecCateService secCateService = new SecCateService();

            if (!string.IsNullOrEmpty(village))
            {
                landSpaces = landSpaces.FindAll(item => item.QSDWMC == village);
            }
            foreach (var item in landSpaces)//根据二级分类代码将图斑分开
            {
                var code = item.ZRZYFLBM.Substring(0, 4);
                var secCate = secCateService.GetNameByCode(code.Trim());//获取二级类名称
                LandSpaceDto landSpaceDto = new LandSpaceDto() { landSpace = item, code = code, name = secCate.name,Area=item.SHAPE_Area };
                LandSpaceDtoList.Add(landSpaceDto);//
            }
           var thirdLevelCate= landSpaces.GroupBy(item => new { item.ZRZYFLMC, item.ZRZYFLBM }).Select(x => new LandSpaceDto
            {
                code = x.Key.ZRZYFLBM,
                name = x.Key.ZRZYFLMC,
                Area = x.Sum(t => t.SHAPE_Area)
            }).ToList();//根据三级分类代码将图斑分开
            var secLevelCate = LandSpaceDtoList.GroupBy(x => new { x.name, x.code }).Select(x => new LandSpaceDto
            {
                code = x.Key.code,
                name = x.Key.name,
                Area = x.Sum(t => t.landSpace.SHAPE_Area),
            }).ToList();//根据二级类分组获取到代码，名字，总和
           
            return Ok(secLevelCate);
        }
        /// <summary>
        /// 根据标识码,获取图斑位置
        /// </summary>
        /// <param name="BSM"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult getLocationByBSM(string BSM)
        {
            if (string.IsNullOrEmpty(BSM))
            {
                return Ok(new ReturnModel() { code = 404, msg = "请输入正确参数", data = null });
            }
            var Shape = landSpaces.Find(item => item.BSM == BSM);
            if (Shape == null)
                return NotFound(new ReturnModel() { code = 404, msg = "未查询到此条信息", data = null });
            return Ok(new ReturnModel() { code = 200, msg = "获取成功", data = new { Shape.longitude, Shape.latitude } });

        }
    }
}
