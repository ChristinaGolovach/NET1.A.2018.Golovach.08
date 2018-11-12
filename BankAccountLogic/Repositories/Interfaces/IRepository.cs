using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLogic.Repositories.Interfaces
{
    interface IRepository<T>
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        IEnumerable<T> GetAll();
    }
}
