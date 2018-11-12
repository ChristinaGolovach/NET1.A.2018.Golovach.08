namespace BankAccountLogic.Factories
{
    public class BaseAccountFactory : AccountFactory
    {      

        internal override Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M)
        {
            return new BaseAccount(accountNumber, owner, initialBalance);
        }
    }
}
