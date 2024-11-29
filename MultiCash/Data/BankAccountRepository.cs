using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Logic.Interfaces;
using Logic.DTO;
using Logic.Model;

namespace Data
{
	public class BankAccountRepository : IBankAccountRepository
	{
		public BankAccountDTO LoadBankAccountById(int bankId)
		{
			Connection conn = new();
			using (SqlConnection sqlConnection = conn.GetConnection())
			{
				SqlCommand command = new SqlCommand(
                    "SELECT " +
                    "B.id, B.balance, BT.id AS bankType, U.id" +
                    "FROM BankAccount B " +
                    "LEFT JOIN UserBankAccount UB ON B.id = UB.bankId " +
                    "LEFT JOIN [User] U ON UB.userId = U.id " +
                    "LEFT JOIN BankType BT ON B.bankTypeId = BT.id;" +
                    "WHERE B.id = @BankId", sqlConnection);
                BankAccountDTO bankAccount = new BankAccountDTO();
				sqlConnection.Open();
				SqlDataReader DataReader = command.ExecuteReader();
				if (DataReader.HasRows)
				{
					while (DataReader.Read())
					{
                        bankAccount.Id = DataReader.GetInt32(0);
                        bankAccount.Balance = DataReader.GetInt32(1);
                        bankAccount.BankTypeId = DataReader.GetInt32(2);
                        bankAccount.UserId = DataReader.GetInt32(3);
                    }
				}
                sqlConnection.Close();
                return bankAccount;
			}
		}
        public List<BankAccountDTO> LoadBankAccountsByUserId(int userId)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand(
					"SELECT " +
					"B.id, B.balance, BT.id AS bankType, U.id AS userId " +
					"FROM [BankAccount] B " +
					"LEFT JOIN UserBankAccount UB ON B.id = UB.bankId " +
					"LEFT JOIN [User] U ON UB.userId = U.id " +
					"LEFT JOIN BankType BT ON B.bankTypeId = BT.id " +
					"WHERE U.id = @UserId", sqlConnection);
				command.Parameters.Add(new SqlParameter("@UserId", userId));
                List<BankAccountDTO> bankAccounts = new List<BankAccountDTO>();
                sqlConnection.Open();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
						BankAccountDTO bank = new BankAccountDTO();
                        bank.Id = (int)DataReader["id"];
                        bank.Balance = (int)DataReader["balance"];
                        bank.BankTypeId = (int)DataReader["bankType"];
                        bank.UserId = (int)DataReader["userId"];
                        
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
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [BankAccount]([balance], [bankTypeId]) " +
                    "VALUES(@Balance, @BankTypeId)", sqlConnection);
                command.Parameters.Add(new SqlParameter("@Balance", bankDTO.Balance));
                command.Parameters.Add(new SqlParameter("@BankTypeId", bankDTO.BankTypeId));

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();
                return;
            }
        }
        public BankTypeDTO GetBankTypeById(int bankTypeId)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand(
                    "SELECT [id], [name]" +
                    "FROM [BankType]" +
                    "WHERE id = @Id", sqlConnection);
                command.Parameters.Add(new SqlParameter("@Id", bankTypeId));

                sqlConnection.Open();
                BankTypeDTO bankType = new BankTypeDTO();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        bankType.Id = DataReader.GetInt32(0);
                        bankType.Name = DataReader.GetString(1);
                    }
                }
                sqlConnection.Close();
                return bankType;
            }
        }
        public BankTypeDTO GetBankTypeByName(string bankTypeName)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand(
                    "SELECT [id], [name]" +
                    "FROM [BankType]" +
                    "WHERE name = @Name", sqlConnection);
                command.Parameters.Add(new SqlParameter("@Name", bankTypeName));

                sqlConnection.Open();
                BankTypeDTO bankType = new BankTypeDTO();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        bankType.Id = DataReader.GetInt32(0);
                        bankType.Name = DataReader.GetString(1);
                    }
                }
                sqlConnection.Close();
                return bankType;
            }
        }
    }
}