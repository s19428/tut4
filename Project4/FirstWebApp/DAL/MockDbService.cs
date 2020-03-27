using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.DAL
{
    public class MockDbService : IDbService
    {
        public static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{StudentID = 1, FirstName = "name1", LastName = "surname1" },
                new Student{StudentID = 2, FirstName = "name2", LastName = "surname2" },
                new Student{StudentID = 3, FirstName = "name3", LastName = "surname3" },
                new Student{StudentID = 4, FirstName = "name4", LastName = "surname4" }
            };
        }

        
        public IEnumerable<Student> GetStudents()
        {
            /*
            using (var con = new SqlConnection(
            @"Server=(localdb)\SQLEXPRESS01;Integrated Security=true;"))
            {
                SqlCommand com = new SqlCommand();
                com.Command = con;
            }
            */
            /*
            using (SqlConnection con = new SqlConnection(
            @"Server=localhost\SQLEXPRESS01;Integrated Security=true;"))
            {
                using (var com = new SqlCommand("Select * From Student"))
                {
                    com.Connection = con;

                    con.Open();
                    var dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        var st = new Student();
                        st.FirstName = dr["FirstName"].ToString();
                        //...
                    }
                }
            }
            */

            return _students;
        }

        public Student GetStudent(string name)
        { return null; }
    }
}