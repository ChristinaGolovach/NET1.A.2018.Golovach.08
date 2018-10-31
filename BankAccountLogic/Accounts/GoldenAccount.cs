namespace BankAccountLogic
{
    internal class GoldenAccount : Account
    {
        public GoldenAccount(int balanceCoefficient, int depositCoefficient, Owner owner, decimal initialBalance) 
            : base (balanceCoefficient, depositCoefficient, owner, initialBalance) { }


        public override void PutMoney(decimal money)
        {
            base.PutMoney(money);
            this.BonusPoints += BalanceCoefficient * 3;
        }

        public override void TakeMoney(decimal money)
        {
            base.TakeMoney(money);
            this.BonusPoints -= DepositCoefficient;
        }
    }
}
