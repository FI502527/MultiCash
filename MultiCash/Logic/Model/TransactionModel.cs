using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public int BankAccountId { get; set; }
        public int BankIdReceiver { get; set; }
        public bool Pending { get; set; }
        public TransactionTypeModel TransactionType { get; set; }
    }
}
