using System;
using System.Collections.Generic;

namespace BeeMatching.Model;

public partial class Tinhthanh
{
    public int IdTinhThanh { get; set; }

    public string TenTinhThanh { get; set; } = null!;

    public virtual ICollection<Congviec> Congviecs { get; set; } = new List<Congviec>();

    public virtual ICollection<Doanhnghiep> Doanhnghieps { get; set; } = new List<Doanhnghiep>();
}
