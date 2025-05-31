using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai4.Models
{
    public class ExamResult
    {
        public string StudentName { get; set; }
        public double MathScore { get; set; }
        public double PhysicsScore { get; set; }
        public double ChemistryScore { get; set; }
        public string Region { get; set; }
        public bool IsPolicyFamily { get; set; }
        public double TotalScore { get; set; }
        public string Result { get; set; }
    }
}