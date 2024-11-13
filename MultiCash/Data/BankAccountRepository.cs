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
				SqlCommand command = new SqlCommand(
					$"SELECT [id], [userId], [type], [amount] " +
					$"FROM [BankAccount] " +
					$"WHERE id = {bankId};", sqlConnection);
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
        public List<BankAccountDTO> LoadBankAccountsByUserId(int userId)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand($"SELECT [id], [userId], [type], [amount] FROM [BankAccount] WHERE userId = @Id;", sqlConnection);
				command.Parameters.Add(new SqlParameter("@Id", userId));
                List<BankAccountDTO> bankAccounts = new List<BankAccountDTO>();
                sqlConnection.Open();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
						BankAccountDTO bank = new BankAccountDTO(DataReader.GetInt32(0), DataReader.GetInt32(1), DataReader.GetString(2), DataReader.GetInt32(3));
						bankAccounts.Add(bank);
                    }
                }
                return bankAccounts;
            }
        }
        public void AddBankAccount(BankAccountDTO bankDTO)
		{
            Connection conn = new();
				using (SqlConnection sqlConnection = conn.GetConnection())
				{
					SqlCommand command = new SqlCommand($"INSERT INTO [BankAccount]([userId], [type], [amount]) VALUES(@UserID, @AccountType, @Amount)", sqlConnection);
					command.Parameters.Add(new SqlParameter("@UserID", bankDTO.UserId));
					command.Parameters.Add(new SqlParameter("@AccountType", bankDTO.AccountType));
					command.Parameters.Add(new SqlParameter("@Amount", bankDTO.Amount));
				
					sqlConnection.Open();
					command.ExecuteNonQuery();
					sqlConnection.Close();
					return;
				}
        }
	}
}