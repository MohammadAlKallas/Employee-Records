using EmployeeRecords.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.Interface
{
     public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(int EmployeeId);
        Task<Employee> CreateEmployee(Employee Employee);
        Task<Employee> UpdateEmployee(int Id, Employee Employee);
        Task<Employee> DeleteEmployee(int EmployeeId);
        Task<IEnumerable<Employee>> FindEmployee(string Value);

    }
}
