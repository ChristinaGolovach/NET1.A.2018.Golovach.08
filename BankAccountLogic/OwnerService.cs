using System.Collections.Generic;

namespace BankAccountLogic
{
    public static class OwnerService
    {
        private static List<Owner> owners;

        public static List<Owner> Owners
        {
            get => owners;
        }

        static OwnerService()
        {
            owners = new List<Owner> { };
        }

        public static Owner CreateOwner(string firstName, string lastdName, string passportNumber, string dateOfBirth)
        {
            Owner owner  = new Owner(firstName, lastdName, passportNumber, dateOfBirth);
            Owners.Add(owner);
            return owner;
        }

        public static List<Account> TakeOwnerAccounts(string passportNumber)
        {
            Owner owner = FindOwnerByPassport(passportNumber);
            return owner.Accouns;
        }

        public static Owner FindOwnerByPassport(string passportNumber)
        {
            //Owner owner = Owners.Find(o => o.PassportNumber == passportNumber);

            Owner existingOwner = null;

            foreach (var owner in Owners)
            {
                if (owner.PassportNumber == passportNumber)
                {
                    return owner;
                }
            }

            return existingOwner;
        }

    }
}
