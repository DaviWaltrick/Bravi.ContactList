using Bravi.ContactList.Domain.ContactsModule;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bravi.ContactList.Infrastructure.Data.EF.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactListContext _dbContext;

        public ContactRepository(ContactListContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Contact contactToAdd)
        {
            _dbContext.Contacts.Add(contactToAdd);
            _dbContext.SaveChanges();
        }

        public void Delete(Contact contactToDelete)
        {
            if (_dbContext.Entry(contactToDelete).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                _dbContext.Attach(contactToDelete);

            _dbContext.Remove(contactToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Contact> RetrieveContactsByPersonID(int personID)
        {
            return _dbContext.Contacts.Include(c => c.Person).Where(c => c.Person.PersonID == personID);
        }

        public IEnumerable<Contact> RetrieveAll()
        {
            return _dbContext.Contacts;
        }

        public Contact RetrieveByID(int contactID)
        {
            return _dbContext.Contacts.Where(c => c.ContactID == contactID).FirstOrDefault();
        }

        public void Update(Contact contactToUpdate)
        {
            _dbContext.Entry(contactToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.Attach(contactToUpdate.Person);
            _dbContext.SaveChanges();
        }
    }
}
