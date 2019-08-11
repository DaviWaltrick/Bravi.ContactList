using Bravi.ContactList.Domain.PersonsModule;

namespace Bravi.ContactList.Domain.ContactsModule
{
    public abstract class Contact
    {
        public int ContactID { get; set; }
        public Person Owner { get; set; }
        public string Name { get; set; }
    }
}
