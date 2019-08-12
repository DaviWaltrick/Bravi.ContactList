using Bravi.ContactList.Domain.PersonsModule;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bravi.ContactList.Infrastructure.Data.EF.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ContactListContext _dbContext;

        public PersonRepository(ContactListContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Person personToAdd)
        {
            _dbContext.People.Add(personToAdd);
            _dbContext.SaveChanges();
        }

        public void Delete(Person personToDelete)
        {
            if (_dbContext.Entry(personToDelete).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                _dbContext.Attach(personToDelete);

            _dbContext.Remove(personToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Person> RetrieveAll()
        {
            return _dbContext.People.Include(p => p.Contacts);
        }

        public Person RetrieveByID(int personID)
        {
            return _dbContext.People.Include(p => p.Contacts).Where(p => p.PersonID == personID).FirstOrDefault();
        }

        public void Update(Person personToUpdate)
        {
            if (_dbContext.Entry(personToUpdate).State != Microsoft.EntityFrameworkCore.EntityState.Detached)
            {
                _dbContext.Update(personToUpdate);
            }
            else
            {
                _dbContext.Attach(personToUpdate);
                _dbContext.Entry(personToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }
    }
}
