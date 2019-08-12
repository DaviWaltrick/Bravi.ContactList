using Bravi.ContactList.Domain.ContactsModule;
using Bravi.ContactList.Domain.PersonsModule;
using System.Collections.Generic;

namespace Bravi.ContactList.Application
{
    public interface IPeopleService
    {
        IEnumerable<Person> GetAllPeople();
        void AddPerson(Person personToAdd);
        void UpdatePerson(Person personToUpdate);
        void DeletePerson(Person personTodelete);
        Person GetPersonByID(int personID);
    }
}
