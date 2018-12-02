using Microsoft.EntityFrameworkCore;

namespace HelloReact.Data {
  public partial class UserDb : DbContext {
    public UserDb() {
    }

    public UserDb(DbContextOptions options)
        : base(options) {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      if (!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        optionsBuilder.UseSqlServer("Server=localhost;Database=HelloReact;Trusted_Connection=True;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<User>(entity => {
        entity.ToTable("User");

        entity.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        entity.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsUnicode(false);
      });
    }
  }
}
