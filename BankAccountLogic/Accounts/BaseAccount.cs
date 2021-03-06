﻿using BankAccountLogic.Accounts.Utils;

namespace BankAccountLogic
{
    internal class BaseAccount : Account
    {
        //хранить здесь коэф. в каждом классе и не передавать из вне.
        // но если их требуется изменить ?????
        private const decimal BALANSECOST = 0.1M;
        private const decimal AMAUNTCOST = 0.1M;
        private const decimal ALLOWEDBALANCEMINUS = -100M;

        public BaseAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base (accountNumber, owner, initialBalance)
        {

        }

        protected override int CalculateBonusPoints(decimal amount)
        {
            return AccountUtils.CalculateBonusPoints(BALANSECOST, Balance, AMAUNTCOST, amount);
        }

        protected override bool IsAllowedToWithdraw(decimal amount)
        {
            return AccountUtils.IsAllowedToWithdraw(ALLOWEDBALANCEMINUS, Balance, amount);
        }
    }
}
