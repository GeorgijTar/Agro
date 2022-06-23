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
        new () { Id = 6, Name = "Удален"},
    };

    public static TypeDoc[] DefaultType() => new TypeDoc[]
    {
        new () { Id = 1, Name = "Юридическое лицо", TypeApplication="Контрагенты"},
        new () { Id = 2, Name = "Индивидуальный предприниматель", TypeApplication="Контрагенты" },
        new () { Id = 3, Name = "Государственный орган", TypeApplication="Контрагенты" },
        new () { Id = 4, Name = "Физическое лицо", TypeApplication="Контрагенты"},
        new () { Id = 5, Name = "Юридический адрес", TypeApplication="Адреса"},
        new () { Id = 6, Name = "Фактический адрес", TypeApplication="Адреса"},
        new () { Id = 7, Name = "Почтовый адрес", TypeApplication="Адреса"},
    };

    public static GroupDoc[] DefaultGroup() => new GroupDoc[]
    {
        new () { Id = 1, Name = "Покупатели",TypeApplication="Контрагенты"},
        new () { Id = 2, Name = "Поставщики", TypeApplication="Контрагенты"},
    };
}
