using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursov.Models
{
    public class Resume
    {
        public DateTime Date { get; set; }
        public string RecruiterName { get; set; }
        public string ResumeLink { get; set; }
        public string HRApproval { get; set; }
        public string ITApproval { get; set; }
        public string Comment { get; set; }
    }
}
