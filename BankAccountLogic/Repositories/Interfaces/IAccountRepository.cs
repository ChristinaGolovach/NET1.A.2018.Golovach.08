using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLogic.Repositories.Interfaces
{
    interface IAccountRepository : IRepository<Account>
    {
        Account GetByNumber(string number);
    }
}
