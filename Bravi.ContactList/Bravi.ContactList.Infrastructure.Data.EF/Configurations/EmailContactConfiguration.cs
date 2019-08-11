using Bravi.ContactList.Domain.ContactsModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravi.ContactList.Infrastructure.Data.EF.Configurations
{
    public class EmailContactConfiguration : IEntityTypeConfiguration<EmailContact>
    {
        public void Configure(EntityTypeBuilder<EmailContact> builder)
        {
            builder.HasDiscriminator().HasValue("Email");
        }
    }
}
