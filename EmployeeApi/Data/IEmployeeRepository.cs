using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModels.Dtos;

namespace EmployeeApi.Data
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
    }
}