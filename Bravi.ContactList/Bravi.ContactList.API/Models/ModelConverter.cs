using Bravi.ContactList.Domain.ContactsModule;
using Bravi.ContactList.Domain.PersonsModule;
using System;
using System.ComponentModel;
using System.Linq;

namespace Bravi.ContactList.API.Models
{
    public class ModelConverter
    {
        public static Person GetPerson(PersonModel personModel)
        {
            return new Person { Name = personModel.Name };
        }

        public static PersonModel GetPersonModel(Person person)
        {
            PersonModel personModel = new PersonModel { Name = person.Name, PersonId = person.PersonID };

            if (person.Contacts != null && person.Contacts.Count > 0)
                personModel.contacts = person.Contacts.Select(c => GetContactModel(c));

            return personModel;
        }

        public static Contact GetContact(ContactModel contactModel)
        {
            switch (contactModel.Type)
            {
                case ContactModelType.Email:
                    return new EmailContact { Address = contactModel.ContactData, Name = contactModel.Name };
                case ContactModelType.WhatsApp:
                    return new WhatsAppContact { WhatsAppNumber = contactModel.ContactData, Name = contactModel.Name };
                case ContactModelType.Phone:
                    return new PhoneContact { PhoneNumber = contactModel.ContactData, Name = contactModel.Name };
                default:
                    throw new InvalidEnumArgumentException(nameof(contactModel), contactModel.Type.GetHashCode(), typeof(ContactModelType));
            }
        }

        public static ContactModel GetContactModel(Contact contact)
        {
            Type contactType = contact.GetType();

            ContactModel contactModel = new ContactModel { Name = contact.Name, ContactId = contact.ContactID };

            if (contactType == typeof(EmailContact))
            {
                contactModel.Type = ContactModelType.Email;
                contactModel.ContactData = ((EmailContact)contact).Address;
            }
            else if (contactType == typeof(WhatsAppContact))
            {
                contactModel.Type = ContactModelType.WhatsApp;
                contactModel.ContactData = ((WhatsAppContact)contact).WhatsAppNumber;
            }
            else if (contactType == typeof(PhoneContact))
            {
                contactModel.Type = ContactModelType.Phone;
                contactModel.ContactData = ((PhoneContact)contact).PhoneNumber;
            }

            return contactModel;
        }
    }
}
