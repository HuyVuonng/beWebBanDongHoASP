using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace beWebBanDongHo.Models;

public partial class WebBanDongHoContext : DbContext
{
    public WebBanDongHoContext()
    {
    }

    public WebBanDongHoContext(DbContextOptions<WebBanDongHoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblBill> TblBills { get; set; }

    public virtual DbSet<TblBillDetail> TblBillDetails { get; set; }

    public virtual DbSet<TblBillWithAccount> TblBillWithAccounts { get; set; }

    public virtual DbSet<TblGender> TblGenders { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblTrademark> TblTrademarks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-8QHLQ8K7\\SQLEXPRESS;Initial Catalog=WebBanDongHo;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.PkId).HasName("PK__tblAccou__F4A24BC2C2C9DB82");

            entity.ToTable("tblAccount");

            entity.Property(e => e.PkId).HasColumnName("PK_ID");
            entity.Property(e => e.SAddress).HasColumnName("sAddress");
            entity.Property(e => e.SCity)
                .HasMaxLength(50)
                .HasColumnName("sCity");
            entity.Property(e => e.SEmail).HasColumnName("sEmail");
            entity.Property(e => e.SFullName).HasColumnName("sFullName");
            entity.Property(e => e.SPassword).HasColumnName("sPassword");
            entity.Property(e => e.SPhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("sPhoneNumber");
        });

        modelBuilder.Entity<TblBill>(entity =>
        {
            entity.HasKey(e => e.PkId).HasName("PK__tblBill__F4A24BC264BDA541");

            entity.ToTable("tblBill");

            entity.Property(e => e.PkId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PK_ID");
            entity.Property(e => e.BDelivered).HasColumnName("bDelivered");
            entity.Property(e => e.BDelivering).HasColumnName("bDelivering");
            entity.Property(e => e.BPay).HasColumnName("bPay");
            entity.Property(e => e.DCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("dCreatedAt");
            entity.Property(e => e.DUpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("dUpdatedAt");
            entity.Property(e => e.SAddress).HasColumnName("sAddress");
            entity.Property(e => e.SCity)
                .HasMaxLength(50)
                .HasColumnName("sCity");
            entity.Property(e => e.SEmail).HasColumnName("sEmail");
            entity.Property(e => e.SFullName).HasColumnName("sFullName");
            entity.Property(e => e.SPhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("sPhoneNumber");
        });

        modelBuilder.Entity<TblBillDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblBillDetail");

            entity.Property(e => e.FPrice).HasColumnName("fPrice");
            entity.Property(e => e.FkIdbill)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Fk_IDBill");
            entity.Property(e => e.FkIdproduct).HasColumnName("FK_IDProduct");
            entity.Property(e => e.IQuantity).HasColumnName("iQuantity");

            entity.HasOne(d => d.FkIdbillNavigation).WithMany()
                .HasForeignKey(d => d.FkIdbill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBillDetail_tblBill");

            entity.HasOne(d => d.FkIdbill1).WithMany()
                .HasForeignKey(d => d.FkIdbill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblBillDetail_tblBillWithAccount");

            entity.HasOne(d => d.FkIdproductNavigation).WithMany()
                .HasForeignKey(d => d.FkIdproduct)
                .HasConstraintName("FK_tblBillDetail_tblProduct");
        });

        modelBuilder.Entity<TblBillWithAccount>(entity =>
        {
            entity.HasKey(e => e.PkId).HasName("PK__tblBillW__F4A24BC24A2A6969");

            entity.ToTable("tblBillWithAccount");

            entity.Property(e => e.PkId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PK_ID");
            entity.Property(e => e.BDelivered).HasColumnName("bDelivered");
            entity.Property(e => e.BDelivering).HasColumnName("bDelivering");
            entity.Property(e => e.BPay).HasColumnName("bPay");
            entity.Property(e => e.DCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("dCreatedAt");
            entity.Property(e => e.DUpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("dUpdatedAt");
            entity.Property(e => e.FkIdaccount).HasColumnName("FK_IDAccount");

            entity.HasOne(d => d.FkIdaccountNavigation).WithMany(p => p.TblBillWithAccounts)
                .HasForeignKey(d => d.FkIdaccount)
                .HasConstraintName("FK_tblBillWithAccount_tblAccount");
        });

        modelBuilder.Entity<TblGender>(entity =>
        {
            entity.HasKey(e => e.PkId);

            entity.ToTable("tblGender");

            entity.Property(e => e.PkId).HasColumnName("Pk_ID");
            entity.Property(e => e.SName).HasColumnName("sName");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.PkId);

            entity.ToTable("tblProduct");

            entity.Property(e => e.PkId).HasColumnName("Pk_ID");
            entity.Property(e => e.BDeleted).HasColumnName("bDeleted");
            entity.Property(e => e.DCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("dCreatedAt");
            entity.Property(e => e.DUpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("dUpdatedAt");
            entity.Property(e => e.FPrice).HasColumnName("fPrice");
            entity.Property(e => e.FkGender).HasColumnName("Fk_Gender");
            entity.Property(e => e.FkTrademark).HasColumnName("Fk_Trademark");
            entity.Property(e => e.IQuantity).HasColumnName("iQuantity");
            entity.Property(e => e.ISold).HasColumnName("iSold");
            entity.Property(e => e.SDecription)
                .HasColumnType("ntext")
                .HasColumnName("sDecription");
            entity.Property(e => e.SImg)
                .HasColumnType("ntext")
                .HasColumnName("sImg");
            entity.Property(e => e.SName).HasColumnName("sName");

            entity.HasOne(d => d.FkGenderNavigation).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.FkGender)
                .HasConstraintName("FK_tblProduct_tblGender");

            entity.HasOne(d => d.FkTrademarkNavigation).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.FkTrademark)
                .HasConstraintName("FK_tblProduct_tblTrademark");
        });

        modelBuilder.Entity<TblTrademark>(entity =>
        {
            entity.HasKey(e => e.PkId);

            entity.ToTable("tblTrademark");

            entity.Property(e => e.PkId).HasColumnName("Pk_ID");
            entity.Property(e => e.SName).HasColumnName("sName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
