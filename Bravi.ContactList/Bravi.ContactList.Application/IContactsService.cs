using Bravi.ContactList.Domain.ContactsModule;
using System.Collections.Generic;

namespace Bravi.ContactList.Application
{
    public interface IContactsService
    {
        Contact GetContactByID(int contactID);
        void AddContact(Contact contactToAdd);
        void DeleteContact(Contact contactToDelete);
        void UpdateContact(Contact contactToUpdate);
        IEnumerable<Contact> GetContactsByPersonID(int personID);
    }
}
