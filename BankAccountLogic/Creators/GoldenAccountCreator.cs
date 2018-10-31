namespace BankAccountLogic.Creators
{
    public class GoldenAccountCreator : AccountCreator
    {
        public GoldenAccountCreator(int balanceCoefficient, int depositCoefficient) : base(balanceCoefficient, depositCoefficient) { }

        internal override Account CreateAccount(Owner owner, decimal initialBalance)
        {
            return new GoldenAccount(BalanceCoefficient, DepositCoefficient, owner, initialBalance);
        }
    }
}
