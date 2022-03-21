using Assessment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Data.Configurations
{

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.UUID);
            builder.Property(x => x.FirstName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(150).IsRequired();

       

        }
    }
}
