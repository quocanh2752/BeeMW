using System;
using System.Collections.Generic;

namespace BeeMatching.Model;

public partial class Doanhnghiep
{
    public int IdDoanhNghiep { get; set; }

    public int IdNguoiDung { get; set; }

    public string TenDoanhNghiep { get; set; } = null!;

    public string? AnhDaiDien { get; set; }

    public string Email { get; set; } = null!;

    public int IdTinhThanh { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<Congviec> Congviecs { get; set; } = new List<Congviec>();

    public virtual Nguoidung IdNguoiDungNavigation { get; set; } = null!;

    public virtual Tinhthanh IdTinhThanhNavigation { get; set; } = null!;
}
