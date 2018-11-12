namespace BankAccountLogic.Factories
{
    public class GoldenAccountFactory : AccountFactory
    {
        internal override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new GoldenAccount(accountNumber, owner, initialBalance);
        }
    }
}
