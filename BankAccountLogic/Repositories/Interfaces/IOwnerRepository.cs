using System;

namespace BankAccountLogic.Repositories.Interfaces
{
    public interface IOwnerRepository : IRepository <Owner>
    {        
        Owner GetByPassportNumber(string passportNumber);
        Owner GetByPassportNumber(string passportNumber, StringComparison stringComparison);
    }
}
