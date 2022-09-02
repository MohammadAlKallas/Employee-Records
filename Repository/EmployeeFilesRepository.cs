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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EmployeeRecords.Repositoty
{
    public class EmployeeFilesRepository : IEmployeeFiles
    {

        private readonly IHttpRequest _IHttpRequest;
        public EmployeeFilesRepository(IHttpRequest _IHttpRequest)
        {
            this._IHttpRequest = _IHttpRequest;
        }

        public async Task<bool> EditImage(IFormFile file, int employeeID)
        {
            var Result = await _IHttpRequest.PostFile("EmployeeFiles/SetImage/" + employeeID, file);
            if (Result != null)
                return true;

            return false;
        }

        public async Task<bool> CreateImage(IFormFile file, int employeeID)
        {
            var Result = await _IHttpRequest.PostFile("EmployeeFiles/CreateImage/" + employeeID, file);
            if (Result != null)
                return true;

            return false;
        }

    }
}
