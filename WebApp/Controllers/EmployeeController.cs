using AOPenenzaTest.BLL.AbstractEmployeeService;
using AOPenenzaTest.BLL.AbstractEmployeeService.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceGet _employeeServiceGet;
        private readonly IEmployeeServiceCUD _employeeServiceCUD;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeServiceGet employeeServiceGet,
            IEmployeeServiceCUD employeeServiceCUD,
            IMapper mapper)
        {
            _employeeServiceGet = employeeServiceGet;
            _employeeServiceCUD = employeeServiceCUD;
            _mapper = mapper;
        }
        // GET: index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee
        public async Task<ActionResult> List()
        {
            var employeeDTO = await _employeeServiceGet.GetAllAsync();

            return View(_mapper.Map<IEnumerable<EmployeeDTO>, IEnumerable<EmployeeViewModel>>(employeeDTO));
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var employeeDTO = await _employeeServiceGet.GetByIdAsync(id);
            return PartialView(_mapper.Map<EmployeeDTO, EmployeeViewModel>(employeeDTO));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            var newEmployee = new EmployeeViewModel();

            return PartialView(newEmployee);
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Patronymic,Age")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var employeeDTO = _mapper.Map<EmployeeViewModel, EmployeeDTO>(employee);
                await _employeeServiceCUD.AddAsync(employeeDTO);

                return PartialView("Success");
            }

            return PartialView(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
