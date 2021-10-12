using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeModels.Dtos;

namespace EmployeeApi.Data
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrdersForCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsForCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrdersForEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsForEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}