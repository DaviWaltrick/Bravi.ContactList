using System;
using System.ComponentModel.DataAnnotations;

namespace Bravi.ContactList.Domain.ContactsModule
{
    public class PhoneContact : Contact
    {
        private string number;

        public string PhoneNumber
        {
            get => number;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("PhoneNumber cannot be null or empty.", nameof(PhoneNumber));

                if (!new PhoneAttribute().IsValid(value))
                    throw new ArgumentException($"'{value}' is not a valid phone number!");

                number = value;
            }
        }

        public override void CopyTo(Contact copyTarget)
        {
            base.CopyTo(copyTarget);
            ((PhoneContact)copyTarget).PhoneNumber = PhoneNumber;
        }
    }
}
