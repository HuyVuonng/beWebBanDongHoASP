using System;
using System.Collections.Generic;

namespace beWebBanDongHo.Models;

public partial class TblProduct
{
    public long PkId { get; set; }

    public string? SName { get; set; }

    public double? FPrice { get; set; }

    public long? FkTrademark { get; set; }

    public long? FkGender { get; set; }

    public string? SDecription { get; set; }

    public long? IQuantity { get; set; }

    public long? ISold { get; set; }

    public bool? BDeleted { get; set; }

    public string? SImg { get; set; }

    public DateTime? DCreatedAt { get; set; }

    public DateTime? DUpdatedAt { get; set; }

    public virtual TblGender? FkGenderNavigation { get; set; }

    public virtual TblTrademark? FkTrademarkNavigation { get; set; }
}
