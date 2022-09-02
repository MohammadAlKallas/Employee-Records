using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.Models
{
    public class EmployeeFiles
    {
        public int ID { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public int EmpID { get; set; }
    }
}
