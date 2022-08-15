using QLDT_API.Models;
using Microsoft.EntityFrameworkCore;
namespace QLDT_API.Data{
    public class VidoWebDbContext : DbContext {
        public VidoWebDbContext(DbContextOptions<VidoWebDbContext> opt):base(opt){
            
        }
        public DbSet<Diemdanh> tbl_QLDT_QLHV_DiemDanh {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diemdanh>()
                .HasNoKey();
            
        }
        
    }
}