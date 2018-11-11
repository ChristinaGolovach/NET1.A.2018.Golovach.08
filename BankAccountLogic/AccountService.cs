using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLogic.Factories;

namespace BankAccountLogic
{
    public static class AccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="creator"></param>
        /// <param name="passportNumber"></param>
        /// <param name="initialBalance"></param>
        /// <returns></returns>
        public static int CreateBankAccount(AccountFactory creator, string passportNumber , decimal initialBalance = 0M)
        {
            CheckInputData(creator, passportNumber, initialBalance);

            Owner owner = FindOwner(passportNumber);

            Account account = creator.CreateAccount(owner, initialBalance);
            owner.Accouns.Add(account);

            return account.Number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberAccount"></param>
        /// <param name="passportNumber"></param>
        public static void CloseBankAccount(int numberAccount, string passportNumber)
        {
            CheckInputData(numberAccount, passportNumber);

            Owner owner = FindOwner(passportNumber);

            Account account = FindAccountByNumber(numberAccount, owner);
            account.CloseAccount();           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberAccount"></param>
        /// <param name="passportNumber"></param>
        /// <param name="money"></param>
        public static void PutMoney(int numberAccount, string passportNumber, decimal money)
        {
            Owner owner = OwnerService.FindOwnerByPassport(passportNumber);
            Account account = FindAccountByNumber(numberAccount, owner);
            account.PutMoney(money);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberAccount"></param>
        /// <param name="passportNumber"></param>
        /// <param name="money"></param>
        public static void TakeMoney(int numberAccount, string passportNumber, decimal money)
        {
            Owner owner = OwnerService.FindOwnerByPassport(passportNumber);
            Account account = FindAccountByNumber(numberAccount, owner);
            account.TakeMoney(money);
        }

        private static Account FindAccountByNumber(int number, Owner owner)
        {
            //Account account =  owner.Accouns.Find(a => a.Number == number);

            Account foundAccount = null;
            foreach (var account in owner.Accouns)
            {
                if (account.Number == number)
                {
                    return account;
                }
            }

            return foundAccount;            
        }

        private static Owner FindOwner(string passportNumber)
        {
            Owner owner = OwnerService.FindOwnerByPassport(passportNumber);

            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentException($"The owner with passport number {passportNumber} does not exist.");
            }

            return owner;
        }

        private static void CheckInputData(AccountFactory creator, string passportNumber, decimal initialBalance)
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

        private static void CheckInputData(int numberAccount, string passportNumber)
        {
            if (numberAccount <= 0)
            {
                throw new ArgumentException($"The {nameof(numberAccount)} can not be less zero.");
            }

            CheckPassportNumber(passportNumber);
        }

        private static void CheckPassportNumber(string passportNumber)
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
