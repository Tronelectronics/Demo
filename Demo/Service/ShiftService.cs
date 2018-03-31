using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Service
{
    public class ShiftService
    {
        public List<string> GetAllShiftNames()
        {
            List<string> shiftNames = new List<string>();

            shiftNames.Add("早班");
            shiftNames.Add("中班");
            shiftNames.Add("晚班");

            return shiftNames;
        }
    }
}