using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai4.Models
{
    public class Staff
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public string ImageName { get; set; }
    }
}