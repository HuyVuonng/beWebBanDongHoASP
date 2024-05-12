using System;
using System.Collections.Generic;

namespace beWebBanDongHo.Models;

public partial class TblGender
{
    public long PkId { get; set; }

    public string SName { get; set; } = null!;

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
