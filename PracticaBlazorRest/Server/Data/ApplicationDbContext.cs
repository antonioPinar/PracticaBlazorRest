using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PracticaBlazorRest.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaBlazorRest.Shared.Models;

namespace PracticaBlazorRest.Server.Data
{
    public class ApplicationDbContext : DbContext //ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Contact> Contacts { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
            //IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>(entity =>
            {
            });
        }
    }
}
