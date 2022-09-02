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

namespace EmployeeRecords.Repositoty
{
    public class DepartmentRepository : IDepartment
    {

        private readonly IHttpRequest _IHttpRequest;
        public DepartmentRepository(IHttpRequest _IHttpRequest)
        {
            this._IHttpRequest = _IHttpRequest;
        }
        public async Task<IEnumerable<Department>> GetAllDept()
        {
            var Result = await _IHttpRequest.GetJson("Department/GetAllDept");
            return JsonConvert.DeserializeObject<IEnumerable<Department>>(Result.ToString());
        }

        public async Task<Department> GetDept(int DeptId)
        {
            var Result = await _IHttpRequest.GetJson("Department/GetDept"+DeptId);
            return JsonConvert.DeserializeObject<Department>(Result.ToString());
        }
    }
}
