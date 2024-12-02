using Logic.DTO;
using Logic.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TransactionRepository : ITransactionRepository
    {
        public TransactionTypeDTO GetTransactionTypeByName(string name)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand(
                    "SELECT id, name " +
                    "FROM TransactionType " +
                    "WHERE name = @Name", sqlConnection);
                command.Parameters.Add(new SqlParameter("@Name", name));
                TransactionTypeDTO transactionType = new TransactionTypeDTO();
                sqlConnection.Open();
                SqlDataReader DataReader = command.ExecuteReader();
                if (DataReader.HasRows)
                {
                    while (DataReader.Read())
                    {
                        transactionType.Id = DataReader.GetInt32(0);
                        transactionType.Name = DataReader.GetString(1);
                    }
                }
                sqlConnection.Close();
                return transactionType;
            }
        }
        public void UploadTransaction(TransactionDTO transactionDTO)
        {
            Connection conn = new();
            using (SqlConnection sqlConnection = conn.GetConnection())
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [Transaction] ([name], [amount], [dateTime], " +
                    "[bankAccountId], [bankAccountIdReceiver], [pending], [transactionTypeId]) " +
                    "VALUES(@Name, @Amount, @DateTime, @BankAccountId, @BankAccountIdReceiver, " +
                    "@Pending, @TransactionTypeId); ", sqlConnection);

                command.Parameters.AddWithValue("Name", transactionDTO.Name);
                command.Parameters.AddWithValue("Amount", transactionDTO.Amount);
                command.Parameters.AddWithValue("DateTime", transactionDTO.DateTime);
                command.Parameters.AddWithValue("BankAccountId", transactionDTO.BankAccountId);
                command.Parameters.AddWithValue("BankAccountIdReceiver", transactionDTO.BankIdReceiver);
                command.Parameters.AddWithValue("Pending", transactionDTO.Pending);
                command.Parameters.AddWithValue("TransactionTypeId", transactionDTO.TransactionTypeId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                sqlConnection.Close();

                return;
            }
        }
    }
}
