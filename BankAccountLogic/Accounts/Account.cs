using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLogic
{
    public abstract class Account
    {
        //private readonly string number;
        private string number;
        private decimal balance;
        private int bonusPoints;
        private bool isOpened;
        private Owner owner;

        public string Number
        {
            get => number;
            private set => number = value ?? throw new ArgumentNullException($"The {nameof(number)} can not be null.");
        }

        public decimal Balance
        {
            get => balance;
            private set => balance = value;
        }

        public int BonusPoints
        {
            get => bonusPoints;

            private set => bonusPoints = value;
        }

        public bool IsOponed
        {
            get => isOpened;

            private set => isOpened = value;
        }

        public Owner Owner
        {
            get => owner;

            internal protected set => owner = value ?? throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
        }

        public Account(string accountNumber,  Owner owner, decimal initialBalance = 0M)
        {
            IsOponed = true;
            Number = accountNumber;
            Owner = owner;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"The count of {nameof(amount)} must be more than zero for this operation.");
            }

            Balance += amount;
            BonusPoints -= CalculateBonusPoints(amount);
        }

        public void Withdraw(decimal amount)
        {
            //TODO это здесь проверять или сервис должен валидацию делать или там и здесь? - і там і здесь
            if (amount <= 0)
            {
                throw new ArgumentException($"The count of {nameof(amount)} must be more than zero for this operation.");
            }

            if (!IsAllowedToWithdraw(amount))
            {
                // верное ли исключение??
                throw new InvalidOperationException();
            }

            Balance -= amount;
            BonusPoints -= CalculateBonusPoints(amount);
        }

        public void CloseAccount()
        {
            if (Balance < 0)
            {
                throw new InvalidOperationException($"The current balance is {Balance}. You can not close account with negative balance.");
            }

            IsOponed = false;
        }

        protected abstract int CalculateBonusPoints(decimal amount);

        protected abstract bool IsAllowedToWithdraw(decimal amount);
    }
}
