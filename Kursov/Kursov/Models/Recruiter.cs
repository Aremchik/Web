using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursov.Models
{
    public class Recruiter
    {
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public int ApprovedCount { get; set; }
        public int InterviewCount { get; set; }
    }
}
