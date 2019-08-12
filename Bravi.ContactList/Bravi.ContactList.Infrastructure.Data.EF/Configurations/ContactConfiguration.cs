using Bravi.ContactList.Domain.ContactsModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravi.ContactList.Infrastructure.Data.EF.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(c => c.ContactID);
            builder.HasOne(c => c.Person).WithMany(p => p.Contacts).OnDelete(DeleteBehavior.Cascade);
            builder.HasDiscriminator<string>("ContactType")
                   .HasValue<EmailContact>("Email")
                   .HasValue<PhoneContact>("Phone")
                   .HasValue<WhatsAppContact>("WhatsApp");
        }
    }
}
