using AOPenenzaTest.BLL.AbstractEmployeeService;
using AOPenenzaTest.BLL.AbstractEmployeeService.DTO;
using AOPenenzaTest.DAL.AbstractRepository;
using AOPenenzaTest.DAL.EF.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOPenenzaTest.BLL.EmployeeService
{
    public class EmployeeService : IEmployeeServiceGet, IEmployeeServiceCUD, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var dbEmployees = await _unitOfWork.Employees.GetAllAsync();

            return _mapper.Map<IEnumerable<DbEmployee>, IEnumerable<EmployeeDTO>>(dbEmployees);
        }

        public async Task<EmployeeDTO> GetByIdAsync(int id)
        {

            var dbEmployee = await _unitOfWork.Employees.GetByIdAsynс(id);
            return _mapper.Map<DbEmployee, EmployeeDTO>(dbEmployee);
        }

        public async Task<EmployeeDTO> AddAsync(EmployeeDTO employeeDTO)
        {
            if (employeeDTO != null)
            {
                var dbEmployee = _mapper.Map<EmployeeDTO, DbEmployee>(employeeDTO);

                _unitOfWork.Employees.Create(dbEmployee);

                await _unitOfWork.CommitAsync();

                return employeeDTO;
            }

            return null;
        }

        public async Task<EmployeeDTO> UpdateAsync(EmployeeDTO employeeDTO)
        {
            if (employeeDTO != null)
            {
                var dbEmployee = _mapper.Map<EmployeeDTO, DbEmployee>(employeeDTO);

                _unitOfWork.Employees.Update(dbEmployee);

                await _unitOfWork.CommitAsync();

                return employeeDTO;
            }

            return null;
        }

        public async Task<EmployeeDTO> DeleteAsync(int employeeId)
        {
            var dbEmployee = await _unitOfWork.Employees.GetByIdAsynс(employeeId);
            if (dbEmployee != null)
            {

                _unitOfWork.Employees.Delete(dbEmployee);

                await _unitOfWork.CommitAsync();

                return _mapper.Map<DbEmployee, EmployeeDTO>(dbEmployee);
            }

            return null;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
