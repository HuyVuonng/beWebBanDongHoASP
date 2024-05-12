using System;
using System.Collections.Generic;

namespace beWebBanDongHo.Models;

public partial class TblTrademark
{
    public long PkId { get; set; }

    public string? SName { get; set; }

    public virtual ICollection<TblProduct> TblProducts { get; set; } = new List<TblProduct>();
}
