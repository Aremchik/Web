using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmenSystem.Models
{
    public class ITSpecialist : Employees
    {
        public int InterviewsCount { get; set; }

        public ITSpecialist() 
        {
            InterviewsCount = 0;
        }
    }
}
