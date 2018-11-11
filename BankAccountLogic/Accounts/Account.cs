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
       // private int balanceCoefficient;
       // private int depositCoefficient;
        private bool isOpened;
        private Owner owner;

        public string Number
        {
            get => number;
            private set => number = value ?? throw new ArgumentNullException($"");
        }

        public bool IsOponed
        {
            get => isOpened;

            private set => isOpened = value;
        }

        public decimal Balance
        {
            get => balance;

            internal protected set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentException($"The value for {nameof(Balance)} must be positive.");
                //}
                balance = value;
            }
        }

        public int BonusPoints
        {
            get => bonusPoints;

            private set => bonusPoints = value;
        }

        public Owner Owner
        {
            get => owner;

            internal protected set => owner = value;
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
            // добавить - Проверка на то, можно ли снять больше чем тек баланс
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
                throw new InvalidOperationException($"The current balance {Balance}. You can not close account with negative balance.");
            }
            IsOponed = false;
        }

        protected abstract int CalculateBonusPoints(decimal money);

        protected abstract bool IsAllowedToWithdraw(decimal money);
    }
}
