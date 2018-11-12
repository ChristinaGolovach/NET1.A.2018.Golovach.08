using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLogic.Repositories.Interfaces
{
    interface IOwnerRepository : IRepository <Owner>
    {
        Owner GetByPassportNumber(string passportNUmber);
    }
}
