using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmenSystem.Models
{
    public class Calendar : Approves
    {
        public string Interviewlink { get; set; }
        public string DataInterview { get; set; }

        public string Interviewer { get; set; }
    }
}
