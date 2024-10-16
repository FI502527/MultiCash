using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTO;
using Microsoft.Data.SqlClient;

namespace Data
{
	public class UserRepository
	{
		public UserDTO LoadUserById(int id)
		{
			Connection conn = new();
			using (SqlConnection sqlConnection = conn.GetConnection())
			{
				SqlCommand command = new SqlCommand($"SELECT * FROM [User] WHERE id = {id};", sqlConnection);
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
					}
				}
				return user;
			}
		}
	}
}
