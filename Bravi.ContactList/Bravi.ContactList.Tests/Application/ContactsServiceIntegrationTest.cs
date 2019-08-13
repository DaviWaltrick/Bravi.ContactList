using Bravi.ContactList.Application;
using Bravi.ContactList.Domain.ContactsModule;
using Bravi.ContactList.Domain.PersonsModule;
using Bravi.ContactList.Infrastructure.Data.EF;
using Bravi.ContactList.Infrastructure.Data.EF.Repositories;

using FluentAssertions;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;

namespace Bravi.ContactList.Tests.Application
{
    [TestClass]
    public class ContactsServiceIntegrationTest
    {
        private IContactsService _contactsService;

        private IPersonRepository _personRepository;
        private IContactRepository _contactRepository;

        private ContactListContext _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<ContactListContext>()
                                .UseInMemoryDatabase(databaseName: "inMemoryDb")
                                .Options;

            _dbContext = new ContactListContext(options);

            _personRepository = new PersonRepository(_dbContext);
            _contactRepository = new ContactRepository(_dbContext);

            _contactsService = new ContactsService(_contactRepository, _personRepository);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public void AddContact_Should_Add_PhoneContact_To_Database()
        {
            Person personOnDb = new Person { Name = "name" };

            _personRepository.Add(personOnDb);

            PhoneContact contact = new PhoneContact { Person = personOnDb, Name = "home", PhoneNumber = "0000-0000" };

            _contactsService.AddContact(contact);

            IEnumerable<Contact> contactsOnDb = _contactRepository.RetrieveAll();

            contactsOnDb.Should().HaveCount(1);
            contactsOnDb.First().Should().BeOfType<PhoneContact>();
            contactsOnDb.First().As<PhoneContact>().PhoneNumber.Should().Be(contact.PhoneNumber);
            contactsOnDb.First().Name.Should().Be(contact.Name);
            contactsOnDb.First().Person.Name.Should().Be(contact.Person.Name);
        }

        [TestMethod]
        public void AddContact_Should_Add_EmailContact_To_Database()
        {
            Person personOnDb = new Person { Name = "name" };

            _personRepository.Add(personOnDb);

            EmailContact contact = new EmailContact { Person = personOnDb, Name = "home", Address = "test@test.com" };

            _contactsService.AddContact(contact);

            IEnumerable<Contact> contactsOnDb = _contactRepository.RetrieveAll();

            contactsOnDb.Should().HaveCount(1);
            contactsOnDb.First().Should().BeOfType<EmailContact>();
            contactsOnDb.First().As<EmailContact>().Address.Should().Be(contact.Address);
            contactsOnDb.First().Name.Should().Be(contact.Name);
            contactsOnDb.First().Person.Name.Should().Be(contact.Person.Name);
        }

        [TestMethod]
        public void AddContact_Should_Add_WhatsAppContact_To_Database()
        {
            Person personOnDb = new Person { Name = "name" };

            _personRepository.Add(personOnDb);

            WhatsAppContact contact = new WhatsAppContact { Person = personOnDb, Name = "home", WhatsAppNumber = "0000-0000" };

            _contactsService.AddContact(contact);

            IEnumerable<Contact> contactsOnDb = _contactRepository.RetrieveAll();

            contactsOnDb.Should().HaveCount(1);
            contactsOnDb.First().Should().BeOfType<WhatsAppContact>();
            contactsOnDb.First().As<WhatsAppContact>().WhatsAppNumber.Should().Be(contact.WhatsAppNumber);
            contactsOnDb.First().Name.Should().Be(contact.Name);
            contactsOnDb.First().Person.Name.Should().Be(contact.Person.Name);
        }

        [TestMethod]
        public void DeleteContact_Should_Remove_Contact_From_Database_But_Keep_Person()
        {
            WhatsAppContact contactOnDb = new WhatsAppContact { Person = new Person { Name = "name" }, Name = "home", WhatsAppNumber = "0000-0000" };
            _contactRepository.Add(contactOnDb);

            _contactsService.DeleteContact(contactOnDb);

            IEnumerable<Contact> contactsOnDb = _contactRepository.RetrieveAll();
            IEnumerable<Person> personOnDb = _personRepository.RetrieveAll();

            contactsOnDb.Should().BeEmpty();
            personOnDb.Should().HaveCount(1);
        }

        [TestMethod]
        public void UpdateContact_Should_Retrieve_And_Update_Contact_On_Database()
        {
            WhatsAppContact contactOnDb = new WhatsAppContact { Person = new Person { Name = "name" }, Name = "home", WhatsAppNumber = "0000-0000" };
            _contactRepository.Add(contactOnDb);

            WhatsAppContact updatedContact = new WhatsAppContact { Person = contactOnDb.Person, ContactID = contactOnDb.ContactID, Name = "updatedName", WhatsAppNumber = "1111-1111" };

            _contactsService.UpdateContact(updatedContact);

            IEnumerable<Contact> contactsOnDb = _contactRepository.RetrieveAll();

            contactsOnDb.Should().HaveCount(1);
            contactsOnDb.First().Should().BeOfType<WhatsAppContact>();
            contactsOnDb.First().As<WhatsAppContact>().WhatsAppNumber.Should().Be(updatedContact.WhatsAppNumber);
            contactsOnDb.First().Name.Should().Be(updatedContact.Name);
        }

        [TestMethod]
        public void GetContactByID_Should_Retrieve_Contact_With_Matching_ContactID_From_Database()
        {
            WhatsAppContact contactOnDb = new WhatsAppContact { Person = new Person { Name = "name" }, Name = "home", WhatsAppNumber = "0000-0000" };
            _contactRepository.Add(contactOnDb);

            Contact retrievedContact = _contactsService.GetContactByID(contactOnDb.ContactID);

            retrievedContact.ContactID.Should().Be(contactOnDb.ContactID);
        }

        [TestMethod]
        public void GetContact_Should_Retrieve_Contact_With_Matching_ContactID_From_Database()
        {
            WhatsAppContact wppContactOnDb = new WhatsAppContact { Person = new Person { Name = "name" }, Name = "home", WhatsAppNumber = "0000-0000" };
            _contactRepository.Add(wppContactOnDb);

            EmailContact emailContactOnDb = new EmailContact { Person = wppContactOnDb.Person, Name = "home", Address = "test@test.com" };
            _contactRepository.Add(emailContactOnDb);
            
            IEnumerable<Contact> retrievedContacts = _contactsService.GetContactsByPersonID(wppContactOnDb.Person.PersonID);

            retrievedContacts.Should().HaveCount(2);
        }
    }
}
