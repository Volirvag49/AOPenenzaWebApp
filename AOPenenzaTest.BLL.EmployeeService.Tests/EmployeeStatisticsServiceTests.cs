using AOPenenzaTest.BLL.AbstractEmployeeService;
using AOPenenzaTest.DAL.AbstractRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;
using System.Threading.Tasks;

namespace AOPenenzaTest.BLL.EmployeeService.Tests
{
    [TestClass]
    public class EmployeeStatisticsServiceTests
    {
        Mock<IUnitOfWork> mock;

        public EmployeeStatisticsServiceTests()
        {
            mock = new Mock<IUnitOfWork>();
        }



        [TestMethod]
        public async Task GetCountAsync_Returns_5Async()
        {

            mock.Setup(m => m.Employees.CountAsync(e => e.Id >= 0)).Returns(Task.FromResult(5));

            var target = new EmployeeStatisticsService(mock.Object);

            var result = await target.GetCountAsync();

            mock.Verify(l => l.Employees.CountAsync(d => d.Id >= 0));
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public async Task GetAverageAgeAsync_returns_43()
        {

            mock.Setup(m => m.Employees.AverageAsync(e => e.Age)).Returns(Task.FromResult<decimal>(43));

            var target = new EmployeeStatisticsService(mock.Object);

            var result = await target.GetAverageAgeAsync();
            // проверка вызова метода
            mock.Verify(l => l.Employees.AverageAsync(e => e.Age));
            Assert.AreEqual(result, 43);
        }

    }
}
