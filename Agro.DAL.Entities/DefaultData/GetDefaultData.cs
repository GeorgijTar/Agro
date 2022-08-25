﻿namespace Agro.DAL.Entities.DefaultData;

public static class GetDefaultData
{
    public static Status[] DefaultStatus() => new Status[]
    {
        new() { Id = 1, Name = "Черновик" },
        new() { Id = 2, Name = "Новый" },
        new() { Id = 3, Name = "Действующий" },
        new() { Id = 4, Name = "Заблокировано" },
        new() { Id = 5, Name = "Актуально" },
        new() { Id = 6, Name = "Удален" },
        new() { Id = 7, Name = "Архивный" },
        new() { Id = 8, Name = "Принят к оплате" },
        new() { Id = 9, Name = "Готов к оплате" },
        new() { Id = 10, Name = "Оплачен" },
        new() { Id = 11, Name = "Выставлен" },
        new() { Id = 12, Name = "Отправлен" },
        new() { Id = 13, Name = "Ошибка отправки" },
    };

    public static TypeDoc[] DefaultType() => new TypeDoc[]
    {
        new() { Id = 1, Name = "Юридическое лицо", TypeApplication = "Контрагенты" },
        new() { Id = 2, Name = "Индивидуальный предприниматель", TypeApplication = "Контрагенты" },
        new() { Id = 3, Name = "Государственный орган", TypeApplication = "Контрагенты" },
        new() { Id = 4, Name = "Физическое лицо", TypeApplication = "Контрагенты" },
        new() { Id = 5, Name = "Юридический адрес", TypeApplication = "Адреса" },
        new() { Id = 6, Name = "Фактический адрес", TypeApplication = "Адреса" },
        new() { Id = 7, Name = "Почтовый адрес", TypeApplication = "Адреса" },
        new() { Id = 8, Name = "Готовая продукция", TypeApplication = "Товары" },
        new() { Id = 9, Name = "Материальные запасы", TypeApplication = "Товары" },
        new() { Id = 10, Name = "Выставленные", TypeApplication = "Счета" },
        new() { Id = 11, Name = "Полученные", TypeApplication = "Счета" },
        new() { Id = 12, Name = "Удостоверение личности", TypeApplication = "Документ" },
        new() { Id = 13, Name = "Собственность", TypeApplication = "ЗУ" },
        new() { Id = 14, Name = "Аренда", TypeApplication = "ЗУ" },
        new() { Id = 15, Name = "Прочие документы", TypeApplication = "Документ" },
    };

    public static GroupDoc[] DefaultGroup() => new GroupDoc[]
    {
        new() { Id = 1, Name = "Покупатели", TypeApplication = "Контрагенты" },
        new() { Id = 2, Name = "Поставщики", TypeApplication = "Контрагенты" },
        new() { Id = 3, Name = "Зерновые", TypeApplication = "Готовая продукция" },
        new() { Id = 4, Name = "Масляничные", TypeApplication = "Готовая продукция" },
        new() { Id = 5, Name = "Технические", TypeApplication = "Готовая продукция" },
        new() { Id = 6, Name = "Отходы", TypeApplication = "Готовая продукция" },
        new() { Id = 7, Name = "Средства защиты растений", TypeApplication = "Материальные запасы" },
        new() { Id = 8, Name = "Удобрения", TypeApplication = "Материальные запасы" },
        new() { Id = 9, Name = "Семена", TypeApplication = "Материальные запасы" },
        new() { Id = 10, Name = "Запасные части", TypeApplication = "Материальные запасы" },
        new() { Id = 11, Name = "Материалы", TypeApplication = "Материальные запасы" },
        new() { Id = 12, Name = "Малоценные товары, инвентарь", TypeApplication = "Материальные запасы" },
        new() { Id = 13, Name = "ГСМ", TypeApplication = "Материальные запасы" },
        new() { Id = 14, Name = "Паспорт гражданина РФ", TypeApplication = "Удостоверение личности" },
        new() { Id = 15, Name = "Загранпаспорт гражданина РФ", TypeApplication = "Удостоверение личности" },
        new() { Id = 16, Name = "Свидетельство о рождении", TypeApplication = "Удостоверение личности" },
        new() { Id = 17, Name = "Временное удостоверение личности", TypeApplication = "Удостоверение личности" },
        new() { Id = 18, Name = "Удостоверение личности военнослужащего РФ (военный билет, паспорт моряка)", TypeApplication = "Удостоверение личности" },
        new() { Id = 19, Name = "Вид на жительство", TypeApplication = "Удостоверение личности" },
        new() { Id = 20, Name = "Прочий документ", TypeApplication = "Прочие документы" },
    };

    public static UnitOkei[] DefaultUnitOkeis() => new UnitOkei[]
    {
        new () { Id = 1, Name = "Час", Abbreviation = "ч", OkeiCode = "356"},
        new () { Id = 2, Name = "Миллиметр", Abbreviation = "мм", OkeiCode = "003"},
        new () { Id = 3, Name = "Сантиметр", Abbreviation = "см", OkeiCode = "004"},
        new () { Id = 4, Name = "Метр", Abbreviation = "м", OkeiCode = "006"},
        new () { Id = 5, Name = "Грамм", Abbreviation = "г", OkeiCode = "163"},
        new () { Id = 6, Name = "Килограмм", Abbreviation = "кг", OkeiCode = "166"},
        new () { Id = 7, Name = "Тонна; метрическая тонна (1000 кг)", Abbreviation = "т", OkeiCode = "168"},
        new () { Id = 8, Name = "Кубический метр", Abbreviation = "м3", OkeiCode = "113"},
        new () { Id = 9, Name = "Квадратный метр", Abbreviation = "м2", OkeiCode = "055"},
        new () { Id = 10, Name = "Гектар", Abbreviation = "га", OkeiCode = "059"},
        new () { Id = 11, Name = "Киловатт-час", Abbreviation = "кВт.ч", OkeiCode = "245"},
        new () { Id = 12, Name = "Лист", Abbreviation = "л.", OkeiCode = "625"},
        new () { Id = 13, Name = "Пара (2 шт.)", Abbreviation = "пар", OkeiCode = "715"},
        new () { Id = 14, Name = "Упаковка", Abbreviation = "упак", OkeiCode = "778"},
        new () { Id = 15, Name = "Штука", Abbreviation = "шт", OkeiCode = "796"},
        new () { Id = 16, Name = "Центнер (метрический) (100 кг)", Abbreviation = "ц", OkeiCode = "206"},
    };

    public static Nds[] DefaultNds() => new Nds[]
    {
        new () { Id = 1, Name = "Без НДС", Percent = 0, OverPercent = 1},
        new () { Id = 2, Name = "0%", Percent = 0, OverPercent = 1},
        new () { Id = 3, Name = "10%", Percent = 10, OverPercent = (decimal)1.1},
        new () { Id = 4, Name = "20%", Percent = 20, OverPercent = (decimal)1.2},
    };

    public static AccountingPlan[] DefaultAccountingPlans()=> new AccountingPlan[]
    {
        new () {Id = 1, StatusId = 5, Code = "Раздел I", Name = "Внеоборотные активы", IsSelect = false},
        new () {Id = 2, StatusId = 5, Code = "01", Name = "Основные средства в организации", ParentPlanId = 1, IsSelect = false},
        new () {Id = 3, StatusId = 5, Code = "01-1", Name = "Основные средства в организации (Недвижимое имущество)", ParentPlanId = 2, IsSelect = true},
        new () {Id = 4, StatusId = 5, Code = "01-2", Name = "Основные средства в организации (Движимое имущество)", ParentPlanId = 2, IsSelect = true},
        new () {Id = 5, StatusId = 5, Code = "01-6", Name = "Земельные участки", ParentPlanId = 2, IsSelect = true},
        new () {Id = 6, StatusId = 5, Code = "01-4", Name = "Выбытие основных спедств", ParentPlanId = 2 , IsSelect = true},
        new () {Id = 7, StatusId = 5, Code = "02", Name = "Амортизация ОС", ParentPlanId = 1, IsSelect = false},
        new () {Id = 8, StatusId = 5, Code = "02-1", Name = "Амортизация основных средств, являющихся недвижимым имуществом", ParentPlanId = 7, IsSelect = true},
        new () {Id = 9, StatusId = 5, Code = "02-2", Name = "Амортизация основных средств, являющихся движимым имуществом", ParentPlanId = 7, IsSelect = true},
        new () {Id = 10, StatusId = 5, Code = "02-3", Name = "Амортизация арендованных основных средств", ParentPlanId = 7, IsSelect = true},
        new () {Id = 11, StatusId = 5, Code = "03", Name = "Доходные вложения в материальные ценности", ParentPlanId = 1, IsSelect = true},
        new () {Id = 12, StatusId = 5, Code = "04", Name = "Нематериальные активы", ParentPlanId = 1, IsSelect = true},
        new () {Id = 13, StatusId = 5, Code = "05", Name = "Амортизация нематериальных активов", ParentPlanId = 1, IsSelect = true},
        new () {Id = 14, StatusId = 5, Code = "07", Name = "Оборудование к установке", ParentPlanId = 1, IsSelect = true},
        new () {Id = 15, StatusId = 5, Code = "08", Name = "Вложения во внеоборотные активы", ParentPlanId = 1, IsSelect = false},
        new () {Id = 16, StatusId = 5, Code = "08-1", Name = "Приобретение земельных участков", ParentPlanId = 15, IsSelect = true},
        new () {Id = 17, StatusId = 5, Code = "08-2", Name = "Приобретение объектов природопользования", ParentPlanId = 15, IsSelect = true},
        new () {Id = 18, StatusId = 5, Code = "08-3", Name = "Строительство объектов основных средств", ParentPlanId = 15, IsSelect = true},
        new () {Id = 19, StatusId = 5, Code = "08-3-1", Name = "Строительство объектов основных средств (Ангар)", ParentPlanId = 18, IsSelect = true},
        new () {Id = 20, StatusId = 5, Code = "08-4", Name = "Приобретение объектов основных средств", ParentPlanId = 15, IsSelect = true},
        new () {Id = 21, StatusId = 5, Code = "08-5", Name = "Приобретение нематериальных активов", ParentPlanId = 15, IsSelect = true},
        new () {Id = 22, StatusId = 5, Code = "08-6", Name = "Закладка и выращивание многолетних насаждений", ParentPlanId = 15, IsSelect = true},
        new () {Id = 23, StatusId = 5, Code = "08-7", Name = "Выполнение научно-исследовательских, опытно-конструкторских и технологических работ", ParentPlanId = 15, IsSelect = true},
        new () {Id = 24, StatusId = 5, Code = "09", Name = "Отложенные налоговые активы", ParentPlanId = 1, IsSelect = true},
        new () {Id = 25, StatusId = 5, Code = "10", Name = "Материалы", ParentPlanId = 44, IsSelect = false},
        new () {Id = 26, StatusId = 5, Code = "10-1", Name = "Сырье и материалы", ParentPlanId = 25, IsSelect = true},
        new () {Id = 27, StatusId = 5, Code = "10-2", Name = "Семена и посадочный материал", ParentPlanId = 25, IsSelect = true},
        new () {Id = 28, StatusId = 5, Code = "10-3", Name = "Топливо (ГСМ)", ParentPlanId = 25, IsSelect = true},
        new () {Id = 29, StatusId = 5, Code = "10-4", Name = "Покупные полуфабрикаты и комплектующие изделия, конструкции и детали", ParentPlanId = 25, IsSelect = true},
        new () {Id = 30, StatusId = 5, Code = "10-5", Name = "Запасные части", ParentPlanId = 25, IsSelect = true},
        new () {Id = 31, StatusId = 5, Code = "10-6", Name = "Удобрения, средства защиты растений", ParentPlanId = 25, IsSelect = true},
        new () {Id = 32, StatusId = 5, Code = "10-8", Name = "Тара и тарные материалы", ParentPlanId = 25, IsSelect = true},
        new () {Id = 33, StatusId = 5, Code = "10-9", Name = "Инвентарь и хозяйственные принадлежности", ParentPlanId = 25, IsSelect = true},
        new () {Id = 34, StatusId = 5, Code = "10-10", Name = "Специальная одежда, средства индивидуальной защиты", ParentPlanId = 25, IsSelect = true},
        new () {Id = 35, StatusId = 5, Code = "10-11", Name = "Материалы и сырье, переданные в переработку на сторону", ParentPlanId = 25, IsSelect = true},
        new () {Id = 36, StatusId = 5, Code = "10-12", Name = "Прочие материалы", ParentPlanId = 25, IsSelect = true},
        new () {Id = 37, StatusId = 5, Code = "14", Name = "Резервы под снижение стоимости материальных ценностей", ParentPlanId = 44, IsSelect = false},
        new () {Id = 38, StatusId = 5, Code = "14-1", Name = "Резервы под снижение стоимости материалов", ParentPlanId = 37, IsSelect = true},
        new () {Id = 39, StatusId = 5, Code = "14-2", Name = "Резервы под снижение стоимости товаров", ParentPlanId = 37, IsSelect = true},
        new () {Id = 40, StatusId = 5, Code = "14-3", Name = "Резервы под снижение стоимости готовой продукции", ParentPlanId = 37, IsSelect = true},
        new () {Id = 41, StatusId = 5, Code = "19", Name = "НДС по приобретенным ценностям", ParentPlanId = 44, IsSelect = false},
        new () {Id = 42, StatusId = 5, Code = "19-1", Name = "НДС по приобретенным товарно-материальным ценностям, работам, услугам", ParentPlanId = 41, IsSelect = true},
        new () {Id = 43, StatusId = 5, Code = "19-2", Name = "НДС по приобретённым продуктам питания", ParentPlanId = 41, IsSelect = true},
        new () {Id = 44, StatusId = 5, Code = "Раздел II", Name = "Производственные запасы", IsSelect = false},
        new () {Id = 45, StatusId = 5, Code = "Раздел III", Name = "Затраты на производство", IsSelect = false},
        new () {Id = 46, StatusId = 5, Code = "20", Name = "Основное производство", ParentPlanId = 45, IsSelect = false},
        new () {Id = 47, StatusId = 5, Code = "20-1", Name = "Основное производство - Растениеводство", ParentPlanId = 46, IsSelect = true},
        new () {Id = 48, StatusId = 5, Code = "20-3", Name = "Сортировка сельхоз продукции", ParentPlanId = 46, IsSelect = true},
        new () {Id = 49, StatusId = 5, Code = "21", Name = "Полуфабрикаты собственного производства", ParentPlanId = 45, IsSelect = true},
        new () {Id = 50, StatusId = 5, Code = "23", Name = "Вспомогательные производства", ParentPlanId = 45, IsSelect = false},
        new () {Id = 51, StatusId = 5, Code = "23-2", Name = "Ремонт зданий, сооружений и сельхоз техники", ParentPlanId = 50, IsSelect = true},
        new () {Id = 52, StatusId = 5, Code = "23-3", Name = "Электроснабжение", ParentPlanId = 50, IsSelect = true},
        new () {Id = 53, StatusId = 5, Code = "23-4", Name = "Водоснаюжение", ParentPlanId = 50, IsSelect = true},
        new () {Id = 54, StatusId = 5, Code = "23-5", Name = "Автотранспорт", ParentPlanId = 50, IsSelect = true},
        new () {Id = 55, StatusId = 5, Code = "23-6", Name = "Газоснабжение", ParentPlanId = 50, IsSelect = true},
        new () {Id = 56, StatusId = 5, Code = "25", Name = "Общепроизводственные расходы", ParentPlanId = 45, IsSelect = false},
        new () {Id = 57, StatusId = 5, Code = "25-1", Name = "Общепроизводственные расходы - Растениеводства", ParentPlanId = 56, IsSelect = true},
        new () {Id = 58, StatusId = 5, Code = "26", Name = "Общехозяйственные расходы", ParentPlanId = 45, IsSelect = true},
        new () {Id = 59, StatusId = 5, Code = "Раздел IV", Name = "Готовая продукция и товары", IsSelect = false},
        new () {Id = 60, StatusId = 5, Code = "40", Name = "Выпуск продукции (Продукция с поля)", ParentPlanId = 59, IsSelect = true},
        new () {Id = 61, StatusId = 5, Code = "41", Name = "Товары", ParentPlanId = 59, IsSelect = false},
        new () {Id = 62, StatusId = 5, Code = "41-1", Name = "Товары на складах", ParentPlanId = 61, IsSelect = true},
        new () {Id = 63, StatusId = 5, Code = "41-2", Name = "Товары к продаже", ParentPlanId = 61, IsSelect = true},
        new () {Id = 64, StatusId = 5, Code = "43", Name = "Готовая продукция", ParentPlanId = 59, IsSelect = false},
        new () {Id = 65, StatusId = 5, Code = "43-1", Name = "Готовая продукция - Растениеводства", ParentPlanId = 64, IsSelect = true},
        new () {Id = 66, StatusId = 5, Code = "Раздел V", Name = "Денежные средства", IsSelect = false},
        new () {Id = 67, StatusId = 5, Code = "50", Name = "Касса", ParentPlanId = 66, IsSelect = true},
        new () {Id = 68, StatusId = 5, Code = "51", Name = "Расчетные счета", ParentPlanId = 66, IsSelect = false},
        new () {Id = 69, StatusId = 5, Code = "51-1", Name = "Расчетный счет в Россельхозбанке", ParentPlanId = 68, IsSelect = true},
        new () {Id = 70, StatusId = 5, Code = "51-2", Name = "Расчетный счет в ОТП", ParentPlanId = 68, IsSelect = true},
        new () {Id = 71, StatusId = 5, Code = "51-3", Name = "Расчетный счет в Сбербанке", ParentPlanId = 68, IsSelect = true},
        new () {Id = 72, StatusId = 5, Code = "52", Name = "Валютные счета", ParentPlanId = 66, IsSelect = false},
        new () {Id = 73, StatusId = 5, Code = "52-1", Name = "Валютные счета внутри страны", ParentPlanId = 72, IsSelect = true},
        new () {Id = 74, StatusId = 5, Code = "55", Name = "Специальные счета в банках", ParentPlanId = 66, IsSelect = false},
        new () {Id = 75, StatusId = 5, Code = "55-3", Name = "Депозитные счета", ParentPlanId = 74, IsSelect = true},
        new () {Id = 76, StatusId = 5, Code = "57", Name = "Переводы в пути", ParentPlanId = 66, IsSelect = true},
        new () {Id = 77, StatusId = 5, Code = "Раздел VI", Name = "Расчеты", IsSelect = false},
        new () {Id = 78, StatusId = 5, Code = "60", Name = "Расчеты с поставщиками и подрядчиками", ParentPlanId = 77, IsSelect = false},
        new () {Id = 79, StatusId = 5, Code = "60-1", Name = "Расчеты с поставщиками и подрядчиками", ParentPlanId = 78, IsSelect = true},
        new () {Id = 80, StatusId = 5, Code = "60-2", Name = "Расчеты с поставщиками и подрядчиками по авансам выданным", ParentPlanId = 78, IsSelect = true},
        new () {Id = 81, StatusId = 5, Code = "62", Name = "Расчеты с покупателями, заказчиками", ParentPlanId = 77, IsSelect = false},
        new () {Id = 82, StatusId = 5, Code = "62-1", Name = "Расчеты с покупателями, заказчиками", ParentPlanId = 81, IsSelect = true},
        new () {Id = 137, StatusId = 5, Code = "62-2", Name = "Расчеты с покупателями, заказчиками по авансам полученным", ParentPlanId = 81, IsSelect = true},
        new () {Id = 83, StatusId = 5, Code = "66", Name = "Расчеты по краткосрочным кредитам и займам", ParentPlanId = 77, IsSelect = false},
        new () {Id = 84, StatusId = 5, Code = "67", Name = "Расчеты по долгосрочным кредитам и займам", ParentPlanId = 77, IsSelect = false},
        new () {Id = 85, StatusId = 5, Code = "68", Name = "Расчеты по налогам и сборам", ParentPlanId = 77, IsSelect = false},
        new () {Id = 86, StatusId = 5, Code = "68-1", Name = "НДС с реализованной продукции", ParentPlanId = 85, IsSelect = true},
        new () {Id = 87, StatusId = 5, Code = "68-3", Name = "Налог на доходы физических лиц", ParentPlanId = 85, IsSelect = true},
        new () {Id = 88, StatusId = 5, Code = "68-3Д", Name = "Налог на доходы физических лиц с дивидендов", ParentPlanId = 85, IsSelect = true},
        new () {Id = 89, StatusId = 5, Code = "68-4", Name = "Налог на прибыль организаций", ParentPlanId = 85, IsSelect = true},
        new () {Id = 90, StatusId = 5, Code = "68-5", Name = "Транспортный налог с организаций", ParentPlanId = 85, IsSelect = true},
        new () {Id = 91, StatusId = 5, Code = "68-6", Name = "Налог на имущество организаций", ParentPlanId = 85, IsSelect = true},
        new () {Id = 92, StatusId = 5, Code = "68-7", Name = "Земельный налог с организаций", ParentPlanId = 85, IsSelect = true},
        new () {Id = 93, StatusId = 5, Code = "69", Name = "Расчеты по социальному страхованию и обеспечению", ParentPlanId = 77, IsSelect = false},
        new () {Id = 94, StatusId = 5, Code = "69-1", Name = "Расчеты по социальному страхованию", ParentPlanId = 93, IsSelect = false},
        new () {Id = 95, StatusId = 5, Code = "69-1-1", Name = "Расчеты по обязательному социальному страхованию", ParentPlanId = 94, IsSelect = true},
        new () {Id = 96, StatusId = 5, Code = "69-1-2", Name = "Расчеты по обязательному социальному страхованию от несчастных случаев", ParentPlanId = 94, IsSelect = true},
        new () {Id = 97, StatusId = 5, Code = "69-2", Name = "Расчеты по пенсионному обеспечению", ParentPlanId = 93, IsSelect = true},
        new () {Id = 98, StatusId = 5, Code = "69-3", Name = "Расчеты по обязательному медицинскому страхованию", ParentPlanId = 93, IsSelect = true},
        new () {Id = 99, StatusId = 5, Code = "70", Name = "Расчеты с персоналом по оплате труда", ParentPlanId = 77, IsSelect = true},
        new () {Id = 100, StatusId = 5, Code = "71", Name = "Расчеты с подотчетными лицами", ParentPlanId = 77, IsSelect = true},
        new () {Id = 101, StatusId = 5, Code = "73", Name = "Расчеты с персоналом по прочим операциям", ParentPlanId = 77, IsSelect = true},
        new () {Id = 102, StatusId = 5, Code = "75", Name = "Расчеты с учредителями", ParentPlanId = 77, IsSelect = true},
        new () {Id = 103, StatusId = 5, Code = "76", Name = "Расчеты с разными дебиторами и кредиторами", ParentPlanId = 77, IsSelect = true},
        new () {Id = 104, StatusId = 5, Code = "76АВ", Name = "Расчеты с разными дебиторами и кредиторами по авансам полученным", ParentPlanId = 103, IsSelect = true},
        new () {Id = 105, StatusId = 5, Code = "76ВА", Name = "Расчеты с разными дебиторами и кредиторами по авансам выданным", ParentPlanId = 103, IsSelect = true},
        new () {Id = 106, StatusId = 5, Code = "Раздел VII", Name = "Капитал", IsSelect = false},
        new () {Id = 107, StatusId = 5, Code = "80", Name = "Уставный капитал", ParentPlanId = 106, IsSelect = true},
        new () {Id = 108, StatusId = 5, Code = "83", Name = "Нераспределенная прибыль (непокрытый убыток)", ParentPlanId = 106, IsSelect = true},
        new () {Id = 109, StatusId = 5, Code = "84", Name = "Добавочный капитал", ParentPlanId = 106, IsSelect = true},
        new () {Id = 110, StatusId = 5, Code = "86", Name = "Целевое финансирование", ParentPlanId = 106, IsSelect = true},
        new () {Id = 111, StatusId = 5, Code = "Раздел VIII", Name = "Финансовые результаты", IsSelect = false},
        new () {Id = 112, StatusId = 5, Code = "90", Name = "Продажи", ParentPlanId = 111, IsSelect = false},
        new () {Id = 113, StatusId = 5, Code = "90-1", Name = "Реализацйия продукции растениеводства", ParentPlanId = 112, IsSelect = true},
        new () {Id = 114, StatusId = 5, Code = "90-3", Name = "Реализацйия прочей продукции и ТМЦ", ParentPlanId = 112, IsSelect = true},
        new () {Id = 115, StatusId = 5, Code = "91", Name = "Прочие доходы и расходы", ParentPlanId = 111, IsSelect = false},
        new () {Id = 116, StatusId = 5, Code = "91-1", Name = "Прочие доходы", ParentPlanId = 115, IsSelect = true},
        new () {Id = 117, StatusId = 5, Code = "91-2", Name = "Прочие расходы", ParentPlanId = 115, IsSelect = true},
        new () {Id = 118, StatusId = 5, Code = "91-9", Name = "Сальдо прочих доходов и расходов", ParentPlanId = 115, IsSelect = true},
        new () {Id = 119, StatusId = 5, Code = "94", Name = "Недостачи и потери от порчи ценностей", ParentPlanId = 111, IsSelect = true},
        new () {Id = 120, StatusId = 5, Code = "96", Name = "Резервы предстоящих расходов", ParentPlanId = 111, IsSelect = false},
        new () {Id = 121, StatusId = 5, Code = "96-1", Name = "Резерв на оплату отпусков", ParentPlanId = 120, IsSelect = true},
        new () {Id = 122, StatusId = 5, Code = "97", Name = "Расходы будущих периодов", ParentPlanId = 111, IsSelect = true},
        new () {Id = 123, StatusId = 5, Code = "99", Name = "Прибыли и убытки", ParentPlanId = 111, IsSelect = true},
        new () {Id = 124, StatusId = 5, Code = "Раздел IX", Name = "Забалансовые счета", IsSelect = false},
        new () {Id = 125, StatusId = 5, Code = "001", Name = "Арендованные основные средства", ParentPlanId = 124, IsSelect = true},
        new () {Id = 126, StatusId = 5, Code = "002", Name = "Товарно-материальные ценности, принятые на ответственное хранение", ParentPlanId = 124, IsSelect = true},
        new () {Id = 127, StatusId = 5, Code = "003", Name = "Материалы, принятые в переработку", ParentPlanId = 124, IsSelect = true},
        new () {Id = 128, StatusId = 5, Code = "004", Name = "Товары, принятые на комиссию", ParentPlanId = 124, IsSelect = true},
        new () {Id = 129, StatusId = 5, Code = "005", Name = "Оборудование, принятое для монтажа", ParentPlanId = 124, IsSelect = true},
        new () {Id = 130, StatusId = 5, Code = "006", Name = "Бланки строгой отчетности", ParentPlanId = 124, IsSelect = true},
        new () {Id = 131, StatusId = 5, Code = "007", Name = "Списанная в убыток задолженность неплатежеспособных дебиторов", ParentPlanId = 124, IsSelect = true},
        new () {Id = 132, StatusId = 5, Code = "008", Name = "Обеспечение обязательств и платежей (полученные)", ParentPlanId = 124, IsSelect = true},
        new () {Id = 133, StatusId = 5, Code = "009", Name = "Обеспечение обязательств и платежей (выданные)", ParentPlanId = 124, IsSelect = true},
        new () {Id = 134, StatusId = 5, Code = "010", Name = "Износ основных средств", ParentPlanId = 124, IsSelect = true},
        new () {Id = 135, StatusId = 5, Code = "011", Name = "Основные средства, сданные в аренду", ParentPlanId = 124, IsSelect = true},
        new () {Id = 136, StatusId = 5, Code = "012", Name = "Земельные угодья", ParentPlanId = 124, IsSelect = true},
};
}