using AOPenenzaTest.BLL.AbstractEmployeeService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPenenzaTest.BLL.AbstractEmployeeService
{
    public interface IEmployeeCRUDService : IEmployeeGetService
    {
        Task<EmployeeDTO> AddAsync(EmployeeDTO employeeDTO);
        Task<EmployeeDTO> UpdateAsync(EmployeeDTO employeeDTO);
        Task<EmployeeDTO> DeleteAsync(int employeeId);
    }
}
