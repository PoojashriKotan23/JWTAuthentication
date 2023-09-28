
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
            var result= Employee.GetEmployee();
            Log.Information("Get Employee Details =>{@Result}", result);
            return result;
        }
        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            string data = null;
            try
            {
                data= "Authenticated with JWT details";
            }
            catch {
                Log.Error("Error in authentication");
            }
            return data;
         
        }

        [Authorize]
        [HttpPost]
        [Route("AddUser")]
        public string AddUser(Users user)
        {
            Log.Information("User added with Username " + user.Username);
            return "User added with Username " + user.Username;
        }

        [HttpPost]
        [Route("CheckError")]
        public void division()
        {
            try
            {
                int n = 10;
                int result = n / 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An Error Occured");
            }
        }
       
    }
}