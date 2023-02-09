using ChillsoftMinutesAPI.Controllers;
using ChillsoftMinutesAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Xml;

namespace ChillsoftMinutesAPI.Data
{
    public class DataContext : IdentityDbContext<AppUser, Roles, int, IdentityUserClaim<int>, UserRoles, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<Roles>()
              .HasMany(ur => ur.UserRoles)
              .WithOne(u => u.Role)
              .HasForeignKey(ur => ur.RoleId)
              .IsRequired();
           
            //builder.Entity<MeetingItemStatus>(b =>
            //{
            //    b.HasKey(e => e.Id);
            //    b.Property(e => e.Id).ValueGeneratedOnAdd();
            //});

        }
        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<MeetingItem> MeetingItems { get; set; }
        public DbSet<MeetingItemStatus> MeetingItemStatuses { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }

    }
}
