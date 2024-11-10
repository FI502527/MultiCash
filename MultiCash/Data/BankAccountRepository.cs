using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTO;
using Microsoft.Data.SqlClient;

namespace Data
{
	public class BankAccountRepository
	{
		public BankAccountDTO LoadBankAccountById(int bankId)
		{
			Connection conn = new();
			using (SqlConnection sqlConnection = conn.GetConnection())
			{
				SqlCommand command = new SqlCommand($"SELECT [id], [userId], [type], [amount] FROM [BankAccount] WHERE id = {bankId};", sqlConnection);
				BankAccountDTO bankAccount = new BankAccountDTO();
				sqlConnection.Open();
				SqlDataReader DataReader = command.ExecuteReader();
				if (DataReader.HasRows)
				{
					while (DataReader.Read())
					{
						bankAccount.Id = DataReader.GetInt32(0);
						bankAccount.UserId = DataReader.GetInt32(1);
						bankAccount.AccountType = DataReader.GetString(2);
                        bankAccount.Amount = DataReader.GetInt32(3);
                    }
				}
				return bankAccount;
			}
		}
	}
}