using Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class TransactionTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TransactionTypeModel(TransactionTypeDTO transactionTypeDTO)
        {
            Id = transactionTypeDTO.Id;
            Name = transactionTypeDTO.Name;
        }
        public TransactionTypeModel() { }
    }
}
