using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLogic
{
    public abstract class Account
    {
        private static int id;

        private bool isOpened;
        private int number;
        private decimal balance;
        private int bonusPoints;
        private int balanceCoefficient;
        private int depositCoefficient;
        private Owner owner;

        public bool IsOponed
        {
            get => isOpened;

            internal protected set => isOpened = value;
        }

        public int Number
        {
            get => number;
        }

        public decimal Balance
        {
            get => balance;

            internal protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"The value for {nameof(Balance)} must be positive.");
                }
                balance = value;
            }
        }

        public int BonusPoints
        {
            get => bonusPoints;

            internal protected set => bonusPoints = value;
        }

        public Owner Owner
        {
            get => owner;

            internal protected set => owner = value;
        }

        public int BalanceCoefficient
        {
            get => balanceCoefficient;

            internal protected set
            {
                if (value <= 0)
                {
                    throw new ArithmeticException($"The value of {nameof(balanceCoefficient)} must be more than zero.");
                }
                balanceCoefficient = value;
            }
        }
                    
        public int DepositCoefficient
        {
            get => depositCoefficient;

            internal protected set
            {
                if (value <= 0)
                {
                    throw new ArithmeticException($"The value of {nameof(depositCoefficient)} must be more than zero.");
                }
                depositCoefficient = value;
            }
        }

        static Account()
        {
            id = 1;
        }

        public Account(int balanceCoefficient, int depositCoefficient, Owner owner, decimal initialBalance)
        {
            IsOponed = true;
            number = id++;
            BalanceCoefficient = balanceCoefficient;
            DepositCoefficient = depositCoefficient;
            Owner = owner;
            Balance = initialBalance;
        }

        // стремно???
        //Делать абстрактным  - шаблонный метод
        public virtual void PutMoney(decimal money)
        {
            Balance += money;
        }

        public virtual void TakeMoney(decimal money)
        {
            if (Balance < money)
            {
                throw new ArgumentException($"The count of {nameof(money)} for withdrawing must be less than {Balance}.");
            }

            Balance -= money;
        }

        public void CloseAccount()
        {
            IsOponed = false;
        }
    }
}
