using Bravi.ContactList.API.Models;
using Bravi.ContactList.Application;
using Bravi.ContactList.Domain.ContactsModule;
using Bravi.ContactList.Domain.PersonsModule;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public IEnumerable<PersonModel> Get()
        {
            return _peopleService.GetAllPeople().Select(p => ModelConverter.GetPersonModel(p));
        }

        // GET: api/People/5
        [HttpGet("{personID}", Name = "Get")]
        public PersonModel Get(int personID)
        {
            Person person = _peopleService.GetPersonByID(personID);

            if (person == null)
                NotFound();

            return ModelConverter.GetPersonModel(person);
        }

        // POST: api/People
        [HttpPost]
        public void Post([FromBody] PersonModel person)
        {
            _peopleService.AddPerson(ModelConverter.GetPerson(person));
        }

        // PUT: api/People/5
        [HttpPut("{personID}")]
        public void Put(int personID, [FromBody] PersonModel person)
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
        public IEnumerable<ContactModel> GetContacts(int personID)
        {
            return _contactsService.GetContactsByPersonID(personID).Select(c => ModelConverter.GetContactModel(c));
        }

        // POST: api/People/5/Contacts
        [HttpPost("{personID}/Contacts")]
        public void PostContact(int personID, [FromBody] ContactModel contact)
        {
            Contact contactToAdd = ModelConverter.GetContact(contact);
            contactToAdd.Person = new Person { PersonID = personID };

            _contactsService.AddContact(contactToAdd);
        }

        // PUT: api/People/5
        [HttpPut("{personID}/Contacts/{contactID}")]
        public void Put(int personID, int contactID, [FromBody] ContactModel contact)
        {
            Contact contactToAdd = ModelConverter.GetContact(contact);
            contactToAdd.Person = new Person { PersonID = personID };
            contactToAdd.ContactID = contactID;

            _contactsService.UpdateContact(contactToAdd);
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
