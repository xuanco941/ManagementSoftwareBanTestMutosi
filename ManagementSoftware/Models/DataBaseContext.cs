using ManagementSoftware.DAL;
using ManagementSoftware.Models.BauNongModel;
using ManagementSoftware.Models.BepTuModel;
using ManagementSoftware.Models.CongTacModel;
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
            //Cong tac 
            modelBuilder.Entity<TestCongTac>(entity =>
            {
                entity.Property(e => e.CreateAt).HasDefaultValueSql("(getdate())");
            });

        }
        public bool CreateDatabase()
        {
            try
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






                    //test
                    for (int i = 0; i < 40; i++)
                    {

                        //loiloc
                        Models.LoiLocModel.LoiLoc loiLoca = new Models.LoiLocModel.LoiLoc();
                        loiLoca.LoiLocName = TenThietBi.LoiLoc1;
                        loiLoca.ThoiGianXa = 3;
                        loiLoca.SoLanTest = 2;
                        DALLoiLoc.Add(loiLoca);

                        //beptu test
                        List<Models.BepTuModel.BepTu> bepTus = new List<BepTu>();
                        BepTu beptu1 = new BepTu();
                        beptu1.BepTuName = TenThietBi.BepTu1;
                        beptu1.ApAC = 6;
                        beptu1.CongSuatAC = 10;
                        beptu1.DongAC = 75;
                        beptu1.NhietDo = 87;
                        beptu1.ThoiGianSoi = 7;
                        BepTu beptu2 = new BepTu();
                        beptu2.BepTuName = TenThietBi.BepTu2;
                        beptu2.ApAC = 6;
                        beptu2.CongSuatAC = 10;
                        beptu2.DongAC = 75;
                        beptu2.NhietDo = 87;
                        beptu2.ThoiGianSoi = 7;
                        bepTus.Add(beptu1);
                        bepTus.Add(beptu2);
                        DALBepTu.Add(bepTus);



                        //BauNong
                        List<BauNong> bauNongs = new List<BauNong>();

                        for (int j = 1; j <= 10; j++)
                        {
                            BauNong baunong1 = new BauNong();
                            baunong1.CBNhietThanBauNong = true;
                            baunong1.BauNongName = "Jig " + j;
                            baunong1.CBNhietThanBauNong = true;
                            baunong1.DongDienAC = 32;
                            bauNongs.Add(baunong1);
                        }
                        DALBauNong.Add(bauNongs);


                        //Nguon
                        List<Nguon> nguons = new List<Nguon>();
                        for (int j = 1; j <= 30; j++)
                        {
                            Nguon nguon = new Nguon();
                            nguon.DienApDC = 7;
                            nguon.DongDC = 4.32;
                            nguon.CongSuat = 5.3;
                            nguon.SoLanTest = 1;
                            nguon.NguonName = "Nguồn " + j;
                            nguons.Add(nguon);
                        }
                        DALNguon.Add(nguons);


                        //jig mach
                        List<JigMachNguon> jigmachs = new List<JigMachNguon>();
                        List<JigMachTDS> jigMachTDs = new List<JigMachTDS>();
                        for (int j = 1; j <= 10; j++)
                        {
                            JigMachNguon jigMachNguon = new JigMachNguon();
                            jigMachNguon.JigMachNguonName = "Jig " + j;
                            jigMachNguon.CongSuat = 23;
                            jigMachNguon.DongDien = 12;
                            jigMachNguon.DienAp = 21;
                            jigmachs.Add(jigMachNguon);

                            JigMachTDS jigMachTDS = new JigMachTDS();
                            jigMachTDS.JigMachTDSName = "Jig " + j;
                            jigMachTDS.ApDC = 23;
                            jigMachTDS.CBApSuat = true;
                            jigMachTDS.Van = false;
                            jigMachTDs.Add(jigMachTDS);
                        }
                        DALJigMach.Add(jigmachs, jigMachTDs);


                        ////cong tac
                        //List<CongTac2VT> ct2vt = new List<CongTac2VT>();
                        //for (int j = 1; j <= 10; j++)
                        //{
                        //    for (int k = 1; k <= 5; k++)
                        //    {
                        //        CongTac2VT ct = new CongTac2VT();
                        //        ct.SoLanTest = k + 3;
                        //        ct.JigCongTac2VTName = "Jig " + j;
                        //        ct.CongTac2VTName = "Công tắc " + k;
                        //        ct.TrangThai = true;
                        //        ct2vt.Add(ct);
                        //    }
                        //}
                        //DALCongTac2VT.Add(ct2vt);



                        ////cong tac
                        //List<CongTac3VT> ct3vt = new List<CongTac3VT>();
                        //for (int j = 1; j <= 10; j++)
                        //{
                        //    for (int k = 1; k <= 5; k++)
                        //    {
                        //        CongTac3VT ct = new CongTac3VT();
                        //        ct.SoLanTest = k + 3;
                        //        ct.JigCongTac3VTName = "Jig " + j;
                        //        ct.CongTac3VTName = "Công tắc " + k;
                        //        ct.TrangThai1 = true;
                        //        ct.TrangThai2 = false;
                        //        ct3vt.Add(ct);
                        //    }
                        //}
                        //DALCongTac3VT.Add(ct3vt);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }


        }
        public bool ResetDB()
        {
            try
            {
                if (this.Database.EnsureDeleted() == true && this.Database.EnsureCreated() == true)
                {
                    //tao quuyen cho admin
                    DALGroup.AddGroup(Common.GroupAdmin);
                    //tao tai khoan admin
                    DALUser.AddUser(Common.UserAdmin);
                    DALActivity.AddActivity(new Activity("Hệ thống", "Khởi tạo tài khoản admin.", Common.UserAdmin.Username));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }



        }

    }
}
