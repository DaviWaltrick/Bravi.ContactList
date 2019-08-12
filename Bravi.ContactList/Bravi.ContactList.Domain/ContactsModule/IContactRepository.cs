using Bravi.ContactList.Domain.Common;
using System.Collections.Generic;

namespace Bravi.ContactList.Domain.ContactsModule
{
    public interface IContactRepository : ICRUDRepository<Contact>
    {
        IEnumerable<Contact> RetrieveContactsByPersonID(int personID);
    }
}
