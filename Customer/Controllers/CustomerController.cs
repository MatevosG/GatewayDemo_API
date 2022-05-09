using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private List<Customer> customerList { get; set; }
        public CustomerController()
        {
            customerList = new List<Customer>() {
                              new Customer(){ Id=1,Name="hako",Surname="test" },
                              new Customer(){ Id=2,Name="hako1",Surname="test1"},
                              new Customer(){ Id=3,Name="hako2",Surname="test2"},
                              new Customer(){ Id=4,Name="hako3",Surname="test3"}
            };
        }

        [HttpGet("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            return Ok(customerList);
        }


        [HttpGet("GetCustomerById/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var res = customerList.FirstOrDefault(x => x.Id == id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost("CreateCustumer")]
        public IActionResult CreateCustumer([FromBody] Customer customer)
        {
            customerList.Add(customer);
            return Ok(customerList);
        }

        [HttpPut("UpdateCustumer")]
        public IActionResult UpdateCustumer([FromBody] Customer customer)
        {
            var customerForUpdate = customerList.FirstOrDefault(x => x.Id == customer.Id);
            if (customerForUpdate == null)
                return BadRequest();
            int custIndex = customerList.IndexOf(customerForUpdate);
            customerList[custIndex] = customer;
            return Ok(customerList);
        }

        [HttpDelete("DeleteCustumer/{id}")]
        public IActionResult DeleteCustumer(int id)
        {
            var customer = customerList.FirstOrDefault(x => x.Id == id);
            if (customer == null)
                return NotFound();
            customerList.Remove(customer);
            return Ok(customerList);
        }

    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
