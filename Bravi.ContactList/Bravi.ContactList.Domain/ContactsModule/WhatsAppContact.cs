using System;
using System.ComponentModel.DataAnnotations;

namespace Bravi.ContactList.Domain.ContactsModule
{
    public class WhatsAppContact : Contact
    {
        private string number;

        public string WhatsAppNumber
        {
            get => number;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("WhatsAppNumber cannot be null or empty.", nameof(WhatsAppNumber));

                if (!new PhoneAttribute().IsValid(value))
                    throw new ArgumentException($"'{value}' is not a valid phone number!");

                number = value;
            }
        }

        public override void CopyTo(Contact copyTarget)
        {
            base.CopyTo(copyTarget);
            ((WhatsAppContact)copyTarget).WhatsAppNumber = WhatsAppNumber;
        }
    }
}
