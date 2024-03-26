using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace demo_api_swagger.Models
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {

        }
        public DemoContext(DbContextOptions<DemoContext> options) :base(options) { }


        public virtual DbSet<User> tblUser { get; set; } = null!;

        public virtual DbSet<Contact> tblContact { get; set; } = null!;

        public virtual DbSet<Recruitment> tblRecruiment { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VP20ASB;Initial Catalog=Demo;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.ToTable("tblUser");
                entity.Property(t => t.Id).HasColumnName("Id");
                entity.Property(t => t.UserFName).HasColumnName("userFName");
                entity.Property(t => t.UserLName).HasColumnName("userLName");
                entity.Property(t => t.UserEmail).HasColumnName("userEmail");
                entity.Property(t => t.UserPassword).HasColumnName("userPassword");
            });


            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.ToTable("tblContact");
                entity.Property(t => t.Id).HasColumnName("Id");
                entity.Property(t => t.Name).HasColumnName("contactName");
                entity.Property(t => t.CompanyName).HasColumnName("contactCName");
                entity.Property(t => t.PhoneNumber).HasColumnName("contactPhoneNumber");
                entity.Property(t => t.Email).HasColumnName("contactEmail");
                entity.Property(t => t.Content).HasColumnName("contactContent");
            });

            modelBuilder.Entity<Recruitment>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.ToTable("tblRecruitment");
                entity.Property(t => t.Id).HasColumnName("Id");
                entity.Property(t => t.rName).HasColumnName("rName");
                entity.Property(t => t.rCat).HasColumnName("rCat");
                entity.Property(t => t.rLocation).HasColumnName("rLocation");
                entity.Property(t => t.rEndDate).HasColumnName("rEndDate");
            });
        }
    }
}
