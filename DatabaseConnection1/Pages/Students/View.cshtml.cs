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
    public class ViewModel : PageModel
    {
        public List<Student> StudentRec { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Level { get; set; }

        public List<int> LevelItems { get; set; } = new List<int> { 4, 5, 6, 7 };

        public void OnGet()
        {

            string DbConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\zairu\source\repos\Week8A\DatabaseConnection1\Data\DatabaseConnection1.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT * FROM Student";

                if (!string.IsNullOrEmpty(Level) && (Level!="All"))
                {
                    command.CommandText += " WHERE StudentLevel = @StdLevel";
                    command.Parameters.AddWithValue("@StdLevel", Convert.ToInt32(Level));
                }

                SqlDataReader reader = command.ExecuteReader(); //SqlDataReader is used to read record from a table

                StudentRec = new List<Student>(); //this object of list is created to populate all records from the table

                while(reader.Read())
                {
                    Student record = new Student(); //a local var to hold a record temporarily
                    record.Id = reader.GetInt32(0); //getting the first field from the table
                    record.StudentID = reader.GetString(1); //getting the second field from the table
                    record.StudentName = reader.GetString(2); //getting the third field from the table
                    record.StudentLevel = reader.GetInt32(3);
                    record.StudentCourse = reader.GetString(4);

                    StudentRec.Add(record); //adding the single record into the list
                }

                // Call Close when done reading.
                reader.Close();
            }


        }
    }
}
