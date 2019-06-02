using AOPenenzaTest.BLL.AbstractEmployeeService;
using AOPenenzaTest.BLL.AbstractEmployeeService.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeCRUDService _employeeServiceCRUD;
        private readonly IMapper _mapper;

        public EmployeeController(
            IEmployeeCRUDService employeeServiceCRUD,
            IMapper mapper)
        {
            _employeeServiceCRUD = employeeServiceCRUD;
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
            var employeeDTO = await _employeeServiceCRUD.GetAllAsync();

            return View(_mapper.Map<IEnumerable<EmployeeDTO>, IEnumerable<EmployeeViewModel>>(employeeDTO));
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var employeeDTO = await _employeeServiceCRUD.GetByIdAsync(id);
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Patronymic,Age")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var employeeDTO = _mapper.Map<EmployeeViewModel, EmployeeDTO>(employee);
                var result = await _employeeServiceCRUD.AddAsync(employeeDTO);

                if (result != null)
                {
                    return PartialView("Success");
                }
            }

            return PartialView(employee);
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var employeeDTO = await _employeeServiceCRUD.GetByIdAsync(id);

            if (employeeDTO != null)
            {
                return PartialView(_mapper.Map<EmployeeDTO, EmployeeViewModel>(employeeDTO));
            }

            return PartialView(employeeDTO);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Patronymic,Age")] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var employeeDTO = _mapper.Map<EmployeeViewModel, EmployeeDTO>(employee);
                _employeeServiceCRUD.UpdateAsync(employeeDTO);

                return PartialView("Success");
            }

            return PartialView(employee);
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var employeeDTO = await _employeeServiceCRUD.GetByIdAsync(id);

            if (employeeDTO != null)
            {
                return PartialView("Delete", _mapper.Map<EmployeeDTO, EmployeeViewModel>(employeeDTO));
            }

            return PartialView(_mapper.Map<EmployeeDTO, EmployeeViewModel>(employeeDTO));
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var employeeDTO = await _employeeServiceCRUD.DeleteAsync(id);

            if (employeeDTO != null)
            {
                return PartialView("Success");
            }

            return PartialView();
        }
    }
}
