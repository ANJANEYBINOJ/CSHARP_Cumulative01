using System.Data;
using Cumulative01.Models;
using MySql.Data.MySqlClient;

namespace Cumulative01.DALL
{
    public class TeacherData
    {
        private readonly string _connectionString;

        public TeacherData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new();
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM teachers", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                teachers.Add(new Teacher
                {
                    Id = reader.GetInt32("Id"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    HireDate = reader.GetDateTime("HireDate")
                });
            }

            return teachers;
        }

        public Teacher? GetTeacherById(int id)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var cmd = new MySqlCommand("SELECT * FROM teachers WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Teacher
                {
                    Id = reader.GetInt32("Id"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    HireDate = reader.GetDateTime("HireDate")
                };
            }

            return null;
        }
      
    }
}
