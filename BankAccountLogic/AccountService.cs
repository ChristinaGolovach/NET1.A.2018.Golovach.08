using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLogic.Factories;
using BankAccountLogic.NumberGenerator;
using BankAccountLogic.Repositories.Interfaces;

namespace BankAccountLogic
{
    public class AccountService
    {
        private OwnerService ownerService;
        private INumberGenerator<string> numberGenerator;
        private IAccountRepository accountRepository;

        public AccountService(IAccountRepository accountRepository, OwnerService ownerService, INumberGenerator<string> numberGenerator)
        {
            this.accountRepository = accountRepository;
            this.ownerService = ownerService;
            this.numberGenerator = numberGenerator;            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creator"></param>
        /// <param name="passportNumber"></param>
        /// <param name="initialBalance"></param>
        /// <returns></returns>
        public string CreateAccount(AccountFactory accountCreator, string passportNumber , decimal initialBalance = 0M)
        {
            CheckInputData(accountCreator, passportNumber, initialBalance);

            //TODO Если такого пользователя не существует
            Owner owner = ownerService.FindByPassport(passportNumber);

            Account account = CreateAccountCore(accountCreator, owner, initialBalance);

            return account.Number;
        }

        public string CreateAccount(AccountFactory accountCreator, string passportNumber, string firstName, string lastName, string email, decimal initialBalance = 0M)
        {
            //TODO
            //CheckInputData()

            Owner owner = ownerService.CreateOwner(passportNumber, firstName, lastName, email);

            Account account = CreateAccountCore(accountCreator, owner, initialBalance);

            return account.Number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberAccount"></param>
        /// <param name="passportNumber"></param>
        public void CloseAccount(string accountNumber)
        {
            //CheckInputData(numberAccount); 

            Account account = accountRepository.GetByNumber(accountNumber);

            account = account ?? throw new ArgumentException($"Account with number {accountNumber} does not exist.");

            //TODO TRY - CATCH
            account.CloseAccount();           
        }


        public void PutMoney(string accountNumber, decimal amount)
        {
            Account account = accountRepository.GetByNumber(accountNumber);

            account.Deposit(amount);
            
        }



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="numberAccount"></param>
        ///// <param name="passportNumber"></param>
        ///// <param name="money"></param>
        //public void TakeMoney(int numberAccount, string passportNumber, decimal money)
        //{
        //    Owner owner = OwnerService.FindOwnerByPassport(passportNumber);
        //    Account account = FindAccountByNumber(numberAccount, owner); 
        //    account.TakeMoney(money);
        //}


        private Account CreateAccountCore(AccountFactory accountCreator, Owner owner, decimal initialBalance)
        {
            string accountNumber = ReciveAccountNumber();

            Account account = accountCreator.CreateAccount(accountNumber, owner, initialBalance);

            accountRepository.Add(account);

            ownerService.OpenNewAccount(owner, account);

            return account;
        }

        private string ReciveAccountNumber()
        {
            string accountNumber = numberGenerator.GenerateNumber();

            while (!IsExistsAccountNumber(accountNumber))
            {
                accountNumber = numberGenerator.GenerateNumber();
            }

            return accountNumber;
        }

        private bool IsExistsAccountNumber(string accountNumber)
        {
            Account account = accountRepository.GetByNumber(accountNumber);

            return ReferenceEquals(account, null);
        }

        private void CheckInputData(AccountFactory creator, string passportNumber, decimal initialBalance)
        {
            CheckPassportNumber(passportNumber);

            if (ReferenceEquals(creator, null))
            {
                throw new ArgumentNullException($"The {nameof(creator)} can not be null.");
            }

            if (initialBalance < 0)
            {
                throw new ArithmeticException($"The {nameof(initialBalance)} can not be less zero.");
            }
        }

        private  void CheckInputData(int numberAccount, string passportNumber)
        {
            if (numberAccount <= 0)
            {
                throw new ArgumentException($"The {nameof(numberAccount)} can not be less zero.");
            }

            CheckPassportNumber(passportNumber);
        }

        private  void CheckPassportNumber(string passportNumber)
        {
            if (ReferenceEquals(passportNumber, null))
            {
                throw new ArgumentNullException($"The {nameof(passportNumber)} can not be null.");
            }

            if (passportNumber.Length == 0)
            {
                throw new ArithmeticException($"The {nameof(passportNumber)} can not be empty.");
            }
        }
    }
}
