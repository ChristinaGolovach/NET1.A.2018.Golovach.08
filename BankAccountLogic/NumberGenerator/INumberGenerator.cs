using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLogic.NumberGenerator
{
    interface INumberGenerator
    {
        string GenerateNumber(int numberLength);
    }
}
