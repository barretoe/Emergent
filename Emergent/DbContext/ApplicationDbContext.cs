using Emergent.Models;
using Microsoft.EntityFrameworkCore;

namespace Emergent.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Software> software { get; set; }
    }
}