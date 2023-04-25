using Agro.DAL.Entities;
using Agro.DAL.Entities.Accounting;
using Agro.DAL.Entities.Agronomy;
using Agro.DAL.Entities.Bank;
using Agro.DAL.Entities.Bank.Base;
using Agro.DAL.Entities.Bank.Pay;
using Agro.DAL.Entities.CheckingCounterparty;
using Agro.DAL.Entities.CheckingCounterparty.Components;
using Agro.DAL.Entities.Classifiers;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.DefaultData;
using Agro.DAL.Entities.General;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.DAL.Entities.Organization;
using Agro.DAL.Entities.Organization.RegInfoOrg;
using Agro.DAL.Entities.Personnel;
using Agro.DAL.Entities.Registers;
using Agro.DAL.Entities.Storage;
using Agro.DAL.Entities.TaxesType;
using Agro.DAL.Entities.Warehouse;
using Agro.DAL.Entities.Warehouse.Coming;
using Agro.DAL.Entities.Warehouse.Decommissioning;
using Agro.DAL.Entities.Weight;
using Microsoft.EntityFrameworkCore;
using Tax = Agro.DAL.Entities.CheckingCounterparty.Components.Tax;


namespace Agro.DAL;
public class AgroDb : DbContext
{
    #region DbSet

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Status> Statuses { get; set; } = null!;
    public DbSet<GroupDoc> Groups { get; set; } = null!;
    public DbSet<TypeDoc> Types { get; set; } = null!;
    public DbSet<BankDetails> BankDetails { get; set; } = null!;
    public DbSet<Currency> Currency { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<UnitOkei> UnitsOkei { get; set; } = null!;
    public DbSet<Nds> Ndses { get; set; } = null!;
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
    public DbSet<IdentityDocument> Documents { get; set; } = null!;
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
    public DbSet<ComingField> ComingFields { get; set; } = null!;
    public DbSet<StorageLocation> StorageLocations { get; set; } = null!;
    public DbSet<OfficialPerson> OfficialPersons { get; set; } = null!;
    public DbSet<Tmc> Tmc { get; set; } = null!;
    public DbSet<RulesAccounting> RulesAccounting { get; set; } = null!;
    public DbSet<Director> Directors { get; set; } = null!;
    public DbSet<Ogrn> Ogrn { get; set; } = null!;
    public DbSet<RegistryInvoice> RegistryInvoices { get; set; } = null!;
    public DbSet<Sitting> Sittings { get; set; } = null!;

    #region CheckingCounterparty
    public DbSet<ArbitrationCasesRecord> ArbitrationCasesRecords { get; set; } = null!;
    public DbSet<AuthorizedCapital> AuthorizedCapitals { get; set; } = null!;
    public DbSet<Balanceline> Balanceline { get; set; } = null!;
    public DbSet<Branch> Branchs { get; set; } = null!;
    public DbSet<CheckBalance> CheckBalances { get; set; } = null!;
    public DbSet<Contacts> Contacts { get; set; } = null!;
    public DbSet<DataIp> DataIp { get; set; } = null!;
    public DbSet<DataUl> DataUl { get; set; } = null!;
    public DbSet<Director> Director { get; set; } = null!;
    public DbSet<Divisions> Division { get; set; } = null!;
    public DbSet<Email> Email { get; set; } = null!;
    public DbSet<EnforcementProceedingRecord> EnforcementProceedingRecords { get; set; } = null!;
    public DbSet<FlMo> FlMo { get; set; } = null!;
    public DbSet<FounderFl> FounderFl { get; set; } = null!;
    public DbSet<FounderIn> FounderIn { get; set; } = null!;
    public DbSet<FounderMoRf> FounderMoRf { get; set; } = null!;
    public DbSet<FounderPif> FounderPif { get; set; } = null!;
    public DbSet<FounderUl> FounderUl { get; set; } = null!;
    public DbSet<HolderRegister> HolderRegisters { get; set; } = null!;
    public DbSet<LegalAddress> LegalAddress { get; set; } = null!;
    public DbSet<License> Licenses { get; set; } = null!;
    public DbSet<LicView> LicViews { get; set; } = null!;
    public DbSet<Likved> Likveds { get; set; } = null!;
    public DbSet<ManagingOrganization> ManagingOrganization { get; set; } = null!;
    public DbSet<Ogrn> Ogrns { get; set; } = null!;
    public DbSet<PaymentTax> PaymentTax { get; set; } = null!;
    public DbSet<Phone> Phones { get; set; } = null!;
    public DbSet<PlaintiffDefendant> PlaintiffDefendant { get; set; } = null!;
    public DbSet<Region> Regions { get; set; } = null!;
    public DbSet<Rmsp> Rmsp { get; set; } = null!;
    public DbSet<Share> Shares { get; set; } = null!;
    public DbSet<Tax> Tax { get; set; } = null!;
    public DbSet<Ul> Ul { get; set; } = null!;
    public DbSet<UlShort> UlShort { get; set; } = null!;
    public DbSet<UnscrupulousSupplierRecord> UnscrupulousSupplierRecord { get; set; } = null!;
    public DbSet<UrStatus> UrStatus { get; set; } = null!;
    public DbSet<CheckCounterparty> CheckCounterparty { get; set; } = null!;
    public DbSet<Founder> Founders { get; set; } = null!;
    public DbSet<FinancialStatement> FinancialStatements { get; set; } = null!;
    #endregion

    #region Registers

    public DbSet<TmcRegister> TmcRegisters { get; set; } = null!;
    public DbSet<AccountingPlanRegister> AccountingPlanRegisters { get; set; } = null!;

    #endregion

    #region Coming
    public DbSet<ComingTmc> ComingTmc { get; set; } = null!;
    public DbSet<ComingTmcCalculations> ComingTmcCalculations { get; set; } = null!;
    public DbSet<InvoiceFactur> InvoiceFacturs { get; set; } = null!;
    public DbSet<ComingTmcPosition> ComingTmcPositions { get; set; } = null!;
    public DbSet<AccountingMethodNds> AccountingMethodsNds { get; set; } = null!;
    #endregion

    #region Bank

    #region Base

    public DbSet<TypeCashFlow> TypeCashFlow { get; set; } = null!;
    public DbSet<ExpenditureItem> ExpenditureItems { get; set; } = null!;

    #endregion

    #region Pay
    public DbSet<BasisPayment> BasisPayment { get; set; } = null!;
    public DbSet<OrderPayment> OrderPayment { get; set; } = null!;
    public DbSet<PayerStatus> PayerStatus { get; set; } = null!;
    public DbSet<PaymentDestination> PaymentDestination { get; set; } = null!;
    public DbSet<PaymentOrder> PaymentOrder { get; set; } = null!;
    public DbSet<TaxPeriod> TaxPeriod { get; set; } = null!;
    public DbSet<TypePayment> TypePayment { get; set; } = null!;
    public DbSet<TypeTransactions> TypeTransactions { get; set; } = null!;
    public DbSet<TypeOperationPay> TypeOperationsPay { get; set; } = null!;

    #endregion

    public DbSet<DebitingAccount> DebitingAccount { get; set; } = null!;
    #endregion

    #region Taxes (Налоги)

    public DbSet<Tax> Taxes { get; set; } = null!;
    public DbSet<TaxKbk> TaxKbk { get; set; } = null!;
    public DbSet<TypeCommitment> TypesCommitments { get; set; } = null!;

    #endregion

    public DbSet<ClosedPeriod> ClosedPeriod { get; set; } = null!;

    #region DecommissioningTmc
    public DbSet<DecommissioningTmc> DecommissioningTmc { get; set; } = null!;
    public DbSet<PositionDecommissioningTmc> PositionDecommissioningTmc { get; set; } = null!;
    public DbSet<PurposeExpenditure> PurposeExpenditures { get; set; } = null!;
    public DbSet<WriteOffObject> WriteOffObjects { get; set; } = null!;
    public DbSet<TypeObject> TypesObject { get; set; } = null!;
    public DbSet<GroupObject> GroupObjects { get; set; } = null!;


    #endregion

    #endregion


    public AgroDb(DbContextOptions<AgroDb> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder db)
    {
        db.Entity<Status>().HasData(GetDefaultData.DefaultStatus());
        db.Entity<GroupDoc>().HasData(GetDefaultData.DefaultGroup());
        db.Entity<TypeDoc>().HasData(GetDefaultData.DefaultType());
        db.Entity<UnitOkei>().HasData(GetDefaultData.DefaultUnitOkeis());
        db.Entity<Nds>().HasData(GetDefaultData.DefaultNds());
        db.Entity<AccountingPlan>().HasData(GetDefaultData.DefaultAccountingPlans());
        db.Entity<Sitting>().HasData(GetDefaultData.DefaultSittings());
        db.Entity<User>().HasData(GetDefaultData.DefaultUsers());
        db.Entity<TypeCashFlow>().HasData(GetDefaultData.DefaultTypeCashFlow());
        db.Entity<BasisPayment>().HasData(GetDefaultData.DefaultBasisPayment());
        db.Entity<TypeTransactions>().HasData(GetDefaultData.DefaultTypeTransactions());
        db.Entity<OrderPayment>().HasData(GetDefaultData.DefaultOrderPayment());
        db.Entity<PaymentDestination>().HasData(GetDefaultData.DefaultPaymentDestination());
        db.Entity<TypePayment>().HasData(GetDefaultData.DefaultTypePayment());
        db.Entity<PayerStatus>().HasData(GetDefaultData.DefaultPayerStatus());
        db.Entity<TypeOperationPay>().HasData(GetDefaultData.DefaultTypeOperationPye());
        db.Entity<TypeCommitment>().HasData(GetDefaultData.DefaultTypeCommitment());
        db.Entity<Currency>().HasData(GetDefaultData.DefaultCurrency());
        db.Entity<AccountingMethodNds>().HasData(GetDefaultData.DefaultAccountingMethodNds());
    }


}
