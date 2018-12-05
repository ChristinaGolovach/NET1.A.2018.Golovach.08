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
        }

        public void Update(Owner owner)
        {
            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentNullException($"The {nameof(owner)} can not be null.");
            }

            Owner ownerForUpdate = owners.FirstOrDefault(x => x.PassportNumber == owner.PassportNumber);

            ownerForUpdate.FirstName = owner.FirstName;
            ownerForUpdate.LastName = owner.LastName;
            ownerForUpdate.Email = owner.Email;           
        }

        public IEnumerable<Owner> GetAll()
        {
            return owners;
        }

        //TODO изменить сигнатуру метода, сделать чтобы можно было указывать как сравнивать номера паспорта
        public Owner GetByPassportNumber(string passportNumber)
        {
            if (ReferenceEquals(passportNumber, null))
            {
                throw new ArgumentNullException($"The {nameof(passportNumber)} can not be null.");
            }

            return owners.FirstOrDefault(x => x.PassportNumber.Equals(passportNumber, StringComparison.OrdinalIgnoreCase));
        }        
    }
}
