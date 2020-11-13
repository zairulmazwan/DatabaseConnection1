using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DatabaseConnection1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DatabaseConnection1.Pages.Students
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Student StudRec { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string DbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DatabaseConnection1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"INSERT INTO Student (StudentID, StudentName, StudentLevel, StudentCourse) VALUES (@SID, @SName, @SLevel, @SCourse)";

                command.Parameters.AddWithValue("@SID", StudRec.StudentID);
                command.Parameters.AddWithValue("@SName", StudRec.StudentName);
                command.Parameters.AddWithValue("@SLevel", StudRec.StudentLevel);
                command.Parameters.AddWithValue("@SCourse", StudRec.StudentCourse);
               

                Console.WriteLine(StudRec.StudentID);
                Console.WriteLine(StudRec.StudentName);
                Console.WriteLine(StudRec.StudentLevel);
                Console.WriteLine(StudRec.StudentCourse);
               


                command.ExecuteNonQuery();
            }



            return RedirectToPage("/Index");
        }


    }
}
