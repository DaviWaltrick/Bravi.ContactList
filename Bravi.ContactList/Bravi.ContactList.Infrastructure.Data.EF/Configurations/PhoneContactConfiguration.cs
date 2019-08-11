using Bravi.ContactList.Domain.ContactsModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravi.ContactList.Infrastructure.Data.EF.Configurations
{
    public class PhoneContactConfiguration : IEntityTypeConfiguration<PhoneContact>
    {
        public void Configure(EntityTypeBuilder<PhoneContact> builder)
        {
            builder.HasDiscriminator().HasValue("Phone");
            builder.Property(c => c.Number).HasColumnName("PhoneNumber");
        }
    }
}
