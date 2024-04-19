using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailShopping.Models.ViewModel;
using OnlineRetailShopping.Repository.Interface;
using OnlineRetailShopping.Services.Interface;

namespace OnlineRetailShopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
           
        }
        [HttpGet]
        [Route("Orderproduct")]
        public async Task<IActionResult> Orderproduct()
        {
            var orderproduct = await _orderService.GetAllOrders();
            if (orderproduct == null)
            {
                return NotFound();
            }
            return Ok(orderproduct);

        }
        [HttpGet("OrderProductbyID")]
        public async Task<IActionResult> OrderProductbyID(Guid ID)
        {
            var orderproduct = await _orderService.GetOrderById(ID);
            if (orderproduct == null)
            {
                return NotFound();
            }
            return Ok(orderproduct);
        }
        [HttpPost]
        [Route("Postorder")]
        public async Task<IActionResult> Postorder(OrderViewModel items)
        {
            //Order order =new Order();
            //order.orderId = Guid.NewGuid();
            //order.quantity = items.quantity;
            //order.customerId = items.customerId;
            //order.productId = items.productId;  
            //order.IsCancel = false; 
            var order = await _orderService.CreateOrder(items);
            if (order == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(Orderproduct), new { ID = order.orderId }, order);
        }
        [HttpPut("PutOrderbyId")]
        public async Task<IActionResult> PutOrderbyId(Guid orderId, int quantity)
        {
            var orderproduct = await _orderService.UpdateOrder(orderId, quantity);
            if (!(orderproduct))
            {
                return BadRequest();
            }
            return Ok(orderproduct);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            var orderproduct = await _orderService.DeleteOrder(orderId);
            if (orderproduct == false)
            {
                return NotFound();
            }
            return Ok();

        }

    }
}
