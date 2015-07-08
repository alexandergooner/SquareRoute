using SquareRouteProject.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SquareRouteProject.Infastructure.Configuration
{
    internal class ClaimConfiguration : EntityTypeConfiguration<Claim>
    {
        internal ClaimConfiguration()
        {
            ToTable("Claim");

            HasKey<Claim>(x => x.ClaimId)
                .Property(x => x.ClaimId)
                .HasColumnName("ClaimId")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property<Claim>(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property<Claim>(x => x.ClaimType)
                .HasColumnName("ClaimType")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property<Claim>(x => x.ClaimValue)
                .HasColumnName("ClaimValue")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            HasRequired<Claim>(x => x.User)
                .WithMany(x => x.Claims)
                .HasForeignKey(x => x.UserId);
        }
    }
}
