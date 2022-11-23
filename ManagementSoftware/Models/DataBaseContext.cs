﻿using ManagementSoftware.DAL;
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
        public DbSet<TestJigMach> TestJigMachs { get; set; }
        public DbSet<JigMachNguon> JigMachNguons { get; set; }
        public DbSet<JigMachTDS> JigMachTDSs { get; set; }

        //Bau nong
        public DbSet<TestBauNong> TestBauNongs { get; set; }
        public DbSet<BauNong> BauNongs { get; set; }

        //Loi loc
        public DbSet<TestLoiLoc> TestLoiLocs { get; set; }
        public DbSet<LoiLoc> LoiLocs { get; set; }

        //BepTu
        public DbSet<TestBepTu> TestBepTus { get; set; }
        public DbSet<BepTu> BepTus { get; set; }

        //Nguon
        public DbSet<TestNguon> TestNguons { get; set; }
        public DbSet<Nguon> Nguons { get; set; }

        //Cong tac 2vt
        public DbSet<TestCongTac2VT> TestCongTac2VTs { get; set; }
        public DbSet<CongTac2VT> CongTac2VTs { get; set; }

        //Cong tac 3vt
        public DbSet<TestCongTac3VT> TestCongTac3VTs { get; set; }
        public DbSet<CongTac3VT> CongTac3VTs { get; set; }









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

            //jig mạch
            modelBuilder.Entity<TestJigMach>(entity =>
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
            modelBuilder.Entity<TestLoiLoc>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
            //Cong tac 2 vt
            modelBuilder.Entity<TestCongTac2VT>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });
            //Cong tac 3 vt
            modelBuilder.Entity<TestCongTac3VT>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });

        }
        public void CreateDatabase()
        {
            this.Database.EnsureDeleted();
            //init db
            if (this.Database.EnsureCreated() == true)
            {
                //tao quuyen cho admin
                DALGroup.AddGroup(Common.GroupAdmin);
                //tao tai khoan admin
                DALUser.AddUser(Common.UserAdmin);

                DALActivity.AddActivity(new Activity("Hệ thống", "Khởi tạo tài khoản admin.", Common.UserAdmin.Username));


                for (int i = 0; i< 40; i++)
                {
                    List<Models.LoiLoc> loiLocs1 = new List<Models.LoiLoc>();

                    Models.LoiLoc loiLoca = new Models.LoiLoc();
                    loiLoca.LoiLocName = TenThietBi.LoiLoc1;
                    loiLoca.ThoiGianXa = 3.2;
                    loiLoca.SoLanTest = 2;

                    Models.LoiLoc loiLocb = new Models.LoiLoc();
                    loiLocb.LoiLocName = TenThietBi.LoiLoc2;
                    loiLocb.ThoiGianXa = 4.2;
                    loiLocb.SoLanTest = 9;
                    loiLocb.ThoiGianNen = 7;

                    Models.LoiLoc loiLocc = new Models.LoiLoc();
                    loiLocc.LoiLocName = TenThietBi.LoiLoc1va2;
                    loiLocc.ThoiGianXa = 4.2;
                    loiLocc.SoLanTest = 9;
                    loiLocc.ThoiGianNen = 7;
                    loiLocc.ThoiGianGiu = 10;
                    loiLocc.ApSuatTest = 1000.1;

                    loiLocs1.Add(loiLoca);
                    loiLocs1.Add(loiLocb);
                    loiLocs1.Add(loiLocc);

                    DALLoiLoc.Add(loiLocs1);
                }


            }
        }

    }
}
