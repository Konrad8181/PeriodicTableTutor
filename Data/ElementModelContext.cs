using Microsoft.EntityFrameworkCore;
using PeriodicTableTutor.Models.Entities;

namespace PeriodicTableTutor.Data
{
    public class ElementModelContext(DbContextOptions<ElementModelContext> options) : DbContext(options)
    {
        /// <summary>
        /// Elements model database definition
        /// </summary>
        public DbSet<ElementModel> Elements { get; set; }
    }
}