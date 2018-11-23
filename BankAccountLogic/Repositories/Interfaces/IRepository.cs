using System.Collections.Generic;

namespace BankAccountLogic.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        IEnumerable<T> GetAll();
    }
}
