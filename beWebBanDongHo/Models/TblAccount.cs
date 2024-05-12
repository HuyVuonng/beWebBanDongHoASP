using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace beWebBanDongHo.Models;

public partial class TblAccount
{
    [AllowNull]
    public long? PkId { get; set; }

    public string? SEmail { get; set; }

    public string? SPassword { get; set; }

    public string? SFullName { get; set; }

    public string? SPhoneNumber { get; set; }

    public string? SCity { get; set; }

    public string? SAddress { get; set; }
    public string? SRole { get; set; }


    public virtual ICollection<TblBillWithAccount> TblBillWithAccounts { get; set; } = new List<TblBillWithAccount>();
}
