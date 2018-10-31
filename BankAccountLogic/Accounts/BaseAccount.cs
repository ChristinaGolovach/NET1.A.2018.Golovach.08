namespace BankAccountLogic
{
    internal class BaseAccount : Account
    {      
        public BaseAccount(int balanceCoefficient, int depositCoefficient, Owner owner, decimal initialBalance) 
            : base (balanceCoefficient, depositCoefficient, owner, initialBalance) { }

        
        public override void PutMoney(decimal money)
        {
            base.PutMoney(money);
            this.BonusPoints += BalanceCoefficient;
        }

        public override void TakeMoney(decimal money)
        {
            base.TakeMoney(money);
            this.BonusPoints -=  DepositCoefficient*3;
        }
    }
}
