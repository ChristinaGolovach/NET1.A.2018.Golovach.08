using System;
using System.Linq;
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
            Owner existingOwner = ownerRepository.GetByPassportNumber(passportNumber);

            if (!ReferenceEquals(existingOwner, null))
            {
                if (existingOwner.FirstName.Equals(firstName, StringComparison.CurrentCultureIgnoreCase) && (existingOwner.LastName.Equals(lastName, StringComparison.CurrentCultureIgnoreCase))) 
                {
                    return existingOwner;
                }

                throw new InvalidOperationException($"The owner with passport number {passportNumber} already exists.");
            }

            Owner owner = new Owner(passportNumber.ToUpperInvariant(), firstName, lastName, email);

            ownerRepository.Add(owner);

            return owner;
        }

        public void OpenNewAccount(Owner owner, Account account)
        {
            // TODO ASK это можно напрямую так, ілі создать в репозіторіі перегруженную версію Update, и уже в методе обновления вызывать OpenAccount
            owner.OpenAccount(account);
        }

        public Owner FindByPassport(string passportNumber)
        {
            return ownerRepository.GetByPassportNumber(passportNumber);
        }

    }
}
