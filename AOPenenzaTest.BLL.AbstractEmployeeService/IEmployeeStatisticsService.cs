using System.Threading.Tasks;

namespace AOPenenzaTest.BLL.AbstractEmployeeService
{
    public interface IEmployeeStatisticsService
    {
        Task<int> GetCountAsync();
        Task<decimal> GetAverageAgeAsync();
    }
}
