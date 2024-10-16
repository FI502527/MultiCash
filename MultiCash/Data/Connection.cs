using Microsoft.Data.SqlClient;

namespace Data
{
	public class Connection
	{
		private static string connectionString = "Data Source=LAPTOP-2LRUOKMM;Initial Catalog=MultiCash;Integrated Security=SSPI;TrustServerCertificate=True;";
		private SqlConnection connection = new SqlConnection(connectionString);
		public SqlConnection GetConnection()
		{
			return connection;
		}
	}
}