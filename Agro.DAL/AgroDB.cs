using Agro.DAL.Entities;
using Agro.DAL.Entities.DefaultData;
using Microsoft.EntityFrameworkCore;
using Type = Agro.DAL.Entities.Type;

namespace Agro.DAL;
public class AgroDB : DbContext
{
    #region DbSet
    public DbSet<Status> Statuses { get; set; } = null!;

    public DbSet<Group> Groups { get; set; } = null!;

    public DbSet<Type> Types { get; set; } = null!;

    public DbSet<BankDetails> BankDetails { get; set; } = null!;

    //public DbSet<Address> Addresses { get; set; } = null!;

    public DbSet<Counterparty> Counterparties { get; set; } = null!;

#endregion
    public AgroDB(DbContextOptions<AgroDB> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder db)
    {
        db.Entity<Status>().HasData(GetDefaultData.DefaultStatus());
        db.Entity<Group>().HasData(GetDefaultData.DefaultGroup());
        db.Entity<Type>().HasData(GetDefaultData.DefaultType());
    }

    
}
