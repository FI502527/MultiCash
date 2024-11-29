using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic.Model;
using Logic.DTO;

namespace Logic
{
    public class BankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUserRepository _userRepository;
        public BankAccountService(IBankAccountRepository bankRepository, IUserRepository userRepository)
        {
            this._bankAccountRepository = bankRepository;
            this._userRepository = userRepository;
        }
        public BankAccountModel LoadBankAccountById(int bankId)
        {
            BankAccountDTO bankDTO = _bankAccountRepository.LoadBankAccountById(bankId);
            UserDTO userDTO = _userRepository.LoadUserById(bankDTO.UserId);
            UserModel user = new UserModel(userDTO);
            BankTypeDTO bankTypeDTO = _bankAccountRepository.GetBankTypeById(bankDTO.BankTypeId);
            BankTypeModel bankType = new BankTypeModel(bankTypeDTO);
            BankAccountModel bankModel = new BankAccountModel(bankDTO, user, bankType);
            return bankModel;
        }
        public List<BankAccountModel> LoadBankAccountsByUserId(int userId)
        {
            List<BankAccountDTO> bankDTOs = _bankAccountRepository.LoadBankAccountsByUserId(userId);
            List<BankAccountModel> bankModels = new List<BankAccountModel>();
            foreach(BankAccountDTO bankDTO  in bankDTOs)
            {
                UserDTO userDTO = _userRepository.LoadUserById(bankDTO.UserId);
                UserModel user = new UserModel(userDTO);
                BankTypeDTO bankTypeDTO = _bankAccountRepository.GetBankTypeById(bankDTO.BankTypeId);
                BankTypeModel bankType = new BankTypeModel(bankTypeDTO);
                BankAccountModel bankModel = new BankAccountModel(bankDTO, user, bankType);
                bankModels.Add(bankModel);
            }
            return bankModels;
        }
        public void AddBankAccount(BankAccountModel bankModel)
        {
            BankAccountDTO bankDTO = new BankAccountDTO(bankModel.Id, bankModel.Balance, bankModel.BankType.Id);
            _bankAccountRepository.AddBankAccount(bankDTO);
            return;
        }
        public BankTypeModel GetBankTypeByName(string name)
        {
            BankTypeDTO bankTypeDTO = _bankAccountRepository.GetBankTypeByName(name);
            BankTypeModel bankType = new BankTypeModel(bankTypeDTO);
            return bankType;
        }
    }
}