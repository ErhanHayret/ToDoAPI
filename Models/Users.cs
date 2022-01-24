using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string Password { get; set; }
    }
}
