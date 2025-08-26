using CampusEventAggregator.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CampusEventAggregator.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

