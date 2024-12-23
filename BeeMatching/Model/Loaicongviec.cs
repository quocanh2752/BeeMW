using System;
using System.Collections.Generic;

namespace BeeMatching.Model;

public partial class Loaicongviec
{
    public int IdLoaiCongViec { get; set; }

    public string TenLoaiCongViec { get; set; } = null!;

    public virtual ICollection<Congviec> Congviecs { get; set; } = new List<Congviec>();
}
