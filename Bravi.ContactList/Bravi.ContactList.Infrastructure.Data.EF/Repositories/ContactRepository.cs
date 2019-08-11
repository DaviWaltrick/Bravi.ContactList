using Bravi.ContactList.Domain.ContactsModule;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public void Delete(Contact contactToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public Contact RetrieveByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact contactToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
