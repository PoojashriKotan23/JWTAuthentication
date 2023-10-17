
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
        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public IList<Employee> GetData()
        {
            var result = _IEmployee.getEmployee();
            Log.Information("Get Employee Details =>{@Result}", result);
            return result;
        }

        [Authorize]
        [HttpGet]
        [Route("GetData/id")]
        public Employee GetEmployee(int id)
        {
            //Employee employee = new Employee();
            //try
            //{
               var result = _IEmployee.getEmployee().Find(x => x.ID == id);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
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
        [HttpGet]
        [Route("AddUser")]
        public string AddUser(Users user)
        {
            Log.Information("User added with Username " + user.username);
            return "User added with Username " + user.username;
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