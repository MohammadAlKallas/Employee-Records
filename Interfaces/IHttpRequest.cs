using EmployeeRecords.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.Interface
{
    public interface IHttpRequest
    {
        Task<object> GetJson(string Uri);
        Task<object> DeleteJson(string Uri);
        Task<string> PostJson(string Uri, object Emp);
        Task<string> PutJson(string Uri, object Emp);
        Task<string> PostFile(string Uri, IFormFile Emp);

    }
}
