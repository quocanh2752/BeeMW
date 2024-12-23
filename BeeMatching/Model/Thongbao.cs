using System;
using System.Collections.Generic;

namespace BeeMatching.Model;

public partial class Thongbao
{
    public int Id { get; set; }

    public int IdNguoiDung { get; set; }

    public string TieuDe { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public string? TrangThai { get; set; }

    public DateTime? NgayThongBao { get; set; }

    public virtual Nguoidung IdNguoiDungNavigation { get; set; } = null!;
}
