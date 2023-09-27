using System.Runtime.Serialization;

namespace TokenAuth.Models
{
    public class Employee
    {
        [DataMember(EmitDefaultValue = false, Name = "ID", Order = 0)]
        public int ID { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Username", Order = 1)]
        public string Username { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Address", Order = 2)]
        public string Address { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Code", Order = 3)]
        public string Code { get; set; }
        internal static List<Employee> GetEmployee()
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
