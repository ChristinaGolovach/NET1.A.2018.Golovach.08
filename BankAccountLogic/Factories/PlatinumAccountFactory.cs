namespace BankAccountLogic.Factories
{
    public class PlatinumAccountFactory : AccountFactory
    {
        internal override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new PlatinumAccount(accountNumber, owner, initialBalance);
        }
    }
}
