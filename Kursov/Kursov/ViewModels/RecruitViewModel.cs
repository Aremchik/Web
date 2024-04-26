using Kursov.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursov.ViewModels
{
    public class RecruitViewModel
    {
        public ObservableCollection<Recruiter> Recruits { get; set; }

        public RecruitViewModel()
        {
            Recruits = new ObservableCollection<Recruiter>
            {
                new Recruiter { Name = "Иванов Иван", ContactInfo = "ivanov@example.com", ApprovedCount = 3, InterviewCount = 5 },
                new Recruiter { Name = "Петров Петр", ContactInfo = "petrov@example.com", ApprovedCount = 2, InterviewCount = 4 }
                // Добавьте больше рекрутов по мере необходимости
            };
        }
    }
}
