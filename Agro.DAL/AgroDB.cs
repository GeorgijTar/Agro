using Agro.DAL.Entities;
using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.Classifiers;
using Agro.DAL.Entities.DefaultData;
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Personnel;
using Agro.DAL.Entities.RegInfoOrg;
using Agro.DAL.Entities.Weight;
using Microsoft.EntityFrameworkCore;


namespace Agro.DAL;
public class AgroDb : DbContext
{
    #region DbSet
    public DbSet<Status> Statuses { get; set; } = null!;
    public DbSet<GroupDoc> Groups { get; set; } = null!;
    public DbSet<TypeDoc> Types { get; set; } = null!;
    public DbSet<BankDetails> BankDetails { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<UnitOkei> UnitsOkei { get; set; } = null!;
    public DbSet<Nds>  Ndses { get; set; } = null!;
    public DbSet<AccountingPlan> AccountingPlans { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Counterparty> Counterparties { get; set; } = null!;
    public DbSet<ScanFile> ScanFiles { get; set; } = null!;
    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<SpecificationContract> Specifications { get; set; } = null!;
    public DbSet<Organization> Organizations { get; set; } = null!;
    public DbSet<Okved> Okveds { get; set; } = null!;
    public DbSet<RegFns> RegFns { get; set; } = null!;
    public DbSet<RegPfr> RegPfr { get; set; } = null!;
    public DbSet<RegFss> RegFss { get; set; } = null!;
    public DbSet<Okato> Okato { get; set; } = null!;
    public DbSet<Okfs> Okfs { get; set; } = null!;
    public DbSet<Okogy> Okogy { get; set; } = null!;
    public DbSet<Okopf> Okopf { get; set; } = null!;
    public DbSet<Oktmo> Oktmo { get; set; } = null!;
    public DbSet<ProductInvoice> ProductsInvoice { get; set; } = null!;
    public DbSet<ReestrInvoice> ReestrInvoice { get; set; } = null!;
    public DbSet<Document> Documents { get; set; } = null!;
    public DbSet<People> People { get; set; } = null!;
    public DbSet<Employee> Employee { get; set; } = null!;
    public DbSet<StaffList> StaffList { get; set; } = null!;
    public DbSet<Post> Post { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Field> Fields { get; set; } = null!;
    public DbSet<Culture> Cultures { get; set; } = null!;
    public DbSet<LandPlot> LandPlots { get; set; } = null!;
    public DbSet<Transport> Transports { get; set; } = null!;
    public DbSet<Driver> Drivers { get; set; } = null!;
    public DbSet<Division> Divisions { get; set; } = null!;
    public DbSet<StaffListPosition> StaffListPositions { get; set; } = null!;

    public DbSet<Weight> Weights { get; set; } = null!;


#endregion
    public AgroDb(DbContextOptions<AgroDb> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder db)
    {
        var v = GetDefaultData.DefaultUnitOkeis();
        db.Entity<Status>().HasData(GetDefaultData.DefaultStatus());
        db.Entity<GroupDoc>().HasData(GetDefaultData.DefaultGroup());
        db.Entity<TypeDoc>().HasData(GetDefaultData.DefaultType());
        db.Entity<UnitOkei>().HasData(GetDefaultData.DefaultUnitOkeis());
        db.Entity<Nds>().HasData(GetDefaultData.DefaultNds());
        db.Entity<AccountingPlan>().HasData(GetDefaultData.DefaultAccountingPlans());
        
    }

    
}
