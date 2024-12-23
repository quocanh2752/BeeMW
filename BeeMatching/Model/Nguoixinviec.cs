using System;
using System.Collections.Generic;

namespace BeeMatching.Model;

public partial class Nguoixinviec
{
    public int IdNguoiXinViec { get; set; }

    public int IdNguoiDung { get; set; }

    public string? AnhDaiDien { get; set; }

    public string? AnhHoSo { get; set; }

    public string? SoDienThoai { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string Email { get; set; } = null!;

    public virtual Nguoidung IdNguoiDungNavigation { get; set; } = null!;

    public virtual ICollection<Ungtuyen> Ungtuyens { get; set; } = new List<Ungtuyen>();
}
