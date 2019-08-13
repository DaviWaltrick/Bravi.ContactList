using Bravi.ContactList.Domain.ContactsModule;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bravi.ContactList.Tests
{
    [TestClass]
    public class WhatsAppContactTest
    {
        [TestMethod]
        public void CopyTo_Should_Copy_WhatsAppContact_WhatsAppNumber_Property()
        {
            WhatsAppContact wppContact = new WhatsAppContact { WhatsAppNumber = "1234-4321" };
            WhatsAppContact wppContactCopyTarget = new WhatsAppContact { WhatsAppNumber = "0000-0000" };

            wppContact.CopyTo(wppContactCopyTarget);

            wppContactCopyTarget.WhatsAppNumber.Should().Be(wppContact.WhatsAppNumber);
        }

        [TestMethod]
        public void Address_Property_Should_Throw_ArgumentException_When_Set_To_Empty()
        {
            WhatsAppContact wppContact = new WhatsAppContact { WhatsAppNumber = "1234-4321" };

            Action act = () => wppContact.WhatsAppNumber = String.Empty;

            act.Should().Throw<ArgumentException>().WithMessage("*WhatsAppNumber cannot be null or empty.*");
        }

        [TestMethod]
        public void Address_Property_Should_Throw_ArgumentException_When_Set_To_Null()
        {
            WhatsAppContact wppContact = new WhatsAppContact { WhatsAppNumber = "1234-4321" };

            Action act = () => wppContact.WhatsAppNumber = null;

            act.Should().Throw<ArgumentException>().WithMessage("*WhatsAppNumber cannot be null or empty.*");
        }

        [TestMethod]
        public void Address_Property_Should_Throw_ArgumentException_When_Set_To_An_Invalid_Email_Address()
        {
            WhatsAppContact wppContact = new WhatsAppContact { WhatsAppNumber = "1234-4321" };

            Action act = () => wppContact.WhatsAppNumber = "invalidNumber";

            act.Should().Throw<ArgumentException>().WithMessage("'invalidNumber' is not a valid phone number!");
        }
    }
}
