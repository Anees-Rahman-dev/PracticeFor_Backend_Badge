using B_Review_Application.Interface;
using B_Review_Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace B_Review_Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)//IConfiguration allows us to read settings from appsettings.json.
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();

            using SqlConnection conn = new SqlConnection(_connectionString);

            conn.Open();

            string Q = @"Select * From Users";

            using SqlCommand cmd = new SqlCommand(Q,conn);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                User user = new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Age = Convert.ToInt32(reader["Age"]),
                    Course = reader["Course"].ToString()!
                };
            users.Add(user);
            }
            return users;
        }
        public User? GetById(int id)
        {
            User? user = null; //If the requested ID doesn't exist, we return null.

            using SqlConnection conn = new SqlConnection(_connectionString);

            conn.Open();

            string Q = @"Select * From Users Where Id = @Id";

            using SqlCommand cmd = new SqlCommand(Q, conn);

            cmd.Parameters.AddWithValue("@Id",id);

            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                user = new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Age = Convert.ToInt32(reader["Age"]),
                    Course = reader["Course"].ToString()!
                };
            }
            return user;
        }

        public void Add(User user)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);

            conn.Open();

            string Q = @"Insert Into Users (Name, Email, Age, Course)
                       Values (@Name, @Email, @Age, @Course)";

            using SqlCommand command = new SqlCommand(Q, conn);

            command.Parameters.AddWithValue("@Name",user.Name);
            command.Parameters.AddWithValue("@Email",user.Email);
            command.Parameters.AddWithValue("@Age",user.Age);
            command.Parameters.AddWithValue("@Course",user.Course);

            command.ExecuteNonQuery();
        }

        public bool Update(int id, User user)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);

            conn.Open();

            string Q = @"Update Users 
                         Set Name = @Name,
                             Email = @Email,
                             Age = @Age,
                             Course = @Course
                          Where Id = @Id";

            using SqlCommand command = new SqlCommand(Q,conn);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name",user.Name);
            command.Parameters.AddWithValue("@Email",user.Email);
            command.Parameters.AddWithValue("@Age",user.Age);
            command.Parameters.AddWithValue("@Course",user.Course);

            int RowsEffected = command.ExecuteNonQuery();

            return RowsEffected > 0;
        }
        
        public bool Delete(int id)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);

            conn.Open();

            string Q = @"Delete From Users Where Id = @Id";

            using SqlCommand command = new SqlCommand(Q,conn);

            command.Parameters.AddWithValue("@Id",id);

            int IsDeleted = command.ExecuteNonQuery();

            return IsDeleted > 0;
        }
    }
}
