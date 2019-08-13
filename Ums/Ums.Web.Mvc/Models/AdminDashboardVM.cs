using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Ums.Web.Mvc.Models
{
    public class ChartVM
    {
        public ChartVM()
        {
            Labels = new List<String>();
            Data = new List<int>();
        }

        public ICollection<String> Labels { get; set; }
        public ICollection<int> Data { get; set; }
    }

    public class AdminDashboardVM
    {
        public int DepartmentCount { get; set; }
        public int CourseCount { get; set; }
        public int StudentCount { get; set; }
        public int RegistrationCount { get; set; }
        public ChartVM BarChartVM { get; set; }
        public ChartVM PieChartVM { get; set; }
    }
}