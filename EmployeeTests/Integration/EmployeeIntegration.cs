using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.Data;
using EmployeeModels.Dtos;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace EmployeeTests.Integration
{
    [TestFixture]
    public class EmployeeIntegration
    {
        private IConfiguration _config;
        
        [SetUp]
        public void SetUp()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            _config = builder.Build();
        }
        [Test]
        public async Task ShouldReturnListOfEmployees()
        {
            var employeeRepository = new EmployeeRepository(configuration: _config);

            var ret = await employeeRepository.GetEmployees();
            
            Assert.IsTrue(ret.Any());
        }

        [Test]
        public async Task ShouldReturnSpecificEmployee()
        {
            var employeeRepository = new EmployeeRepository(configuration: _config);

            var ret = await employeeRepository.GetEmployee(1);
            
            Assert.IsNotNull(ret);
        }
    }
}