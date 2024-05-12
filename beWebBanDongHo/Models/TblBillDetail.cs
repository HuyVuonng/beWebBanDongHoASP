using System;
using System.Collections.Generic;

namespace beWebBanDongHo.Models;

public partial class TblBillDetail
{
    public string FkIdbill { get; set; } = null!;

    public long? FkIdproduct { get; set; }

    public long? IQuantity { get; set; }

    public double? FPrice { get; set; }

    public virtual TblBillWithAccount FkIdbill1 { get; set; } = null!;

    public virtual TblBill FkIdbillNavigation { get; set; } = null!;

    public virtual TblProduct? FkIdproductNavigation { get; set; }
}
