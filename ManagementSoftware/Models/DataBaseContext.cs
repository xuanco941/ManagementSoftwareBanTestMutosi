using ManagementSoftware.DAL;
using ManagementSoftware.Models.BauNongModel;
using ManagementSoftware.Models.BepTuModel;
using ManagementSoftware.Models.CongTacModel;
using ManagementSoftware.Models.JigMachModel;
using ManagementSoftware.Models.LedModel;
using ManagementSoftware.Models.LoiLocModel;
using ManagementSoftware.Models.NguonModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ManagementSoftware.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Activity> Activities { get; set; }

        //jig mach
        public DbSet<TestJigMach> TestJigMachNguons { get; set; }
        public DbSet<JigMachNguon> JigMachNguons { get; set; }
        public DbSet<TestJigMachTDS> TestJigMachTDSs { get; set; }
        public DbSet<JigMachTDS> JigMachTDSs { get; set; }

        //Bau nong
        public DbSet<TestBauNong> TestBauNongs { get; set; }
        public DbSet<BauNong> BauNongs { get; set; }

        //Loi loc
        public DbSet<LoiLoc> LoiLocs { get; set; }

        //BepTu
        public DbSet<TestBepTu> TestBepTus { get; set; }
        public DbSet<BepTu> BepTus { get; set; }

        //Nguon
        public DbSet<TestNguon> TestNguons { get; set; }
        public DbSet<Nguon> Nguons { get; set; }

        //Led
        public DbSet<TestLed> TestLeds { get; set; }
        public DbSet<Led> Leds { get; set; }

        //Cong tac 2vt
        public DbSet<TestCongTac> TestCongTacs { get; set; }
        public DbSet<CongTac> CongTacs { get; set; }










        // Tạo ILoggerFactory 
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                   .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
                   .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            //.AddDebug();
        }
        );

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                //.UseLoggerFactory(loggerFactory)  // - Thiết lập sử Logger
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

            //jig mạch
            modelBuilder.Entity<TestJigMach>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
            modelBuilder.Entity<TestJigMachTDS>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
            //bau nong
            modelBuilder.Entity<TestBauNong>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
            //bep tu
            modelBuilder.Entity<TestBepTu>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
            //nguon
            modelBuilder.Entity<TestNguon>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
            //Loi loc
            modelBuilder.Entity<LoiLoc>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
            //Cong tac 
            modelBuilder.Entity<TestCongTac>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
            //Cong tac 
            modelBuilder.Entity<TestLed>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });

        }
        public bool CreateDatabase()
        {
            try
            {
                //this.Database.EnsureDeleted();
                //init db
                if (this.Database.EnsureCreated() == true)
                {
                    //tao quuyen cho admin
                    DALGroup.AddGroup(Common.GroupAdmin);
                    //tao tai khoan admin
                    DALUser.AddUser(Common.UserAdmin);

                    DALActivity.AddActivity(new Activity("Hệ thống", "Khởi tạo tài khoản admin.", Common.UserAdmin.Username));
                }
                return true;
            }
            catch
            {
                return false;
            }


        }
       
    }
}
