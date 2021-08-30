using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVIMonitor.Models
{
    public class DVIService
    {
        public int Id { get; set; }
        public string InsideTemp { get; set; }
        public string InsideHumitity { get; set; }
        public string OutsideTemp { get; set; }
        public string OutsideHumitity { get; set; }
    }
}