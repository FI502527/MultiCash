﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.DTO;
using Logic.Model;

namespace Logic
{
    public class BankService
    {
        private readonly BankAccountRepository _bankRepository;
        public BankService(BankAccountRepository bankRepository)
        {
            this._bankRepository = bankRepository;
        }
        public BankAccountModel LoadBankAccountById(int bankId)
        {
            BankAccountDTO bankDTO = _bankRepository.LoadBankAccountById(bankId);
            BankAccountModel bankModel = new BankAccountModel(bankDTO);
            return bankModel;
        }
        public List<BankAccountModel> LoadBankAccountsByUserId(int userId)
        {
            List<BankAccountDTO> bankDTOs = _bankRepository.LoadBankAccountsByUserId(userId);
            List<BankAccountModel> bankModels = new List<BankAccountModel>();
            foreach(BankAccountDTO bankDTO  in bankDTOs)
            {
                BankAccountModel bankModel = new BankAccountModel(bankDTO);
                bankModels.Add(bankModel);
            }
            return bankModels;
        }
        public void AddBankAccount(BankAccountModel bankModel)
        {
            BankAccountDTO bankDTO = new BankAccountDTO(bankModel.Id, bankModel.UserId, bankModel.AccountType, bankModel.Amount);
            _bankRepository.AddBankAccount(bankDTO);
            return;
        }
    }
}