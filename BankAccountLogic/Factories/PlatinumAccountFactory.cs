namespace BankAccountLogic.Factories
{
    public class PlatinumAccountFactory : AccountFactory
    {
        public PlatinumAccountFactory(int balanceCoefficient, int depositCoefficient) : base(balanceCoefficient, depositCoefficient) { }

        internal override Account CreateAccount(Owner owner, decimal initialBalance)
        {
            return new PlatinumAccount(BalanceCoefficient, DepositCoefficient, owner, initialBalance);
        }
    }
}
