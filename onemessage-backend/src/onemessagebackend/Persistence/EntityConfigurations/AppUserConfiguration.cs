using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(a => a.AvatarURL).HasColumnName("AvatarURL").HasMaxLength(256);
        builder.Property(a => a.UserName).HasColumnName("UserName").IsRequired().HasMaxLength(50);
        builder.Property(a => a.Status).HasColumnName("Status").HasMaxLength(256);
        builder.Property(a => a.LastSeen).HasColumnName("LastSeen");

        builder.HasOne(a => a.User)
               .WithOne()
               .HasForeignKey<AppUser>(a => a.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        //builder.HasMany(a => a.Contacts)
        //       .WithMany()
        //       .UsingEntity(j => j.ToTable("UserContacts"));

        //builder.HasMany(a => a.Blockings)
        //       .WithMany()
        //       .UsingEntity(j => j.ToTable("UserBlockings"));

        builder.HasMany(a => a.MessagesSent)
               .WithOne(m => m.Sender)
               .HasForeignKey(m => m.SenderId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.MessagesReceived)
               .WithOne(m => m.Receiver)
               .HasForeignKey(m => m.ReceiverId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
