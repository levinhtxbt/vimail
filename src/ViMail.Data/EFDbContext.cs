using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ViMail.Data.Entities;

namespace ViMail.Data
{
    public class EFDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Email> Emails { get; set; }

        public DbSet<EmailCollection> EmailCollections { get; set; }

        public DbSet<EmailTemplate> EmailTemplates { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}