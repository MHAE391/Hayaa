using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Fax> Faxes { get; set; }
        public DbSet<Image> Images { get; set; }    
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<FaxBranch> FaxesBranches { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FaxBranch>().HasKey(FB => new { FB.FaxId , FB.BranchId});
            modelBuilder.Entity<FaxBranch>().HasOne(F => F.Fax).WithMany(B => B.FaxBranches)
                .HasForeignKey(F => F.FaxId);
            modelBuilder.Entity<FaxBranch>().HasOne(B => B.Branch).WithMany(B => B.BrachFaxes)
                .HasForeignKey(B => B.BranchId);
        }
    }
}
