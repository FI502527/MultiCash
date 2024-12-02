using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ITransactionRepository
    {
        public TransactionTypeDTO GetTransactionTypeByName(string name);
        public void UploadTransaction(TransactionDTO transactionDTO);
    }
}
