using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailShopping.API.Filters;
using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository.Interface;
using OnlineRetailShopping.Services.Interface;

namespace OnlineRetailShopping.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizationFilter))]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
           _customerService = customerService;
        }

        [HttpGet]
        [Route("Getcustomer")]

        public async Task<IActionResult> Getcustomer()
        {
            var proget = await _customerService.GetCustomerAll();
            if (proget == null)
            {
                return NotFound();
            }
            return Ok(proget);

        }
        [HttpGet("GetcustomerbyID")]
        public async Task<IActionResult> GetcustomerbyID(Guid ID)
        {

            var products = await _customerService.GetCustomerById(ID);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("GetcustomerbyName/{Name}")]
        public async Task<IActionResult> GetcustomerbyName(string Name)
        {

            var products = await _customerService.GetCustomerByName(Name);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Postproduct(Customer pro)
        {
            var customerpost = await _customerService.CreateCustomer(pro);
            return CreatedAtAction(nameof(GetcustomerbyID), new { ID = pro.customerId }, pro);
        }
        [HttpPut("PutCustomerbyId")]
        public async Task<IActionResult> PutCustomerbyId(Guid customerId, Customer pro)
        {
            if (customerId != pro.customerId)
            {
                return BadRequest();
            }
            await _customerService.UpdateCustomer(pro);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _customerService.DeleteCustomer(id);
            return NoContent();


        }


    }
}
