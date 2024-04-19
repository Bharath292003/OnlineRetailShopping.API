using Microsoft.AspNetCore.Mvc;
using Moq;
using FakeItEasy;
using OnlineRetailShopping.API.Controllers;
using OnlineRetailShopping.Repository.Entities;
using OnlineRetailShopping.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineRetailShopping.Services.Interface;

namespace OnlineRetailShopping.XUnitTesting
{
    public class CustomerControllerTest
    {
        CustomerController _controller;
        ICustomerService _customerService;
        private readonly Mock<ICustomerService> _CustomerServiceMock = new();
        public CustomerControllerTest()
        {
            _customerService = A.Fake<ICustomerService>();
            _controller = new CustomerController(_customerService);
        }
        //[Fact]
        //public void GetAllTest()
        //{
        //    //act
        //    var result = _controller.Getcustomer();
        //    //assert
        //    Assert.IsType<OkObjectResult>(result.Result as OkObjectResult);
        //}
        [Fact]
        public async void GetAllTest2()
        {
            var data = A.Fake<ICustomerService>();
            var CustomerController = new CustomerController(data);
            var customers = CustomerController.Getcustomer();
            OkObjectResult okresult = customers.Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(okresult);

        }

        public void GetCustomerByIdTest(Guid id)
        {
            var customer = A.Fake<ICustomerService>();
            var Customercontroller = new CustomerController(customer);
            var customers = Customercontroller.GetcustomerbyID(Guid.NewGuid());
            OkObjectResult result = customers.Result as OkObjectResult;
            Assert.IsType<OkObjectResult>(result);

        }
        [Theory]
        [InlineData("vignesh", "8963510275", "vignesh@gmail.com")]
        public async void PostCustomerCheck(string customerName, string mobile, string emailId)
        {
            // Arrange
            Customer customers = new Customer
            {
                customerName = customerName,
                mobile = mobile,
                emailID = emailId
            };

            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(r => r.CreateCustomer(It.IsAny<Customer>()))
              .ReturnsAsync(customers);

            var controller = new CustomerController(mockCustomerService.Object);
            var result = await controller.Postproduct(customers);

            //assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(customers, createdAtActionResult.Value);

        }


        [Theory]
        [InlineData("151d510e-9506-4254-a266-1d5882d2749b")]
        public async Task DeleteCustomer_Check(Guid id)
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(r => r.DeleteCustomer(id)).Returns((Task.CompletedTask));

            var controller = new CustomerController(mockCustomerService.Object);

            // Act
            var result = await controller.DeleteCustomer(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000", "bharath", "8765434567", "balajibharath@gmail.com")]
        public async Task PutCustomer_Check(Guid id, string customerName, string phone, string email)
        {
            // Arrange
            var customerToUpdate = new Customer { customerId = id, customerName = customerName, mobile = phone, emailID = email };

            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(r => r.UpdateCustomer(It.IsAny<Customer>())).Returns(Task.CompletedTask);

            var controller = new CustomerController(mockCustomerService.Object);

            // Act
            var result = await controller.PutCustomerbyId(id, customerToUpdate);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }






    }
}
