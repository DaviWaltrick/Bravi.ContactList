using System;
using System.ComponentModel.DataAnnotations;

namespace Bravi.ContactList.Domain.ContactsModule
{
    public class EmailContact : Contact
    {
        private string address;

        public string Address
        {
            get => address;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Address));

                if (!new EmailAddressAttribute().IsValid(value))
                    throw new ArgumentException($"'{value}' is not a valid email!");

                address = value;
            }
        }

        public override void CopyTo(Contact copyTarget)
        {
            base.CopyTo(copyTarget);
            ((EmailContact)copyTarget).Address = Address;
        }
    }
}
