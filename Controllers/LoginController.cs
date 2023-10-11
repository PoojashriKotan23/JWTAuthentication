
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using TokenAuth.Interface;
using TokenAuth.Models;

namespace JWT_TokenBased_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _IEmployee;
        public EmployeeController(IEmployee emp)
        {
            _IEmployee = emp;
        }

        //public EmployeeController()
        //{

        //}

        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public IList<Employee> GetData()
        {
           // private _IEmployee =new IEmployee(); 
            var result = _IEmployee.getEmployee();
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
                data = "Authenticated with JWT details";
            }
            catch
            {
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

        [HttpGet]
        [Route("CheckError")]
        public int division()
        {
            int result = 0;
            try
            {
                int n = 10;
                result = n / 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An Error Occured");
            }
            return result;
        }

    }
}