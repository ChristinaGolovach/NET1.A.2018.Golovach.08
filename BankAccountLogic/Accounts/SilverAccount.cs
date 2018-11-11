using BankAccountLogic.Accounts.Utils;

namespace BankAccountLogic
{
    internal class SilverAccount : Account
    {
        private const decimal BALANSECOST = 0.2M;
        private const decimal AMAUNTCOST = 0.2M;
        private const decimal ALLOWEDBALANCEMINUS = -200M;

        public SilverAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base (accountNumber, owner, initialBalance)
        {

        }

        protected override int CalculateBonusPoints(decimal money)
        {
            return AccountUtils.CalculateBonusPoints(BALANSECOST, Balance, AMAUNTCOST, money);
        }

        protected override bool IsAllowedToWithdraw(decimal money)
        {
            return AccountUtils.IsAllowedToWithdraw(ALLOWEDBALANCEMINUS, Balance, money);
        }
    }
}
