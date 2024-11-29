using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO
{
    public class BankAccountDTO
    {
        public int Id { get; set; }
        public int Balance { get; set; }
        public int BankTypeId { get; set; }
        public int UserId { get; set; }
        public BankAccountDTO() { }
        public BankAccountDTO(int id, int balance, int bankTypeId)
        {
            Id = id;
            Balance = balance;
            BankTypeId = bankTypeId;
        }
    }
}