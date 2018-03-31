using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class Schedule
    {
        public DateTime Date { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}