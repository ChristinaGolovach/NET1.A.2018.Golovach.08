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

            string baseNumberAccount1 = accountService.CreateAccount(new BaseAccountFactory(), "Kb147147", "UserFirstName", "UserLastName", "email", 10);
            string baseNumberAccount2 = accountService.CreateAccount(new BaseAccountFactory(), "KB147147", 7);

           // accountService.CloseAccount(baseNumberAccount1);

            accountService.PutMoney(baseNumberAccount1, 12);
            accountService.PutMoney(baseNumberAccount2, 10);
          //  accountService.TakeMoney(baseNumberAccount2, 4);
        //    accountService.Transfer(baseNumberAccount1, baseNumberAccount2, 3);

        }
    }
}
