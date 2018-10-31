using System;

namespace BankAccountLogic
{
    public abstract class AccountCreator
    {
        private int balanceCoefficient;
        private int depositCoefficient;

        public int BalanceCoefficient
        {
            get => balanceCoefficient;

            protected set
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

            protected set
            {
                if (value <= 0)
                {
                    throw new ArithmeticException($"The value of {nameof(depositCoefficient)} must be more than zero.");
                }
                depositCoefficient = value;
            }
        }

        public AccountCreator(int balanceCoefficient, int depositCoefficient)
        {
            BalanceCoefficient = balanceCoefficient;
            DepositCoefficient = depositCoefficient;
        }

        internal abstract Account CreateAccount(Owner owner, decimal initialBalance = 0M);
    }
}
