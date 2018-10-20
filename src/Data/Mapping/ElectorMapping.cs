using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ElectorMapping : IEntityTypeConfiguration<Elector>
    {
        public void Configure(EntityTypeBuilder<Elector> builder)
        {
            builder.ToTable("Elector");

            builder.HasKey(c => c.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar(20)");

            builder.Property(x => x.Email)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Password)
                .HasColumnType("varchar(8)");

            builder.Property(x => x.Document)
                .HasColumnType("varchar(11)");

            builder.HasOne(x => x.Party)
                .WithMany(x => x.Electors)
                .HasForeignKey(x => x.PartyId);

        }
    }
}
