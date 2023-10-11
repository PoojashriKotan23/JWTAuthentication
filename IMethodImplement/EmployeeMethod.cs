using TokenAuth.Interface;
using TokenAuth.Models;

namespace TokenAuth.IMethodImplement
{
    public class EmployeeMethod : IEmployee
    {
        
        public List<Employee> getEmployee()
        {
            List<Employee> list = new List<Employee>()
            {
                new Employee{ID=100,Username="Poojashri",Address="Bangalore",Code="A100"},
                new Employee{ID=101,Username="Pooja",Address="Udupi",Code="A101"},
                new Employee{ID=102,Username="Shri",Address="Hasan",Code="A102"},
                new Employee{ID=103,Username="Poo",Address="Delhi",Code="A103"},
                new Employee{ID=104,Username="Poojashri",Address="Mumbai",Code="A104"},
            };
            return list;
        }
    }
}
