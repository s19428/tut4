using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.DAL
{
    public class DbService : IDbService
    {
        private const string connectionString = @"Server=localhost\SQLEXPRESS01;Integrated Security=true;";

        public IEnumerable<Student> GetStudents()
        {
            List<Student> _students = new List<Student>();
            
            using (SqlConnection con = new SqlConnection(connectionString))
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
                        st.LastName = dr["LastName"].ToString();
                        st.IndexNumber = dr["IndexNumber"].ToString();
                        //...
                        _students.Add(st);
                    }
                }
            }
            
            /*
            var dr = Execute("Select * From Student");
            while (dr.Read())
            {
                var st = new Student();
                st.FirstName = dr["FirstName"].ToString();
                st.LastName = dr["LastName"].ToString();
                st.IndexNumber = dr["IndexNumber"].ToString();
                //...
                _students.Add(st);
            }
            */

            return _students;
        }

        public Student GetStudent(string name) 
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (var com = new SqlCommand($"Select * From Student Where FirstName Like '{name}'"))
                {
                    com.Connection = con;

                    con.Open();
                    var dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        var st = new Student();
                        st.FirstName = dr["FirstName"].ToString();
                        st.LastName = dr["LastName"].ToString();
                        st.IndexNumber = dr["IndexNumber"].ToString();
                        //...
                        return st;
                    }
                }
            }

            return null;
        }

        /*
        private SqlDataReader Execute(string sqlString)
        {
            using (SqlConnection con = new SqlConnection(
                            @"Server=localhost\SQLEXPRESS01;Integrated Security=true;"))
            {
                using (var com = new SqlCommand(sqlString))
                {
                    com.Connection = con;

                    con.Open();
                    var dr = com.ExecuteReader();
                    return dr;
                    
                    while (dr.Read())
                    {
                        var st = new Student();
                        st.FirstName = dr["FirstName"].ToString();
                        st.LastName = dr["LastName"].ToString();
                        st.IndexNumber = dr["IndexNumber"].ToString();
                        //...
                        _students.Add(st);
                    }
                    

                    con.Close();
                }
            }
        }
        */
    }
}
