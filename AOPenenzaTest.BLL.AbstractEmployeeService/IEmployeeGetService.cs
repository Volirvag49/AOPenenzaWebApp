﻿using AOPenenzaTest.BLL.AbstractEmployeeService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AOPenenzaTest.BLL.AbstractEmployeeService
{
    public interface IEmployeeGetService
    {
        Task<EmployeeDTO> GetByIdAsync(int id);
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
    }
}
