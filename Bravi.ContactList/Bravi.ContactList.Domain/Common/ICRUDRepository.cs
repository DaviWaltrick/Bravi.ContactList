using System.Collections.Generic;

namespace Bravi.ContactList.Domain.Common
{
    public interface ICRUDRepository<T> 
    {
        IEnumerable<T> RetrieveAll();
        T RetrieveByID(int id);
        void Add(T objectToAdd);
        void Update(T objectToUpdate);
        void Delete(T objectToDelete);
    }
}
