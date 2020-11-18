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
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public Student StudentRec { get; set; }

        public IActionResult OnGet(int? id)
        {
            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zairu\source\repos\Week8A\DatabaseConnection1\Data\DatabaseConnection1.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

           

            StudentRec = new Student();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Student WHERE Id = @ID";

                command.Parameters.AddWithValue("@ID", id);
                Console.WriteLine("The id : "+id);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    StudentRec.Id = reader.GetInt32(0);
                    StudentRec.StudentID = reader.GetString(1);
                    StudentRec.StudentName = reader.GetString(2);
                    StudentRec.StudentLevel = reader.GetInt32(3);
                    StudentRec.StudentCourse = reader.GetString(4);
                }


            }

            conn.Close();

            return Page();

        }


        public IActionResult OnPost()
        {
            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zairu\source\repos\Week8A\DatabaseConnection1\Data\DatabaseConnection1.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            Console.WriteLine("Student ID : " + StudentRec.Id);
            Console.WriteLine("Student Student ID : " + StudentRec.StudentID);
            Console.WriteLine("Student Name : " + StudentRec.StudentName);
            Console.WriteLine("Student Level : " + StudentRec.StudentLevel);
            Console.WriteLine("Student Course : " + StudentRec.StudentCourse);

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "UPDATE Student SET StudentId = @StdID, StudentName = @StdName, StudentLevel = @StdLevel, StudentCourse = @StdCourse WHERE Id = @ID";

                command.Parameters.AddWithValue("@ID", StudentRec.Id);
                command.Parameters.AddWithValue("@StdID", StudentRec.StudentID);
                command.Parameters.AddWithValue("@StdName", StudentRec.StudentName);
                command.Parameters.AddWithValue("@StdLevel", StudentRec.StudentLevel);
                command.Parameters.AddWithValue("@StdCourse", StudentRec.StudentCourse);

                command.ExecuteNonQuery();
            }

            conn.Close();

            return RedirectToPage("/Index");
        }

    }
}
