using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LogDTO
    {
        public int? ID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Origin { get; set; }
        public string Message { get; set; }
        public int Priority { get; set; }
        public bool Handled { get; set; }
    }
}
