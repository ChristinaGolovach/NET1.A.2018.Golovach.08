namespace BankAccountLogic.Factories
{
    public class GoldenAccountFactory : AccountFactory
    {
        public GoldenAccountFactory(int balanceCoefficient, int depositCoefficient) : base(balanceCoefficient, depositCoefficient) { }

        internal override Account CreateAccount(Owner owner, decimal initialBalance)
        {
            return new GoldenAccount(BalanceCoefficient, DepositCoefficient, owner, initialBalance);
        }
    }
}
