using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList_blazor.Shared
{
    internal class Do
    {
        public int DoId { get; set; }
        public string DoString { get; set; }
        public bool Completed { get; set; }
    }
}
