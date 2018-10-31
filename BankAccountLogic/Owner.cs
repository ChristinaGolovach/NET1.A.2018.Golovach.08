using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLogic
{
    public class Owner
    {
        private List<Account> accounts = new List<Account>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string DateOfBirth { get; set; }
        public List<Account> Accouns { get => accounts; }

        public Owner(string firstName, string lastdName, string passportNumber, string dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastdName;
            PassportNumber = passportNumber;
            DateOfBirth = dateOfBirth;
        }

    }
}
