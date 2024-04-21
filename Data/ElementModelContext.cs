using Microsoft.EntityFrameworkCore;
using PeriodicTableTutor.Models;

namespace PeriodicTableTutor.Data
{
    public class ElementModelContext(DbContextOptions<ElementModelContext> options) : DbContext(options)
    {
        public DbSet<ElementModel> Elements { get; set; }
    }
}