using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModels.Dtos;

namespace EmployeeApi.Data
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersForCustomer(int customerId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailsForCustomer(int customerId);
        Task<IEnumerable<Order>> GetOrdersForEmployee(int employeeId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailsForEmployee(int employeeId);
    }
}