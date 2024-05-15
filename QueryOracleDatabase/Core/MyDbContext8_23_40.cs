using Microsoft.EntityFrameworkCore;

namespace Core8_23_40
{
    public class MyDbContext8_23_40 : DbContext
    {
        public MyDbContext8_23_40(DbContextOptions<MyDbContext8_23_40> dbContextOptions)
        : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            modelBuilder.HasDefaultSchema("MY_USER");

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
    }
}
