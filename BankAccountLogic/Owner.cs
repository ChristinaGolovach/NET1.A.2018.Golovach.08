using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLogic
{
    public class Owner
    {
        //TODO добавить валидацию
        private List<Account> accounts;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string Email { get; set; }

        //TODO (when use LIST) это нормально еслі напрямую у этого св-ва вызывать Add, или нужно спец метод доватить для киента.
        //И кто должен проверять, что не добавили один и тот же счет для клиента два раза. Здесь или сервис.

        public IEnumerable<Account> Accouns { get => accounts; }

        public Owner(string firstName, string lastdName, string passportNumber, string email)
        {
            FirstName = firstName;
            LastName = lastdName;
            PassportNumber = passportNumber;
            Email = email;
            accounts = new List<Account>();
        }

    }
}
