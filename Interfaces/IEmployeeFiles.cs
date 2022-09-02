using EmployeeRecords.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.Interface
{
   public interface IEmployeeFiles
    {
        Task<bool> EditImage(IFormFile file, int employeeID);

        Task<bool> CreateImage(IFormFile file, int employeeID);
    }
}
