using Bravi.ContactList.Domain.ContactsModule;
using Bravi.ContactList.Domain.PersonsModule;
using Bravi.ContactList.Infrastructure.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Bravi.ContactList.Infrastructure.Data.EF
{
    public class ContactListContext : DbContext
    {
        public ContactListContext(DbContextOptions<ContactListContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new EmailContactConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneContactConfiguration());
            modelBuilder.ApplyConfiguration(new WhatsAppContactConfiguration());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
