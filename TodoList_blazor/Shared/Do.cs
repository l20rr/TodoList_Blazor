using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList_blazor.Shared
{
    public class Do
    {
        public Guid DoId { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }

        public DateTime DateOn { get; set; }
    }
}
