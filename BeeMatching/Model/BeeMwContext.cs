using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BeeMatching.Model;

public partial class BeeMwContext : DbContext
{
    public BeeMwContext()
    {
    }

    public BeeMwContext(DbContextOptions<BeeMwContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Congviec> Congviecs { get; set; }

    public virtual DbSet<Doanhnghiep> Doanhnghieps { get; set; }

    public virtual DbSet<Loaicongviec> Loaicongviecs { get; set; }

    public virtual DbSet<Luong> Luongs { get; set; }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    public virtual DbSet<Nguoixinviec> Nguoixinviecs { get; set; }

    public virtual DbSet<Thongbao> Thongbaos { get; set; }

    public virtual DbSet<Tinhthanh> Tinhthanhs { get; set; }

    public virtual DbSet<Ungtuyen> Ungtuyens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=noname;Initial Catalog=BeeMW;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Congviec>(entity =>
        {
            entity.HasKey(e => e.IdCongViec).HasName("PK__CONGVIEC__151A672962077326");

            entity.ToTable("CONGVIEC");

            entity.Property(e => e.IdCongViec).HasColumnName("id_cong_viec");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("dia_chi");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(255)
                .HasColumnName("hinh_anh");
            entity.Property(e => e.HinhThucCongViec)
                .HasMaxLength(50)
                .HasColumnName("hinh_thuc_cong_viec");
            entity.Property(e => e.IdDoanhNghiep).HasColumnName("id_doanh_nghiep");
            entity.Property(e => e.IdTinhThanh).HasColumnName("id_tinh_thanh");
            entity.Property(e => e.LoaiCongViec).HasColumnName("loai_cong_viec");
            entity.Property(e => e.MoTa)
                .HasColumnType("text")
                .HasColumnName("mo_ta");
            entity.Property(e => e.MucLuong)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("muc_luong");
            entity.Property(e => e.NgayHetHan)
                .HasColumnType("datetime")
                .HasColumnName("ngay_het_han");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.SoLuongUngTuyen)
                .HasDefaultValue(0)
                .HasColumnName("so_luong_ung_tuyen");
            entity.Property(e => e.TenCongViec)
                .HasMaxLength(255)
                .HasColumnName("ten_cong_viec");
            entity.Property(e => e.YeuCauCongViec)
                .HasColumnType("text")
                .HasColumnName("yeu_cau_cong_viec");

            entity.HasOne(d => d.IdDoanhNghiepNavigation).WithMany(p => p.Congviecs)
                .HasForeignKey(d => d.IdDoanhNghiep)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CongViec_DoanhNghiep");

            entity.HasOne(d => d.IdTinhThanhNavigation).WithMany(p => p.Congviecs)
                .HasForeignKey(d => d.IdTinhThanh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CongViec_TinhThanh");

            entity.HasOne(d => d.LoaiCongViecNavigation).WithMany(p => p.Congviecs)
                .HasForeignKey(d => d.LoaiCongViec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CongViec_LoaiCongViec");
        });

        modelBuilder.Entity<Doanhnghiep>(entity =>
        {
            entity.HasKey(e => e.IdDoanhNghiep).HasName("PK__DOANHNGH__A1EF1C028C622609");

            entity.ToTable("DOANHNGHIEP");

            entity.HasIndex(e => e.Email, "UQ__DOANHNGH__AB6E6164006F9A9A").IsUnique();

            entity.Property(e => e.IdDoanhNghiep).HasColumnName("id_doanh_nghiep");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(255)
                .HasColumnName("anh_dai_dien");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .HasColumnName("dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.IdNguoiDung).HasColumnName("id_nguoi_dung");
            entity.Property(e => e.IdTinhThanh).HasColumnName("id_tinh_thanh");
            entity.Property(e => e.TenDoanhNghiep)
                .HasMaxLength(255)
                .HasColumnName("ten_doanh_nghiep");

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.Doanhnghieps)
                .HasForeignKey(d => d.IdNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoanhNghiep_NguoiDung");

            entity.HasOne(d => d.IdTinhThanhNavigation).WithMany(p => p.Doanhnghieps)
                .HasForeignKey(d => d.IdTinhThanh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoanhNghiep_TinhThanh");
        });

        modelBuilder.Entity<Loaicongviec>(entity =>
        {
            entity.HasKey(e => e.IdLoaiCongViec).HasName("PK__LOAICONG__24A7F1AECA52A47C");

            entity.ToTable("LOAICONGVIEC");

            entity.Property(e => e.IdLoaiCongViec).HasColumnName("id_loai_cong_viec");
            entity.Property(e => e.TenLoaiCongViec)
                .HasMaxLength(255)
                .HasColumnName("ten_loai_cong_viec");
        });

        modelBuilder.Entity<Luong>(entity =>
        {
            entity.HasKey(e => e.IdLuong).HasName("PK__LUONG__D64864F59EF9B96F");

            entity.ToTable("LUONG");

            entity.Property(e => e.IdLuong).HasColumnName("id_luong");
            entity.Property(e => e.KhoangLuong)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("khoang_luong");
        });

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.IdNguoiDung).HasName("PK__NGUOIDUN__75D6A11E74B4946E");

            entity.ToTable("NGUOIDUNG");

            entity.HasIndex(e => e.Email, "UQ__NGUOIDUN__AB6E61645C096DC0").IsUnique();

            entity.Property(e => e.IdNguoiDung).HasColumnName("id_nguoi_dung");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("ho_ten");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .HasColumnName("mat_khau");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(CONVERT([date],getdate()))")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");
            entity.Property(e => e.VaiTro)
                .HasMaxLength(50)
                .HasColumnName("vai_tro");
        });

        modelBuilder.Entity<Nguoixinviec>(entity =>
        {
            entity.HasKey(e => e.IdNguoiXinViec).HasName("PK__NGUOIXIN__78614F211352C5CD");

            entity.ToTable("NGUOIXINVIEC");

            entity.HasIndex(e => e.Email, "UQ__NGUOIXIN__AB6E61641825563C").IsUnique();

            entity.Property(e => e.IdNguoiXinViec).HasColumnName("id_nguoi_xin_viec");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(255)
                .HasColumnName("anh_dai_dien");
            entity.Property(e => e.AnhHoSo)
                .HasMaxLength(255)
                .HasColumnName("anh_ho_so");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(10)
                .HasColumnName("gioi_tinh");
            entity.Property(e => e.IdNguoiDung).HasColumnName("id_nguoi_dung");
            entity.Property(e => e.NgaySinh).HasColumnName("ngay_sinh");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .HasColumnName("so_dien_thoai");

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.Nguoixinviecs)
                .HasForeignKey(d => d.IdNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NguoiXinViec_NguoiDung");
        });

        modelBuilder.Entity<Thongbao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__THONGBAO__3213E83F0AE71D92");

            entity.ToTable("THONGBAO");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdNguoiDung).HasColumnName("id_nguoi_dung");
            entity.Property(e => e.NgayThongBao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_thong_bao");
            entity.Property(e => e.NoiDung)
                .HasColumnType("text")
                .HasColumnName("noi_dung");
            entity.Property(e => e.TieuDe)
                .HasMaxLength(255)
                .HasColumnName("tieu_de");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.IdNguoiDungNavigation).WithMany(p => p.Thongbaos)
                .HasForeignKey(d => d.IdNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThongBao_NguoiDung");
        });

        modelBuilder.Entity<Tinhthanh>(entity =>
        {
            entity.HasKey(e => e.IdTinhThanh).HasName("PK__TINHTHAN__ED52EE68BF95F6B5");

            entity.ToTable("TINHTHANH");

            entity.Property(e => e.IdTinhThanh).HasColumnName("id_tinh_thanh");
            entity.Property(e => e.TenTinhThanh)
                .HasMaxLength(255)
                .HasColumnName("ten_tinh_thanh");
        });

        modelBuilder.Entity<Ungtuyen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UNGTUYEN__3213E83F7B523A3A");

            entity.ToTable("UNGTUYEN");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCongViec).HasColumnName("id_cong_viec");
            entity.Property(e => e.IdNguoiXinViec).HasColumnName("id_nguoi_xin_viec");
            entity.Property(e => e.NgayUngTuyen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_ung_tuyen");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasColumnName("trang_thai");
            entity.Property(e => e.YeuCauNguyenVong)
                .HasColumnType("text")
                .HasColumnName("yeu_cau_nguyen_vong");

            entity.HasOne(d => d.IdCongViecNavigation).WithMany(p => p.Ungtuyens)
                .HasForeignKey(d => d.IdCongViec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UngTuyen_CongViec");

            entity.HasOne(d => d.IdNguoiXinViecNavigation).WithMany(p => p.Ungtuyens)
                .HasForeignKey(d => d.IdNguoiXinViec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UngTuyen_NguoiXinViec");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
