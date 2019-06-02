using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AOPenenzaTest.BLL.AbstractEmployeeService;
using AOPenenzaTest.BLL.AbstractEmployeeService.DTO;
using AOPenenzaTest.DAL.AbstractRepository;
using AOPenenzaTest.DAL.EF.Entities;

namespace AOPenenzaTest.BLL.EmployeeService
{
    public class EmployeeStatisticsService : IEmployeeStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeStatisticsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<decimal> GetAverageAgeAsync()
        {
           return await _unitOfWork.Employees.AverageAsync(d => d.Age);
        }

        public async Task<int> GetCountAsync()
        {
            return await _unitOfWork.Employees.CountAsync(d => d.Id >=0);
        }
    }

}
