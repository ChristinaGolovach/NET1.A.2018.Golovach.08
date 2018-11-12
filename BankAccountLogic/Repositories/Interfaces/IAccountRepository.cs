namespace BankAccountLogic.Repositories.Interfaces
{
    interface IAccountRepository : IRepository<Account>
    {
        Account GetByNumber(string number);
    }
}
