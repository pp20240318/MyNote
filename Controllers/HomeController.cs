using Microsoft.AspNetCore.Mvc;
using MyNote.Model;
using MyNote.Models;
using System.Diagnostics;

namespace MyNote.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var types = GetAllSubclasses(typeof(ModelBase));
            ////建库
            //SqlSugarHelper.Db.DbMaintenance.CreateDatabase();//达梦和Oracle不支持建库
            ////建表 （看文档迁移）
            //SqlSugarHelper.Db.CodeFirst.InitTables(GetAllSubclasses(typeof(ModelBase))); //所有库都支持


            //var diffString = SqlSugarHelper.Db.CodeFirst.GetDifferenceTables(types).ToDiffString();
            SqlSugarHelper.Db.CodeFirst.InitTables(types);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public static Type[] GetAllSubclasses(Type baseType)
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.IsSubclassOf(baseType)).ToArray();

            return allTypes;
        }

    }
}
