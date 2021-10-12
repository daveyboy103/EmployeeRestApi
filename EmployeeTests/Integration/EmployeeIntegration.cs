using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EmployeeApi.Data;
using EmployeeModels.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;
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

        [Test]
        public async Task ShouldUpdateEmployee()
        {
            Employee personToUpdate;
            var employeeRepository = new EmployeeRepository(configuration: _config);

            Employee ret = await employeeRepository.GetEmployee(1);
            
            Assert.IsNotNull(ret);

            if (ret.FirstName == "Nancy")
            {
                personToUpdate = ret with
                {
                    FirstName = "Norman"
                };
            }
            else
            {
                personToUpdate = ret with
                {
                    FirstName = "Nancy"
                };
            }

            ret = await employeeRepository.UpdateEmployee(personToUpdate);
            
            Assert.IsNotNull(ret);
        }
    }

    [TestFixture]
    public class ApiIntegration
    {
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/"),
            };
        }

        [Test]
        public async Task ShouldGetListOfEmployees()
        {
            var ret = await _client.GetFromJsonAsync<IEnumerable<Employee>>("api/Employee");
            
            Assert.IsTrue(ret?.Any());
        } 
        
        [Test]
        public async Task ShouldGetSpecificEmployees()
        {
            var ret = await _client.GetFromJsonAsync<Employee>("api/Employee/1");
            
            Assert.IsNotNull(ret?.FirstName);
        }
    }
}