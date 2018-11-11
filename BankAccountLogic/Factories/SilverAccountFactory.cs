namespace BankAccountLogic.Factories
{
    public class SilverAccountFactory : AccountFactory
    {
        public SilverAccountFactory(int balanceCoefficient, int depositCoefficient) : base(balanceCoefficient, depositCoefficient) { }

        internal override Account CreateAccount(Owner owner, decimal initialBalance)
        {
            return new SilverAccount(BalanceCoefficient, DepositCoefficient, owner, initialBalance);
        }
    }
}
