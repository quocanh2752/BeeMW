using System;
using System.Collections.Generic;

namespace BeeMatching.Model;

public partial class Nguoidung
{
    public int IdNguoiDung { get; set; }

    public string HoTen { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string VaiTro { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public DateOnly? NgayTao { get; set; }

    public virtual ICollection<Doanhnghiep> Doanhnghieps { get; set; } = new List<Doanhnghiep>();

    public virtual ICollection<Nguoixinviec> Nguoixinviecs { get; set; } = new List<Nguoixinviec>();

    public virtual ICollection<Thongbao> Thongbaos { get; set; } = new List<Thongbao>();
}
