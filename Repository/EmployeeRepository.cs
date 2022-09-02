using EmployeeRecords.Interface;
using EmployeeRecords.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace EmployeeRecords.Repositoty
{
    public class EmployeeRepository : IEmployee
    {

        private readonly IHttpRequest _IHttpRequest;
        public EmployeeRepository(IHttpRequest _IHttpRequest)
        {
            this._IHttpRequest = _IHttpRequest;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var Result =await _IHttpRequest.GetJson("Employee/GetAllEmployees");
            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(Result.ToString());
        }

        public async Task<Employee> UpdateEmployee(int Id, Employee Employee)
        {
            var Result = await _IHttpRequest.PutJson("Employee/UpdateEmployee/"+Id,Employee);
            return JsonConvert.DeserializeObject<Employee>(Result.ToString());
        }

        public async Task<Employee> DeleteEmployee(int EmployeeId)
        {
            var Result = await _IHttpRequest.DeleteJson("Employee/DeleteEmployee/"+EmployeeId);
            return JsonConvert.DeserializeObject<Employee>(Result.ToString());
        }

        public async Task<Employee> CreateEmployee(Employee Employee)
        {
            var Result = await _IHttpRequest.PostJson("Employee/CreateEmployee", Employee);
            return JsonConvert.DeserializeObject<Employee>(Result.ToString());
        }

      

        public async Task<IEnumerable<Employee>> FindEmployee(string Value)
        {
            var Result = await _IHttpRequest.GetJson("Employee/FindEmployee/"+Value);
            if(Result!=null)
              return JsonConvert.DeserializeObject<IEnumerable<Employee>>(Result.ToString());

            return null;
        }
        
        public async Task<Employee> GetEmployee(int EmployeeId)
        {
            var Result = await _IHttpRequest.GetJson("Employee/GetEmployee/" + EmployeeId);
            if (Result != null)
                return JsonConvert.DeserializeObject<Employee>(Result.ToString());

            return null;

        }

    }
}
