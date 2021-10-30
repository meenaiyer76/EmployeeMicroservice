using EmployeeMicroservice.Models;
using System;
using EmployeeMicroservice.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Repositories
{
    public class EmployeeRepository
    {
        private readonly EmployeeContext _dbcontext;
        public List<Employee> Employees = new List<Employee>()
            {
                new Employee{EmployeeId=101, EmployeeName="Nithya Kalyani", Password="12345"},
                new Employee{EmployeeId=102, EmployeeName="Daphne Bridgerton", Password="12345"},
                new Employee{EmployeeId=103, EmployeeName="Loki Laufeyson", Password="12345"},
                new Employee{EmployeeId=104, EmployeeName="Malcolm Bright", Password="12345"},
                new Employee{EmployeeId=105, EmployeeName="Clarke Griffin", Password="12345"},
                new Employee{EmployeeId=201, EmployeeName="Harvey Specter", Password="12345"},

            };

        }
}
