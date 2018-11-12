using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLogic;
using BankAccountLogic.Factories;

namespace BankAccountConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Owner owner = OwnerService.CreateOwner("Chris", "Golovach", "Pass", "Date");           
            int baseNumberAccount  = AccountService.CreateBankAccount(new BaseAccountFactory(), owner.PassportNumber, 45);
            int coldenNumberAccoun = AccountService.CreateBankAccount(new GoldenAccountFactory(), owner.PassportNumber, 7);
          
            AccountService.PutMoney(baseNumberAccount, owner.PassportNumber, 47);
            AccountService.TakeMoney(baseNumberAccount, owner.PassportNumber, 7);

            ///////////////////////////////////////////////////////

            Owner owner2 = OwnerService.CreateOwner("User2", "User2", "Pass2", "Date");
            int baseNumberAccount2 = AccountService.CreateBankAccount(new BaseAccountFactory(), owner2.PassportNumber, 75);
            int coldenNumberAccoun2 = AccountService.CreateBankAccount(new GoldenAccountFactory(), owner2.PassportNumber, 7);

            AccountService.PutMoney(baseNumberAccount2, owner2.PassportNumber, 7);
            AccountService.TakeMoney(coldenNumberAccoun2, owner2.PassportNumber, 87);

        }
    }
}
