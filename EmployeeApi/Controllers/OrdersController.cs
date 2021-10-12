using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeApi.Data;
using EmployeeModels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderRepository _orderRepository;

        public OrdersController(ILogger<OrdersController> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            try
            {
                return Ok( await _orderRepository.GetOrders());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data from the database. Details: {e.Message}");
            }
        }

        [HttpGet("{customerId:int}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersForCustomer(int customerId)
        {
            try
            {
                return Ok( await _orderRepository.GetOrdersForCustomer(customerId));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data from the database. Details: {e.Message}");
            }
        }  
        
        [HttpGet("{customerId:int}/Details")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailsForCustomer(int customerId)
        {
            try
            {
                return Ok( await _orderRepository.GetOrderDetailsForCustomer(customerId));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data from the database. Details: {e.Message}");
            }
        } 
        
        [HttpGet("Employee/{employeeId:int}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersForEmployee(int employeeId)
        {
            try
            {
                return Ok( await _orderRepository.GetOrdersForEmployee(employeeId));;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data from the database. Details: {e.Message}");
            }
        } 
        
        [HttpGet("Employee/{employeeId:int}/Details")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailsForEmployee(int employeeId)
        {
            try
            {
                return Ok( await _orderRepository.GetOrderDetailsForEmployee(employeeId));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving data from the database. Details: {e.Message}");
            }
        }
    }
}