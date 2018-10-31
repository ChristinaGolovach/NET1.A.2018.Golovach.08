namespace BankAccountLogic.Creators
{
    public class PlatinumAccountCreator : AccountCreator
    {
        public PlatinumAccountCreator(int balanceCoefficient, int depositCoefficient) : base(balanceCoefficient, depositCoefficient) { }

        internal override Account CreateAccount(Owner owner, decimal initialBalance)
        {
            return new PlatinumAccount(BalanceCoefficient, DepositCoefficient, owner, initialBalance);
        }
    }
}
