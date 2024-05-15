using Microsoft.EntityFrameworkCore;

namespace Core8_21_140
{
    public class MyDbContext8_21_140 : DbContext
    {
        public MyDbContext8_21_140(DbContextOptions<MyDbContext8_21_140> dbContextOptions)
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
