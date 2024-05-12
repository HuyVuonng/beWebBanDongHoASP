using System;
using System.Collections.Generic;

namespace beWebBanDongHo.Models;

public partial class TblBill
{
    public string PkId { get; set; } = null!;

    public string? SEmail { get; set; }

    public string? SFullName { get; set; }

    public string? SPhoneNumber { get; set; }

    public string? SCity { get; set; }

    public string? SAddress { get; set; }

    public bool? BDelivering { get; set; }

    public bool? BDelivered { get; set; }

    public bool? BPay { get; set; }

    public DateTime? DCreatedAt { get; set; }

    public DateTime? DUpdatedAt { get; set; }
}
