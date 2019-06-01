using AOPenenzaTest.BLL.AbstractEmployeeService;
using AOPenenzaTest.DAL.AbstractRepository;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeServiceGet _employeeServiceGet;
        public HomeController(IEmployeeServiceGet employeeServiceGet)
        {
            _employeeServiceGet = employeeServiceGet;
        }


        public async Task<ActionResult> Details()
        {

            var reader = await _employeeServiceGet.GetAllAsync();

            return View(reader);
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}