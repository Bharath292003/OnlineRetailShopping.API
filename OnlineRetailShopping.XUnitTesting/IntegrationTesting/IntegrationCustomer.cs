using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OnlineRetailShopping.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace OnlineRetailShopping.XUnitTesting.IntegrationTesting
{
    public class IntegrationCustomer: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public IntegrationCustomer(WebApplicationFactory<Program> factory)
        {

            _factory = factory;

        }
        [Theory]
        [InlineData("https://localhost:44361/api/Customer/Getcustomer")]
        [InlineData("https://localhost:44361/api/Product/Getproduct")]
        public async Task IntegrationTestType1(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            var result = response.IsSuccessStatusCode;
            if (result)
                Assert.True(result);
            else
                Assert.False(result);
        }
        [Theory]
        [InlineData("https://localhost:44361/api/Customer/Getcustomer")]
        public async Task IntegrationTestType2(string url)
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync(url);
            var responseContent = await result.Content.ReadAsStringAsync();
            var actualCustomer = JsonConvert.DeserializeObject<List<Customer>>(responseContent);
            Assert.IsType<List<Customer>>(actualCustomer);
            //var result = await client.GetAsync(url);
            //var content = await result.Content.ReadFromJsonAsync<Customer>();
            //Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            //Assert.Equal("test", actualCustomer?.);
      
        }
        [Theory]
        [InlineData("https://localhost:44361/api/Order/Orderproduct")]
        public async void IntegrationTestType3(string url)
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync(url);
            var resContent = await result.Content.ReadAsStringAsync();
            var actualOrder = JsonConvert.DeserializeObject<List<Order>>(resContent);
            Assert.IsType<List<Order>>(actualOrder);
        }




    }
}
