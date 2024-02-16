using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProject.Models {
    public class Employee {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTime DtOfBirth { get; set; }
    }
}