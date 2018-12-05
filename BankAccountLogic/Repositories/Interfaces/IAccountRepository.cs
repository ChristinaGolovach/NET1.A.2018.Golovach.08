using System;

namespace BankAccountLogic.Repositories.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByNumber(string number);
        Account GetByNumber(string number, StringComparison stringComparison);
        
    }
}
