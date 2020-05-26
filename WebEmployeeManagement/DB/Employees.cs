using System;
using System.Collections.Generic;

namespace WebEmployeeManagement.DB
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthyear { get; set; }
        public string Position { get; set; }
        public string Division { get; set; }
    }
}
