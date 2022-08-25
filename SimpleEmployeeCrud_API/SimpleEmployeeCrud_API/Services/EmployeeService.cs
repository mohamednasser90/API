using SimpleEmployeeCrud_API.Models;

namespace SimpleEmployeeCrud_API.Services
{
    public class EmployeeService
    {
        static List<Employee> employeeList { get; }
        static int nextEmp = 3;
        static EmployeeService()
        {
            employeeList = new List<Employee>
            {
                new Employee{Id=1,Name="Mohamed",Title="Developer",Salary=3000},
                new Employee{Id=2,Name="Nasser",Title="Engineer",Salary=4000}
            };
        }

        public static List<Employee> GetAll() => employeeList;
        public static Employee Get(int Id) => employeeList.FirstOrDefault(w => w.Id == Id);
        public static void Add(Employee emp)
        {
            emp.Id= nextEmp++;
            employeeList.Add(emp);
        }
        public static void Update(Employee emp)
        {
            int index = employeeList.FindIndex(w => w.Id == emp.Id);
            if (index == -1)
                return;
            employeeList[index] = emp;
        }
        public static void Delete(int Id)
        {
            //int index = employeeList.FindIndex(w => w.Id == Id);
            //if (index == 1)
            //    return;
            //var existEmp = employeeList.FirstOrDefault(w => w.Id == Id);
            //if (existEmp is null)
            //    return;
            var employee = Get(Id);
            if (employee is null)
                return;
            employeeList.Remove(employee);
        } 




    }
    //public class EmployeeService2:EmployeeService
    //{

    //}
}
