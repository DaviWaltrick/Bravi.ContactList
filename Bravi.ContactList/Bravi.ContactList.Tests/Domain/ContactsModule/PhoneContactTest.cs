using Bravi.ContactList.Domain.ContactsModule;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Bravi.ContactList.Tests
{
    [TestClass]
    public class PhoneContactTest
    {
        [TestMethod]
        public void CopyTo_Should_Copy_PhoneContact_PhoneNumber_Property()
        {
            PhoneContact phoneContact = new PhoneContact { PhoneNumber = "1234-4321" };
            PhoneContact phoneContactCopyTarget = new PhoneContact { PhoneNumber = "0000-0000" };

            phoneContact.CopyTo(phoneContactCopyTarget);

            phoneContactCopyTarget.PhoneNumber.Should().Be(phoneContact.PhoneNumber);
        }

        [TestMethod]
        public void Address_Property_Should_Throw_ArgumentException_When_Set_To_Empty()
        {
            PhoneContact phoneContact = new PhoneContact { PhoneNumber = "1234-4321" };

            Action act = () => phoneContact.PhoneNumber = String.Empty;

            act.Should().Throw<ArgumentException>().WithMessage("*PhoneNumber cannot be null or empty.*");
        }

        [TestMethod]
        public void Address_Property_Should_Throw_ArgumentException_When_Set_To_Null()
        {
            PhoneContact phoneContact = new PhoneContact { PhoneNumber = "1234-4321" };

            Action act = () => phoneContact.PhoneNumber = null;

            act.Should().Throw<ArgumentException>().WithMessage("*PhoneNumber cannot be null or empty.*");
        }

        [TestMethod]
        public void Address_Property_Should_Throw_ArgumentException_When_Set_To_An_Invalid_Email_Address()
        {
            PhoneContact phoneContact = new PhoneContact { PhoneNumber = "1234-4321" };

            Action act = () => phoneContact.PhoneNumber = "invalidNumber";

            act.Should().Throw<ArgumentException>().WithMessage("'invalidNumber' is not a valid phone number!");
        }
    }
}
