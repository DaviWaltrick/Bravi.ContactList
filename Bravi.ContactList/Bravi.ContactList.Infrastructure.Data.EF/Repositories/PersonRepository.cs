using Bravi.ContactList.Domain.PersonsModule;
using System;
using System.Collections.Generic;

namespace Bravi.ContactList.Infrastructure.Data.EF.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ContactListContext _dbContext;

        public PersonRepository(ContactListContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Person contactToAdd)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person contactToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public Person RetrieveByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Person contactToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
