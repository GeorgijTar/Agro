namespace Agro.DAL.Entities.DefaultData;
public static class GetDefaultData
{
    public static Status[] DefaultStatus() => new Status[]
    {
        new () { Id = 1, Name = "Черновик" },
        new () { Id = 2, Name = "Новый" },
        new () { Id = 3, Name = "Действующий" },
        new () { Id = 4, Name = "Заблокировано"},
        new () { Id = 5, Name = "Актуально"},
    };

    public static Type[] DefaultType() => new Type[]
    {
        new () { Id = 1, Name = "Юридическое лицо", TypeApplication="Counterparty"},
        new () { Id = 2, Name = "Индивидуальный предприниматель", TypeApplication="Counterparty" },
        new () { Id = 3, Name = "Государственный орган", TypeApplication="Counterparty" },
        new () { Id = 4, Name = "Физическое лицо", TypeApplication="Counterparty"},
        new () { Id = 5, Name = "Юридический адрес", TypeApplication="Address"},
        new () { Id = 6, Name = "Фактический адрес", TypeApplication="Address"},
        new () { Id = 7, Name = "Почтовый адрес", TypeApplication="Address"},
    };

    public static Group[] DefaultGroup() => new Group[]
    {   
        new () { Id = 1, Name = "Контрагенты"},
        new () { Id = 2, Name = "Покупатели" },
        new () { Id = 3, Name = "Поставщики" },
    };
}
