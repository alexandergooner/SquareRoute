using SquareRouteProject.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SquareRouteProject.Infastructure.Configuration
{
    internal class ExternalLoginConfiguration : EntityTypeConfiguration<ExternalLogin>
    {
        internal ExternalLoginConfiguration()
        {
            ToTable("ExternalLogin");

            HasKey<ExternalLogin>(x => new { x.LoginProvider, x.ProviderKey, x.UserId });

            Property<ExternalLogin>(x => x.LoginProvider)
                .HasColumnName("LoginProvider")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            Property<ExternalLogin>(x => x.ProviderKey)
                .HasColumnName("ProviderKey")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            Property<ExternalLogin>(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            HasRequired<ExternalLogin>(x => x.User)
                .WithMany(x => x.Logins)
                .HasForeignKey(x => x.UserId);
        }
    }
}
