using ADO.NET.Entities;
using Microsoft.EntityFrameworkCore;

namespace ADO.NET
{
    public class MyAppContext : DbContext
    {
        public DbSet<Cashier> Cashiers { get; set; }
        
        public DbSet<Medicine> Medicine { get; set; }
        
        public DbSet<CashierMedicine> CashierMedicine { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=7978;Database=Ap;";
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CashierMedicine>()
                .HasKey(cm => new { cm.CashierMedicineId});
            
            modelBuilder.Entity<CashierMedicine>()
                .HasOne(cm => cm.Cashier)
                .WithMany(cm => cm.CashiersMedicines)
                .HasForeignKey(cm => cm.CashierId);
            
            modelBuilder.Entity<CashierMedicine>()
                .HasOne(cm => cm.Medicine)
                .WithMany(m => m.CashierMedicines)
                .HasForeignKey(cm => cm.MedicineId);
            
            modelBuilder.Entity<Medicine>()
                .HasIndex(m => m.Barcode)
                .IsUnique(); 
                
        }
    }
}