using System;

namespace BankAccountLogic.Factories
{
    public abstract class AccountFactory
    {       
        internal abstract Account CreateAccount(string accountNumber, Owner owner, decimal initialBalance = 0M);
    }
}
