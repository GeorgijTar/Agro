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
        new () { Id = 8, Name = "Готовая продукция", TypeApplication="Товары"},
        new () { Id = 9, Name = "Материальные запасы", TypeApplication="Товары"},
    };

    public static GroupDoc[] DefaultGroup() => new GroupDoc[]
    {
        new () { Id = 1, Name = "Покупатели",TypeApplication="Контрагенты"},
        new () { Id = 2, Name = "Поставщики", TypeApplication="Контрагенты"},

        new () { Id = 3, Name = "Зерновые", TypeApplication="Готовая продукция"},
        new () { Id = 4, Name = "Масляничные", TypeApplication="Готовая продукция"},
        new () { Id = 5, Name = "Технические", TypeApplication="Готовая продукция"},
        new () { Id = 6, Name = "Отходы", TypeApplication="Готовая продукция"},

        new () { Id = 7, Name = "Средства защиты растений", TypeApplication="Материальные запасы"},
        new () { Id = 8, Name = "Удобрения", TypeApplication="Материальные запасы"},
        new () { Id = 9, Name = "Семена", TypeApplication="Материальные запасы"},
        new () { Id = 10, Name = "Запасные части", TypeApplication="Материальные запасы"},
        new () { Id = 11, Name = "Материалы", TypeApplication="Материальные запасы"},
        new () { Id = 12, Name = "Малоценные товары, инвентарь", TypeApplication="Материальные запасы"},
        new () { Id = 13, Name = "ГСМ", TypeApplication="Материальные запасы"},

    };

    public static UnitOkei[] DefaultUnitOkeis() => new UnitOkei[]
    {
        new UnitOkei(){Id = 1, Name = "Час", Abbreviation = "ч", OkeiCode = "356", StatusId = 5},
        new UnitOkei(){Id = 2, Name = "Миллиметр", Abbreviation = "мм", OkeiCode = "003", StatusId = 5},
        new UnitOkei(){Id = 3, Name = "Сантиметр", Abbreviation = "см", OkeiCode = "004", StatusId = 5},
        new UnitOkei(){Id = 4, Name = "Метр", Abbreviation = "м", OkeiCode = "006", StatusId = 5},
        new UnitOkei(){Id = 5, Name = "Грамм", Abbreviation = "г", OkeiCode = "163", StatusId = 5},
        new UnitOkei(){Id = 6, Name = "Килограмм", Abbreviation = "кг", OkeiCode = "166", StatusId = 5},
        new UnitOkei(){Id = 7, Name = "Тонна; метрическая тонна (1000 кг)", Abbreviation = "т", OkeiCode = "168", StatusId = 5},
        new UnitOkei(){Id = 8, Name = "Кубический метр", Abbreviation = "м3", OkeiCode = "113", StatusId = 5},
        new UnitOkei(){Id = 9, Name = "Квадратный метр", Abbreviation = "м2", OkeiCode = "055", StatusId = 5},
        new UnitOkei(){Id = 10, Name = "Гектар", Abbreviation = "га", OkeiCode = "059", StatusId = 5},
        new UnitOkei(){Id = 11, Name = "Киловатт-час", Abbreviation = "кВт.ч", OkeiCode = "245", StatusId = 5},
        new UnitOkei(){Id = 12, Name = "Лист", Abbreviation = "л.", OkeiCode = "625", StatusId = 5},
        new UnitOkei(){Id = 13, Name = "Пара (2 шт.)", Abbreviation = "пар", OkeiCode = "715", StatusId = 5},
        new UnitOkei(){Id = 14, Name = "Упаковка", Abbreviation = "упак", OkeiCode = "778", StatusId = 5},
        new UnitOkei(){Id = 15, Name = "Штука", Abbreviation = "шт", OkeiCode = "796", StatusId = 5},
        new UnitOkei(){Id = 16, Name = "Центнер (метрический) (100 кг)", Abbreviation = "ц", OkeiCode = "206", StatusId = 5},
    };

    public static Nds[] DefaultNds() => new Nds[]
    {
        new Nds(){Id = 1, Name = "Без НДС", Percent = 0},
        new Nds(){Id = 2, Name = "0%", Percent = 0},
        new Nds(){Id = 3, Name = "10%", Percent = 10},
        new Nds(){Id = 4, Name = "20%", Percent = 20},
    };
}
