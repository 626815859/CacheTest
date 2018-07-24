using CacheTest.BLL;
using CacheTest.Common;
using CacheTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheTest.Controllers
{
    public class HomeController : Controller
    {
        Person p = new Person();
        PersonBll personBll = new PersonBll();
        CacheHelper cacheHelper = new CacheHelper();
        public ActionResult Index()
        {
            personBll.AddPerson("张三" + DateTime.Now);

            return View();
        }

        [HttpGet]
        public ActionResult GetPersonById(int personId)
        {
            if(cacheHelper.Exist(personId.ToString()))     //缓存中有，就不必去数据库服务器查找
            {
                p = cacheHelper.Retrieve<Person>(personId.ToString());
            }
            else                                          //缓存中没有，就去查找
            {
                p = personBll.GetPersonById(personId);
                cacheHelper.Add(p.Id.ToString(), p);
            
            }
            
            if (p != null)
            {
                return Content("ok");

            }
            else
            {
                return Content("no");
            }
            
        }
    }
}