using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Bar_Time_Management
{
    internal class Task
    {
        public string Description { get; set; }
        public int PercentTime { get; set; }
        public bool Status { get; set; } = false;
    }
}
