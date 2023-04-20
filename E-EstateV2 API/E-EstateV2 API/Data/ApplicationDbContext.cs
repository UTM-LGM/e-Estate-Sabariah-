using E_EstateV2_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_EstateV2_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Company> companies { get; set; }
        public DbSet<Estate> estates { get; set; }
        public DbSet<Establishment> establishments { get; set; }
        public DbSet<FinancialYear> financialYears { get; set; }
        public DbSet<MembershipType> membershipTypes { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<Town> towns { get; set; }
        public DbSet<EstateStatus> estateStatusLog { get; set; }
        public DbSet<CropCategory> cropCategories { get; set; }
        public DbSet<Clone> clones { get; set; }
        public DbSet<Field> fields { get; set; }
        public DbSet<FieldClone> fieldClones { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<Labor> labors { get; set; }
        public DbSet<CostType> costTypes { get; set; }
        public DbSet<CostCategory> costCategories { get; set; }
        public DbSet<CostSubcategory1> costSubcategories1 { get; set; } 
        public DbSet<CostSubcategory2> costSubcategories2 { get; set; }
        public DbSet<Cost> costs { get; set; }
        public DbSet<CostAmount> costAmounts { get; set; }
        public DbSet<FieldProduction> fieldProductions { get; set; }
        public DbSet<UserActivityLog> userActivityLogs { get; set; }
    }
}
