using QLDT_API.Models;
using Microsoft.EntityFrameworkCore;
namespace QLDT_API.Data{
    public class VidoWebDbContext : DbContext {
        public VidoWebDbContext(DbContextOptions<VidoWebDbContext> opt):base(opt){
            
        }
        public DbSet<Diemdanh> tbl_QLDT_QLHV_DiemDanh {get;set;}
        public DbSet<Lopmonhoc> tbl_QLDT_TKB_LopMonHoc {get; set;}
        public DbSet<Monhoc> tbl_QLDT_CTDT_MonHoc {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diemdanh>()
                .HasNoKey();
            
        }
        
    }
}