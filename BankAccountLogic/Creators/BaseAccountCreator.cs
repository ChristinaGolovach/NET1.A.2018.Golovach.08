namespace BankAccountLogic.Creators
{
    public class BaseAccountCreator : AccountCreator
    {
        public BaseAccountCreator(int balanceCoefficient, int depositCoefficient) : base (balanceCoefficient, depositCoefficient) { }

        internal override Account CreateAccount(Owner owner, decimal initialBalance)
        {
            return new BaseAccount(BalanceCoefficient, DepositCoefficient, owner, initialBalance);
        }
    }
}
