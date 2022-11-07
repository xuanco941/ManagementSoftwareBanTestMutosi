using ManagementSoftware.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ManagementSoftware.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Shift> Shifts { get; set; }

        // Tạo ILoggerFactory 
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
            builder
                   .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
                   .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information)
                   .AddDebug();
        }
        );

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(loggerFactory)  // - Thiết lập sử Logger
                .UseSqlServer(Common.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).HasDefaultValueSql("('123')");
                entity.HasIndex(e => e.Username).IsUnique();
            });

            //group
            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.IsManagementGroup).HasDefaultValueSql("(0)");
                entity.Property(e => e.IsManagementUser).HasDefaultValueSql("(0)");
                entity.HasIndex(e => e.GroupName).IsUnique();

            });

            //activity
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
        }
        public void CreateDatabase()
        {
            //this.Database.EnsureDeleted();
            //init db
            if (this.Database.EnsureCreated() == true)
            {
                //tao quuyen cho admin
                DALGroup.AddGroup(Common.GroupAdmin);
                //tao tai khoan admin
                DALUser.AddUser(Common.UserAdmin);

                DALActivity.AddActivity(new Activity("Hệ thống", "asd hasdadaishaoish iaha iahr i riah oahr ahraiwrhaw hrqirh qr", ""));
                DALActivity.AddActivity(new Activity("Hệ thống", "asd hasdadaishaoish iaha iahr i riah oahr ahraiwrhaw hrqirh qr", ""));
                DALActivity.AddActivity(new Activity("Hệ thống", "asd hasdadaishaoish iaha iahr i riah oahr ahraiwrhaw hrqirh qr", ""));
                DALActivity.AddActivity(new Activity("Hệ thống", "asd hasdadaishaoish iaha iahr i riah oahr ahraiwrhaw hrqirh qr", ""));
                DALActivity.AddActivity(new Activity("Hệ thống", "asd hasdadaishaoish iaha iahr i riah oahr ahraiwrhaw hrqirh qr", ""));
                DALActivity.AddActivity(new Activity("Hệ thống", "asd hasdadaishaoish iaha iahr i riah oahr ahraiwrhaw hrqirh qr", ""));
                DALActivity.AddActivity(new Activity("Hệ thống", "Khởi tạo tài khoản admin", Common.UserAdmin.Username));

            }
        }

    }
}
