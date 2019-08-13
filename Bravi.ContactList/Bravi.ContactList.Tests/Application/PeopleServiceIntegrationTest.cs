using Bravi.ContactList.Application;
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
    public class PeopleServiceIntegrationTest
    {
        private IPeopleService _peopleService;
        private IPersonRepository _personRepository;
        private ContactListContext _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<ContactListContext>()
                                .UseInMemoryDatabase(databaseName: "inMemoryDb")
                                .Options;

            _dbContext = new ContactListContext(options);
            _personRepository = new PersonRepository(_dbContext);
            _peopleService = new PeopleService(_personRepository);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public void AddPerson_Should_Insert_Person_Into_Database()
        {
            Person person = new Person { Name = "personName" };

            _peopleService.AddPerson(person);

            IEnumerable<Person> personsOnDb = _personRepository.RetrieveAll();

            personsOnDb.Should().HaveCount(1);
            personsOnDb.First().Name.Should().Be(person.Name);
        }

        [TestMethod]
        public void DeletePerson_Should_Delete_Person_From_Database()
        {
            Person person = new Person { Name = "personName" };

            _personRepository.Add(person);

            _peopleService.DeletePerson(person);

            IEnumerable<Person> personsOnDb = _personRepository.RetrieveAll();
            personsOnDb.Should().BeEmpty();
        }
    }
}
