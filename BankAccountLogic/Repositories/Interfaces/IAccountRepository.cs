namespace BankAccountLogic.Repositories.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByNumber(string number);
    }
}
