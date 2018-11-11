namespace BankAccountLogic.Factories
{
    public class BaseAccountFactory : AccountFactory
    {
        public BaseAccountFactory(int balanceCoefficient, int depositCoefficient) : base (balanceCoefficient, depositCoefficient) { }

        internal override Account CreateAccount(Owner owner, decimal initialBalance)
        {
            return new BaseAccount(BalanceCoefficient, DepositCoefficient, owner, initialBalance);
        }
    }
}
