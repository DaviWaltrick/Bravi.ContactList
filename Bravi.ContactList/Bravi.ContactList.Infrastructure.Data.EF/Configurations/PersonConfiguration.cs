using Bravi.ContactList.Domain.PersonsModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bravi.ContactList.Infrastructure.Data.EF.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(p => p.PersonID);
            builder.HasMany(p => p.Contacts).WithOne(c => c.Owner);
        }
    }
}
