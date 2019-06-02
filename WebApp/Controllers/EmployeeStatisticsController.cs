using AOPenenzaTest.BLL.AbstractEmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeStatisticsController : Controller
    {
        private readonly IEmployeeStatisticsService  _employeeStatisticsService;

        public EmployeeStatisticsController(
            IEmployeeStatisticsService employeeStatisticsService)
        {
            _employeeStatisticsService = employeeStatisticsService;

        }

        // GET: EmployeeStatistics
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetStatistic(int type)
        {
            EmployeeStatisticType employeeStatisticType = (EmployeeStatisticType)type;

            if (employeeStatisticType == EmployeeStatisticType.AverageAge)
            {
                var result = await _employeeStatisticsService.GetAverageAgeAsync();
                return Json(String.Format("Средний возраст сотрудников: {0:f}", result),  JsonRequestBehavior.AllowGet);
            }
            else if(employeeStatisticType == EmployeeStatisticType.EmployeeCount)
            {
                var result = await _employeeStatisticsService.GetCountAsync();
                return Json($"Кол-во сотрудников: {result}", JsonRequestBehavior.AllowGet);
            }

            return Json("Error", JsonRequestBehavior.AllowGet);
        }
    }
}