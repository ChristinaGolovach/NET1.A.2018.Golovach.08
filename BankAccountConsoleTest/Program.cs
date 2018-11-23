using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLogic;
using BankAccountLogic.Factories;
using BankAccountLogic.Repositories.Fakes;
using BankAccountLogic.NumberGenerator;

namespace BankAccountConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OwnerService ownerService = new OwnerService(new OwnerRepository());
            AccountService accountService = new AccountService(new AccountRepository(), ownerService, new AccountNumberGenerator());

            string baseNumberAccount = accountService.CreateAccount(new BaseAccountFactory(), "KB147147", "UserFirstName", "UserLastName", "email", 147);
            string baseNumberAccount2 = accountService.CreateAccount(new BaseAccountFactory(), "Kb147147", 17777);

            accountService.CloseAccount(baseNumberAccount);

        }
    }
}
