namespace BankAccountLogic.Creators
{
    public class SilverAccountCreator : AccountCreator
    {
        public SilverAccountCreator(int balanceCoefficient, int depositCoefficient) : base(balanceCoefficient, depositCoefficient) { }

        internal override Account CreateAccount(Owner owner, decimal initialBalance)
        {
            return new SilverAccount(BalanceCoefficient, DepositCoefficient, owner, initialBalance);
        }
    }
}
