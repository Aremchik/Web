using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursov.Models.Database
{
    internal class db
    {
        private string connectionString = "Data Source=Kursov.db;Version=3;";

        public void AddResume(Resume resume)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Resumes (Date, RecruiterName, ResumeLink, HRApproval, ITApproval, Comment) " +
                               "VALUES (@Date, @RecruiterName, @ResumeLink, @HRApproval, @ITApproval, @Comment)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Date", resume.Date);
                command.Parameters.AddWithValue("@RecruiterName", resume.RecruiterName);
                command.Parameters.AddWithValue("@ResumeLink", resume.ResumeLink);
                command.Parameters.AddWithValue("@HRApproval", resume.HRApproval);
                command.Parameters.AddWithValue("@ITApproval", resume.ITApproval);
                command.Parameters.AddWithValue("@Comment", resume.Comment);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateApproval(string approvalType, string approvalStatus, DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"UPDATE Resumes SET {approvalType} = @ApprovalStatus WHERE Date = @Date";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApprovalStatus", approvalStatus);
                command.Parameters.AddWithValue("@Date", date);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOldResumes(DateTime cutoffDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Resumes WHERE Date < @CutoffDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CutoffDate", cutoffDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
