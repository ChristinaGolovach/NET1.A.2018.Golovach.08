using System;
using System.Collections.Generic;
using BankAccountLogic.Repositories.Interfaces;

namespace BankAccountLogic
{
    public class OwnerService
    {
        private IEnumerable<Owner> owners;
        private IOwnerRepository ownerRepository;

        public IEnumerable<Owner> Owners
        {
            get => owners;
        }

        public OwnerService(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
            owners = ownerRepository.GetAll();
        }

        public Owner CreateOwner(string passportNumber, string firstName, string lastName, string email)
        {
            string upperPassportNumber = passportNumber.ToUpper();

            Owner existingOwner = ownerRepository.GetByPassportNumber(upperPassportNumber);

            if (!ReferenceEquals(existingOwner, null))
            {
                if (existingOwner.FirstName.Equals(firstName, StringComparison.CurrentCultureIgnoreCase) && (existingOwner.LastName.Equals(lastName, StringComparison.CurrentCultureIgnoreCase))) 
                {
                    return existingOwner;
                }

                throw new InvalidOperationException($"The owner with passport number {passportNumber} already exists.");
            }

            Owner owner = new Owner(upperPassportNumber, firstName, lastName, email);

            ownerRepository.Add(owner);

            return owner;
        }

        public void AddNewAccount(Owner owner, Account account)
        {
            // TODO ASK это можно напрямую так, ілі создать в репозіторіі перегруженную версію Update, и уже в методе обновления вызывать OpenAccount
            owner.OpenAccount(account);
        }

        public Owner FindByPassport(string passportNumber)
        {
            string  upperPassportNumber = passportNumber.ToUpper();

            return ownerRepository.GetByPassportNumber(upperPassportNumber);
        }

       // public 
        
        //public static IEnumerable<Account> TakeOwnerAccounts(string passportNumber)
        //{
        //    Owner owner = FindOwnerByPassport(passportNumber);
        //    return owner.Accouns;
        //}

        //public static Owner FindOwnerByPassport(string passportNumber)
        //{
        //    //Owner owner = Owners.Find(o => o.PassportNumber == passportNumber);

        //    Owner existingOwner = null;

        //    foreach (var owner in Owners)
        //    {
        //        if (owner.PassportNumber == passportNumber)
        //        {
        //            return owner;
        //        }
        //    }

        //    return existingOwner;
        //}

    }
}
