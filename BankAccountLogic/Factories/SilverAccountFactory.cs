namespace BankAccountLogic.Factories
{
    public class SilverAccountFactory : AccountFactory
    {
        internal override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new SilverAccount(accountNumber, owner, initialBalance);
        }
    }
}
