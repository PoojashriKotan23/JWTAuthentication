
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenAuth.Models;

namespace JWT_TokenBased_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public List<Employee> GetData()
        {
                return Employee.GetEmployee();
        }



        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            return "Authenticated with JWT details";
        }



        [Authorize]
        [HttpPost]
        [Route("AddUser")]
        public string AddUser(Users user)
        {
            return "User added with Username " + user.Username;
        }
    }
}