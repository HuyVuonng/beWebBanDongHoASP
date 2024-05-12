using System;
using System.Collections.Generic;

namespace beWebBanDongHo.Models;

public partial class TblBillWithAccount
{
    public string PkId { get; set; } = null!;

    public long? FkIdaccount { get; set; }

    public bool? BDelivering { get; set; }

    public bool? BDelivered { get; set; }

    public bool? BPay { get; set; }

    public DateTime? DCreatedAt { get; set; }

    public DateTime? DUpdatedAt { get; set; }

    public virtual TblAccount? FkIdaccountNavigation { get; set; }
}
