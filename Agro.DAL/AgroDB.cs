using Agro.DAL.Entities;
using Agro.DAL.Entities.DefaultData;
using Microsoft.EntityFrameworkCore;
using TypeDoc = Agro.DAL.Entities.TypeDoc;

namespace Agro.DAL;
public class AgroDB : DbContext
{
    #region DbSet
    public DbSet<Status> Statuses { get; set; } = null!;

    public DbSet<GroupDoc> Groups { get; set; } = null!;

    public DbSet<TypeDoc> Types { get; set; } = null!;

    public DbSet<BankDetails> BankDetails { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<UnitOkei> UnitsOkei { get; set; } = null!;

    public DbSet<Nds>  Ndses { get; set; } = null!;

    //public DbSet<Address> Addresses { get; set; } = null!;

    public DbSet<Counterparty> Counterparties { get; set; } = null!;

#endregion
    public AgroDB(DbContextOptions<AgroDB> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder db)
    {
        db.Entity<Status>().HasData(GetDefaultData.DefaultStatus());
        db.Entity<GroupDoc>().HasData(GetDefaultData.DefaultGroup());
        db.Entity<TypeDoc>().HasData(GetDefaultData.DefaultType());
        db.Entity<UnitOkei>().HasData(GetDefaultData.DefaultUnitOkeis());
        db.Entity<Nds>().HasData(GetDefaultData.DefaultNds());
    }

    
}
