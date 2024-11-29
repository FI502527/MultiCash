using Logic.Model;

namespace MultiCash.Models
{
    public class BankTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BankTypeViewModel(BankTypeModel bankType)
        {
            Id = bankType.Id;
            Name = bankType.Name;
        }
    }
}
