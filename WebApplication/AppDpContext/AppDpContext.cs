using GymManagement.Models;
using Microsoft.EntityFrameworkCore;
using GymManagement.AppDpContext.Congigrations;

namespace GymManagement.AppDpContext
{

    public class AppDpContext : DbContext
    {
        #region Properties
        public DbSet<Plan> Plans { get; set; }
        #endregion

        #region Constructors
        public AppDpContext(DbContextOptions<AppDpContext> options) :
            base(options)
        {

        }
        #endregion

        #region Protected Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GymMangmentMin;Trusted_Connection=true;trustservercertificate=true ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanConfigration());
        }
        #endregion
    }   }

