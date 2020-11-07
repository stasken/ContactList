using ContactListApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactListApi.Data
{
    public class ContactListContext : DbContext
    {
        public ContactListContext(DbContextOptions<ContactListContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API Configuration
            // ========================

            // Contact
            // =======

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Contact)
                .HasForeignKey<Address>(y => y.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relations
            // ---------


            // Unique Indexes
            // --------------

            // PhoneNumber
            // ===========

            // Relations
            // ---------

            modelBuilder.Entity<PhoneNumber>()
                .HasOne(p => p.Contact)
                .WithMany(c => c.PhoneNumbers)
                .HasForeignKey(p => p.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique Indexes
            // --------------

            modelBuilder.Entity<PhoneNumber>()
                .HasIndex(p => new { p.Number, p.ContactId })
                .IsUnique(true)
                .HasName("UQ_PhoneNumber_Number_ContactId");
        }
    }
}
