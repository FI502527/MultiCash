using Microsoft.Data.SqlClient;

namespace Data
{
	public class Connection
	{
		private static string connectionString = "";
		private SqlConnection connection = new SqlConnection(connectionString);
		public SqlConnection GetConnection()
		{
			return connection;
		}
	}
}