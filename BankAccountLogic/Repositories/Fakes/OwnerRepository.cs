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

            owners.Remove(owner);

            // Owner ownerForDelete = owners.FirstOrDefault(x => x.PassportNumber == owner.PassportNumber);
        }

        public void Update(Owner owner)
        {
            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
            }

            //TODO а если как раз-таки паспорт номер изменился??? ID 
            //это здесь не трекается, это сервер сначала прове6ряет і еслі ок, то отправляет на обновленіе

            Owner ownerForUpdate = owners.FirstOrDefault(x => x.PassportNumber == owner.PassportNumber);

            ownerForUpdate.FirstName = owner.FirstName;
            ownerForUpdate.LastName = owner.LastName;
            ownerForUpdate.Email = owner.Email;           
        }

        public void Update(Owner owner, Account account)
        {
            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
            }

            owner.OpenAccount(account);
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
            //TODO 
           return owners.FirstOrDefault(x => x.PassportNumber == passportNumber);
        }        
    }
}
