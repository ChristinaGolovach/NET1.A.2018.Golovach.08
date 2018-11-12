using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLogic.Repositories.Interfaces;

namespace BankAccountLogic.Repositories.Fakes
{
    public class OwnerRepository : IOwnerRepository
    {
        private List<Owner> owners;

        public OwnerRepository()
        {
            owners = new List<Owner>();
        }

        //TODO здесь же не нужно проверять на дублікат, это же не ответсвенность этого класса?  
        public void Add(Owner owner)
        {
            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
            }

            owners.Add(owner);
        }

        public void Delete(Owner owner)
        {
            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
            }
            //TODO а еслі такого владельца нет, опять же это здесь чекать или можно просто remove?
            Owner ownerForDelete = owners.FirstOrDefault(x => x.PassportNumber == owner.PassportNumber);

            if (!ReferenceEquals(ownerForDelete, null))
            {
                owners.Remove(owner);
            }               
        }

        public void Update(Owner owner)
        {
            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
            }

            //TODO а если как раз-таки паспорт номер изменился???
            Owner ownerForUpdate = owners.FirstOrDefault(x => x.PassportNumber == owner.PassportNumber);
            if (!ReferenceEquals(owner, null))
            {
                ownerForUpdate.FirstName = owner.FirstName;
                ownerForUpdate.LastName = owner.LastName;
                ownerForUpdate.Email = owner.Email;
            }
        }

        public IEnumerable<Owner> GetAll()
        {
            return owners;
        }

        public Owner GetByPassportNumber(string passportNumber)
        {
            if (ReferenceEquals(passportNumber, null))
            {
                throw new ArgumentNullException($"The {nameof(passportNumber)} can not be null.");
            }

           return owners.FirstOrDefault(x => x.PassportNumber == passportNumber);
        }        
    }
}
