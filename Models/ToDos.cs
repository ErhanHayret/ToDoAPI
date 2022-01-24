using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class ToDos
    {
        public int ToDoID { get; set; }
        public string ToDoText { get; set; }
        public int ToDoCompleted { get; set; }
        public int UserID { get; set; }
    }
}
