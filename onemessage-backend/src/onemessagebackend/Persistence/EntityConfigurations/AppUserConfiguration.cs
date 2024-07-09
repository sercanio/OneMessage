using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers").HasKey(au => au.Id);

        builder.Property(au => au.Id).HasColumnName("Id").IsRequired();
        builder.Property(au => au.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(au => au.AvatarURL).HasColumnName("AvatarURL");
        builder.Property(au => au.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(au => au.Status).HasColumnName("Status");
        builder.Property(au => au.LastSeen).HasColumnName("LastSeen");
        builder.Property(au => au.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(au => au.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(au => au.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(au => !au.DeletedDate.HasValue);

        builder.HasIndex(a => a.UserId, "AppUser_UserID_UK").IsUnique();

        builder.HasOne(a => a.User);
    }
}