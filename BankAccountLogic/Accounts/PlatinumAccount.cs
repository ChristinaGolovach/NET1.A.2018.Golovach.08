﻿using BankAccountLogic.Accounts.Utils;

namespace BankAccountLogic
{
    internal class PlatinumAccount : Account
    {
        private const decimal BALANSECOST = 0.4M;
        private const decimal AMAUNTCOST = 0.4M;
        private const decimal ALLOWEDBALANCEMINUS = -400M;

        public PlatinumAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base (accountNumber, owner, initialBalance)
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
