using Logic.DTO;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests.DummyRepo
{
    public class TestTransactionRepository : ITransactionRepository
    {
        public TransactionTypeDTO GetTransactionTypeByName(string name)
        {
            TransactionTypeDTO transactionType = new TransactionTypeDTO
            {
                Id = 1,
                Name = name
            };
            return transactionType;
        }
        public void UploadTransaction(TransactionDTO transactionDTO)
        {
            return;
        }
    }
}
