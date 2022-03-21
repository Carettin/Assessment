using Assessment.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Data.Configurations
{

    public class InfoConfiguration : IEntityTypeConfiguration<Info>
    {
        public void Configure(EntityTypeBuilder<Info> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Location).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();


            builder
           .HasOne(s => s.Personeller)
           .WithMany(i=> i.Bilgiler)
           .HasForeignKey(s => s.PersonId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
