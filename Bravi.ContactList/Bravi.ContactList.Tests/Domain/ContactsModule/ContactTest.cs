using Bravi.ContactList.Domain.ContactsModule;
using Bravi.ContactList.Domain.PersonsModule;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Bravi.ContactList.Tests.ContactsModule
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void CopyTo_Should_Throw_ArgumentNullException_When_Copy_Target_Is_Null()
        {
            Contact contact = new EmailContact();

            Action act = () => contact.CopyTo(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void CopyTo_Should_Throw_ArgumentException_When_Copy_Target_Is_Not_The_Same_Type_As_Copy_Origin()
        {
            Contact emailContact = new EmailContact();
            Contact phoneContact = new PhoneContact();

            Action act = () => emailContact.CopyTo(phoneContact);

            act.Should().Throw<ArgumentException>().WithMessage("Copy origin and copy target must be of the same type.");
        }

        [TestMethod]
        public void CopyTo_Should_Copy_Contact_Name_Property()
        {
            Contact contact = new EmailContact { Address = "test@test.com", Name = "EmailContactName" };
            Contact copyTargetContact = new EmailContact { Name = "CopyTargetEmailContactName" };

            contact.CopyTo(copyTargetContact);

            copyTargetContact.Name.Should().Be(contact.Name);
        }

        [TestMethod]
        public void CopyTo_Should_Copy_Contact_Person_Property()
        {
            Contact contact = new EmailContact { Address = "test@test.com", Person = new Person { Name = "personName" } };
            Contact copyTargetContact = new EmailContact();

            contact.CopyTo(copyTargetContact);

            copyTargetContact.Person.Should().Be(contact.Person);
        }
    }
}
