using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.DTO;

namespace Logic.Model
{
    public class BankTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BankTypeModel() { }
        public BankTypeModel(BankTypeDTO bankTypeDTO)
        {
            Id = bankTypeDTO.Id;
            Name = bankTypeDTO.Name;
        }
    }
}
