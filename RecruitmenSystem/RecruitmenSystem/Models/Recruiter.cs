using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmenSystem.Models
{
    public class Recruiter : Employees
    {
        
        public int ApprovedCount { get; set; }
        public int SentForInterview { get; set; }
        public int HiredCount { get; set; }

        public Recruiter() {
            ApprovedCount=0;
            SentForInterview = 0; 
            HiredCount=0;
        }
    }
}
