namespace BankAccountLogic
{
    internal class PlatinumAccount : Account
    {
        public PlatinumAccount(int balanceCoefficient, int depositCoefficient, Owner owner, decimal initialBalance) 
            : base (balanceCoefficient, depositCoefficient, owner, initialBalance) { }


        public override void PutMoney(decimal money)
        {
            base.PutMoney(money);
            this.BonusPoints += BalanceCoefficient * 4;
        }

        public override void TakeMoney(decimal money)
        {
            base.TakeMoney(money);
            this.BonusPoints -= DepositCoefficient;
        }
    }
}
