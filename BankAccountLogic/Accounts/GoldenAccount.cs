using BankAccountLogic.Accounts.Utils;

namespace BankAccountLogic
{
    internal class GoldenAccount : Account
    {
        private const decimal BALANSECOST = 0.3M;
        private const decimal AMAUNTCOST = 0.3M;
        private const decimal ALLOWEDBALANCEMINUS = -300M;

        public GoldenAccount(string accountNumber, Owner owner, decimal initialBalance = 0M) : base (accountNumber, owner, initialBalance)
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
