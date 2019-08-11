using Bravi.ContactList.Domain.ContactsModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravi.ContactList.Infrastructure.Data.EF.Configurations
{
    public class WhatsAppContactConfiguration : IEntityTypeConfiguration<WhatsAppContact>
    {
        public void Configure(EntityTypeBuilder<WhatsAppContact> builder)
        {
            builder.HasDiscriminator().HasValue("WhatsApp");
            builder.Property(c => c.Number).HasColumnName("WhatsAppNumber");
        }
    }
}
