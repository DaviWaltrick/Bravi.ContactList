using System;
using System.ComponentModel.DataAnnotations;

namespace Bravi.ContactList.Domain.ContactsModule
{
    public class WhatsAppContact : Contact
    {
        private string number;

        public string Number
        {
            get => number;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Number));

                if (new PhoneAttribute().IsValid(value))
                    throw new ArgumentException($"'{value}' is not a valid phone number!");

                number = value;
            }
        }
    }
}
