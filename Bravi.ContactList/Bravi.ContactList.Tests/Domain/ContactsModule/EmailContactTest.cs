using Bravi.ContactList.Domain.ContactsModule;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Bravi.ContactList.Tests.ContactsModule
{
    [TestClass]
    public class EmailContactTest
    {
        [TestMethod]
        public void CopyTo_Should_Copy_EmailContact_Address_Property()
        {
            EmailContact emailContact = new EmailContact { Address = "test@test.com" };
            EmailContact emailContactCopyTarget = new EmailContact { Address = "copyTarget@test.com" };

            emailContact.CopyTo(emailContactCopyTarget);

            emailContactCopyTarget.Address.Should().Be(emailContact.Address);
        }

        [TestMethod]
        public void Address_Property_Should_Throw_ArgumentException_When_Set_To_Empty()
        {
            EmailContact emailContact = new EmailContact { Address = "test@test.com" };

            Action act = () => emailContact.Address = String.Empty;

            act.Should().Throw<ArgumentException>().WithMessage("*Address cannot be null or empty.*");
        }

        [TestMethod]
        public void Address_Property_Should_Throw_ArgumentException_When_Set_To_Null()
        {
            EmailContact emailContact = new EmailContact { Address = "test@test.com" };

            Action act = () => emailContact.Address = null;

            act.Should().Throw<ArgumentException>().WithMessage("*Address cannot be null or empty.*");
        }

        [TestMethod]
        public void Address_Property_Should_Throw_ArgumentException_When_Set_To_An_Invalid_Email_Address()
        {
            EmailContact emailContact = new EmailContact { Address = "test@test.com" };

            Action act = () => emailContact.Address = "invalidmail";

            act.Should().Throw<ArgumentException>().WithMessage("'invalidmail' is not a valid email!");
        }
    }
}
