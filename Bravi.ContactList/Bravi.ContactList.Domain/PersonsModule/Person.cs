using System;
using System.Collections.Generic;
using Bravi.ContactList.Domain.ContactsModule;

namespace Bravi.ContactList.Domain.PersonsModule
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }

        public void CopyTo(Person copyTarget)
        {
            if (copyTarget == null)
                throw new ArgumentNullException(nameof(copyTarget));

            copyTarget.Name = Name;
        }
    }
}
