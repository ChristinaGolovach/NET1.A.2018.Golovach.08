using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLogic
{
    public abstract class Account
    {
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

        public void Deposit(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException($"The count of {nameof(money)} must be more than zero for this operation.");
            }

            Balance += money;
            BonusPoints -= CalculateBonusPoints(money);
        }

        public void Withdraw(decimal money)
        {            
            if (!IsAllowedToWithdraw(money))
            {
                // верное ли исключение??
                throw new InvalidOperationException();
            }

            Balance -= money;
            BonusPoints -= CalculateBonusPoints(money);
        }

        public void CloseAccount()
        {
            if (Balance < 0)
            {
                throw new InvalidOperationException($"The current balance is {Balance}. You can not close account with negative balance.");
            }

            IsOponed = false;
        }

        protected abstract int CalculateBonusPoints(decimal money);

        protected abstract bool IsAllowedToWithdraw(decimal money);
    }
}
