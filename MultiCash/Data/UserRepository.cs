using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTO;
using Logic.Interfaces;
using Microsoft.Data.SqlClient;

namespace Data
{
	public class UserRepository : IUserRepository
	{
		public UserDTO LoadUserById(int id)
		{
			Connection conn = new();
			using (SqlConnection sqlConnection = conn.GetConnection())
			{
				SqlCommand command = new SqlCommand(
					"SELECT id, email, password, name, lastName " +
					"FROM [User] " +
					"WHERE id = @Id;", sqlConnection);
				
				command.Parameters.AddWithValue("Id", id);
				
				UserDTO user = new UserDTO();
				
				sqlConnection.Open();
				SqlDataReader DataReader = command.ExecuteReader();
				
				if (DataReader.HasRows)
				{
					while (DataReader.Read())
					{
						user.Id = DataReader.GetInt32(0);
						user.Email = DataReader.GetString(1);
						user.Password = DataReader.GetString(2);
						user.Name = DataReader.GetString(3);
						user.LastName = DataReader.GetString(4);
					}
				}
				return user;
			}
		}
		public UserDTO LoginCheck(string email, string password)
		{
			Connection conn = new();
			using (SqlConnection sqlConnection = conn.GetConnection())
			{
				SqlCommand command = new SqlCommand(
					"SELECT id, email, password, name, lastName " +
					"FROM [User] " +
					"WHERE email = @Email AND password = @Password", sqlConnection);
				
				command.Parameters.AddWithValue("Email", email);
				command.Parameters.AddWithValue ("Password", password);
				
				UserDTO user = new UserDTO();
				
				sqlConnection.Open();
				SqlDataReader DataReader = command.ExecuteReader();
                
				if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        user.Id = DataReader.GetInt32(0);
                        user.Email = DataReader.GetString(1);
                        user.Password = DataReader.GetString(2);
                        user.Name = DataReader.GetString(3);
                        user.LastName = DataReader.GetString(4);
                    }
                }
                return user;

            }
		}
	}
}
