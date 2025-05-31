using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai4.Models
{
    public class EmailInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public List<string> Attachments { get; set; }
    }
}