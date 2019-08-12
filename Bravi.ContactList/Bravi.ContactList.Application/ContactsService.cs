using Bravi.ContactList.Domain.ContactsModule;
using Bravi.ContactList.Domain.PersonsModule;
using System;
using System.Collections.Generic;

namespace Bravi.ContactList.Application
{
    public class ContactsService : IContactsService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IPersonRepository _personRepository;

        public ContactsService(IContactRepository contactRepository, IPersonRepository personRepository)
        {
            _contactRepository = contactRepository;
            _personRepository = personRepository;
        }

        public void AddContact(Contact contactToAdd)
        {
            contactToAdd.Person = _personRepository.RetrieveByID(contactToAdd.Person.PersonID);

            if (contactToAdd.Person == null)
                throw new ArgumentException("Person was not found on database.");

            _contactRepository.Add(contactToAdd);
        }

        public void DeleteContact(Contact contactToDelete)
        {
            _contactRepository.Delete(contactToDelete);
        }

        public Contact GetContactByID(int contactID)
        {
            return _contactRepository.RetrieveByID(contactID);
        }

        public IEnumerable<Contact> GetContactsByPersonID(int personID)
        {
            return _contactRepository.RetrieveContactsByPersonID(personID);
        }

        public void UpdateContact(Contact contactToUpdate)
        {
            Contact contactOnDb = _contactRepository.RetrieveByID(contactToUpdate.ContactID);
            contactToUpdate.CopyTo(contactOnDb);

            _contactRepository.Update(contactOnDb);
        }
    }
}
