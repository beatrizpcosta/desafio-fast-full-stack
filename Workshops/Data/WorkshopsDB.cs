using Microsoft.EntityFrameworkCore;
using Workshops.Data.Map;
using Workshops.Models;

namespace Workshops.Data
{
    public class WorkshopsDB : DbContext
    {
        public WorkshopsDB(DbContextOptions<WorkshopsDB> options) : base(options)
        {
        }

        public DbSet<ColaboradorModel> Colaboradores { get; set; }
        public DbSet<WorkshopModel> Workshops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
            modelBuilder.ApplyConfiguration(new WorkshopMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
