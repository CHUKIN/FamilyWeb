using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FamilyWeb.Models
{
    public class FamilyContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<Cash> Cashs { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public FamilyContext(DbContextOptions<FamilyContext> options)
            : base(options)
        {
        }
    }
}
