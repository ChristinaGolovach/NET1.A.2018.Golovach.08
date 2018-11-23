using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLogic.Repositories.Interfaces;

namespace BankAccountLogic.Repositories.Fakes
{
    public class AccountRepository : IAccountRepository
    {
        private List<Account> accounts;

        public AccountRepository()
        {
            accounts = new List<Account>();
        }

        public void Add(Account account)
        {
            accounts.Add(account);
        }

        public void Delete(Account account)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAll()
        {
            return accounts;
        }

        public Account GetByNumber(string number)
        {
            //TODO EQUALS ??
           return accounts.FirstOrDefault(x => x.Number == number);
        }
    }
}
