using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmenSystem.Models
{
    public class Approves : Recruiter
    {
        public int ApproveId { get; set; }
        public string DateAdded { get; set; }
        public string Summary { get; set; }
        public string Contacts { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; } 
        public int ApprovedByIT { get; set; }
    }
}
