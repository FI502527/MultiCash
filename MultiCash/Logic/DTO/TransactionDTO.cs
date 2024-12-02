using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public int BankAccountId { get; set; }
        public int BankIdReceiver { get; set; }
        public bool Pending { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionDTO(TransactionModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Amount = model.Amount;
            DateTime = model.DateTime;
            BankAccountId = model.BankAccountId;
            BankIdReceiver = model.BankIdReceiver;
            Pending = model.Pending;
            TransactionTypeId = model.TransactionType.Id;
        }
    }
}
