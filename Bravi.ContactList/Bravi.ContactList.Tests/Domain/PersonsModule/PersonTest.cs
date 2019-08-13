using Bravi.ContactList.Domain.ContactsModule;
using Bravi.ContactList.Domain.PersonsModule;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

namespace Bravi.ContactList.Tests.Domain.PersonsModule
{

    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void CopyTo_Should_Throw_ArgumentNullException_When_Copy_Target_Is_Null()
        {
            Person person = new Person();

            Action act = () => person.CopyTo(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void CopyTo_Should_Copy_Person_Name_Property()
        {
            Person person = new Person { Name = "personName" };
            Person copyTargetPerson = new Person { Name = "copyTargetPersonName" };

            person.CopyTo(copyTargetPerson);

            copyTargetPerson.Name.Should().Be(person.Name);
        }

        [TestMethod]
        public void CopyTo_Should_Not_Copy_Contacts_Property()
        {
            Person person = new Person { Name = "personName" };
            Person copyTargetPerson = new Person { Name = "copyTargetPersonName", Contacts = new List<Contact> { new PhoneContact() } };

            person.CopyTo(copyTargetPerson);

            copyTargetPerson.Contacts.Should().HaveCount(1);
        }
    }
}
