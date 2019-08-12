using Bravi.ContactList.Domain.PersonsModule;
using System;

namespace Bravi.ContactList.Domain.ContactsModule
{
    public abstract class Contact
    {
        public int ContactID { get; set; }
        public Person Person { get; set; }
        public string Name { get; set; }

        public virtual void CopyTo(Contact copyTarget)
        {
            if (copyTarget == null)
                throw new ArgumentNullException(nameof(copyTarget));

            if (copyTarget.GetType() != GetType())
                throw new ArgumentException("Copy origin and copy target must be of the same type.");

            copyTarget.Person = Person;
            copyTarget.Name = Name;
        }
    }
}
