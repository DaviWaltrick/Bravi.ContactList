using Bravi.ContactList.Application;
using Bravi.ContactList.Domain.ContactsModule;
using Bravi.ContactList.Domain.PersonsModule;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bravi.ContactList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly IContactsService _contactsService;

        public PeopleController(IPeopleService peopleService, IContactsService contactsService)
        {
            _peopleService = peopleService;
            _contactsService = contactsService;
        }

        #region People
        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _peopleService.GetAllPeople();
        }

        // GET: api/People/5
        [HttpGet("{personID}", Name = "Get")]
        public Person Get(int personID)
        {
            Person person = _peopleService.GetPersonByID(personID);

            if (person == null)
                NotFound();

            return person;
        }

        // POST: api/People
        [HttpPost]
        public void Post([FromBody] Person person)
        {
            _peopleService.AddPerson(person);
        }

        // PUT: api/People/5
        [HttpPut("{personID}")]
        public void Put(int personID, [FromBody] Person person)
        {
            Person personToUpdate = _peopleService.GetPersonByID(personID);

            if (personToUpdate == null)
                NotFound();

            personToUpdate.Name = person.Name;

            _peopleService.UpdatePerson(personToUpdate);
        }

        // DELETE: api/People/5
        [HttpDelete("{personID}")]
        public void Delete(int personID)
        {
            Person personToDelete = _peopleService.GetPersonByID(personID);

            if (personToDelete == null)
                NotFound();

            _peopleService.DeletePerson(personToDelete);
        }
        #endregion

        #region Contacts
        // GET: api/People/5/Contacts
        [HttpGet("{personID}/Contacts", Name = "GetContacts")]
        public IEnumerable<Contact> GetContacts(int personID)
        {
            return _contactsService.GetContactsByPersonID(personID);
        }

        // POST: api/People/5/Contacts
        [HttpPost("{personID}/Contacts")]
        public void PostContact(int personID, [FromBody] Contact contact)
        {
            contact.Person = new Person { PersonID = personID };

            _contactsService.AddContact(contact);
        }

        // PUT: api/People/5
        [HttpPut("{personID}/Contacts/{contactID}")]
        public void Put(int personID, int contactID, [FromBody] Contact contact)
        {
            contact.Person = new Person { PersonID = personID };
            contact.ContactID = contactID;

            _contactsService.UpdateContact(contact);
        }
        
        // PUT: api/People/5
        [HttpDelete("{personID}/Contacts/{contactID}")]
        public void Delete(int personID, int contactID)
        {
            Contact contactToDelete = _contactsService.GetContactByID(contactID);

            _contactsService.DeleteContact(contactToDelete);
        }
        #endregion
    }
}
