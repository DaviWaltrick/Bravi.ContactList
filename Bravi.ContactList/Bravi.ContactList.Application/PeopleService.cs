using Bravi.ContactList.Domain.PersonsModule;
using System.Collections.Generic;

namespace Bravi.ContactList.Application
{
    public class PeopleService : IPeopleService
    {
        private readonly IPersonRepository _personRepository;

        public PeopleService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void AddPerson(Person personToAdd)
        {
            _personRepository.Add(personToAdd);
        }

        public void DeletePerson(Person personTodelete)
        {
            _personRepository.Delete(personTodelete);
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _personRepository.RetrieveAll();
        }

        public Person GetPersonByID(int personID)
        {
            return _personRepository.RetrieveByID(personID);
        }

        public void UpdatePerson(Person personToUpdate)
        {
            Person personOnDb = _personRepository.RetrieveByID(personToUpdate.PersonID);
            personToUpdate.CopyTo(personOnDb);
            _personRepository.Update(personToUpdate);
        }
    }
}
