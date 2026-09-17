using GymManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.AppDpContext.Congigrations
{
    public class PlanConfigration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            #region Property Configuration
            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Description)
                 .HasColumnType("nvarchar(500)")
                 .HasMaxLength(500)
                 .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            #endregion

            #region Table Mapping & Constraints
            // Map to table and add check constraint for DurationDays
            builder.ToTable("Plans");
            builder.HasCheckConstraint("CK_Plan_DurationDays", "DurationDays BETWEEN 1 AND 365");
            #endregion

            #region Seed Data
            builder.HasData(
                new Plan
                {
                    Id = 1,
                    Name = "Basic Plan",
                    Description = "Basic gym membership",
                    Price = 50,
                    DurationDays = 30
                },

                new Plan
                {
                    Id = 2,
                    Name = "Premium Plan",
                    Description = "Premium gym membership",
                    Price = 100,
                    DurationDays = 60
                },

                new Plan
                {
                    Id = 3,
                    Name = "VIP Plan",
                    Description = "VIP gym membership",
                    Price = 150,
                    DurationDays = 90
                }
            );
            #endregion
        }

    }
}
