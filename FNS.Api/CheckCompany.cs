using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Agro.DAL.Entities.CheckingCounterparty;
using System.Text.Json.Nodes;
using Agro.DAL.Entities.CheckingCounterparty.Components;
using Agro.DAL.Entities.Classifiers;
using Agro.DAL.Entities.Organization.RegInfoOrg;
using System.Text;

namespace FNS.Api;
public static class CheckCompany
{
    private const string ApiKey = "zpKipA8XmoNldFmM";
    public static async Task<CheckCounterparty> ChecAsync(string inn)
    {
        if (inn.Length == 10) return await GetChecUlAsync(inn);
        if (inn.Length == 12) return await GetChecIpAsync(inn);
        return null!;
    }

    private static Task<CheckCounterparty> GetChecIpAsync(string inn)
    {
        throw new NotImplementedException();
    }


    private static async Task<CheckCounterparty> GetChecUlAsync(string inn)
    {
        var client = new HttpClient();
        var uri = new Uri($"https://api.checko.ru/v2/company?key={ApiKey}&inn={inn}");
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        JsonNode? json = JsonNode.Parse(result);
        var ss = json!["meta"]!["message"]!;
        if (ss != null!) throw new InvalidOperationException(json["meta"]!["message"]!.ToString());
        var checkCounterparty = new CheckCounterparty();
        DataUl dataUl = new();
        dataUl.Ogrn = json["data"]!["ОГРН"]!.ToString();
        dataUl.Inn = json["data"]!["ИНН"]!.ToString();
        dataUl.Kpp = json["data"]!["КПП"]!.ToString();
        dataUl.Okpo = json["data"]!["ОКПО"]!.ToString();
        dataUl.DateReg = json["data"]!["ДатаРег"]!.GetValue<DateTime>();
        dataUl.DateROgrn = json["data"]!["ДатаОГРН"]!.GetValue<DateTime>();
        dataUl.ShortName = json["data"]!["НаимСокр"]!.ToString();
        dataUl.FullName = json["data"]!["НаимПолн"]!.ToString();

        dataUl.Status = new()
        {
            Name = json["data"]!["Статус"]!["Наим"]!.ToString(),
            Code = json["data"]!["Статус"]!["Код"]!.ToString(),

        };
        if (json["data"]!["Статус"]!["ОгрДоступ"] != null!)
            dataUl.Status.OgrDostup = bool.Parse(json["data"]!["Статус"]!["ОгрДоступ"]!.ToString());

        if (json["data"]!["Ликвид"] != null!)
        {
            dataUl.Likved = new Likved()
            {
                Date = json["data"]!["Ликвид"]!["Дата"]!.ToString(),
                Name = json["data"]!["Ликвид"]!["Наим"]!.ToString()
            };
        }
        dataUl.Region = new Region()
        {
            Code = json["data"]!["Регион"]!["Код"]!.ToString(),
            Name = json["data"]!["Регион"]!["Наим"]!.ToString()
        };
        dataUl.LegalAddress = new LegalAddress()
        {
            Locality = json["data"]!["ЮрАдрес"]!["НасПункт"]!.ToString(),
            Address = json["data"]!["ЮрАдрес"]!["АдресРФ"]!.ToString(),
            IdGar = json["data"]!["ЮрАдрес"]!["ИдГАР"] != null ? json["data"]!["ЮрАдрес"]!["ИдГАР"]!.ToString() : null,
            Unreliability = json["data"]!["ЮрАдрес"]!["Недост"]!.GetValue<bool>(),
            Description = json["data"]!["ЮрАдрес"]!["НедостОпис"] != null ? json["data"]!["ЮрАдрес"]!["НедостОпис"]!.ToString() : null,


        };

        dataUl.Okved = new Okved()
        {
            Code = json["data"]!["ОКВЭД"]!["Код"]!.ToString(),
            Name = json["data"]!["ОКВЭД"]!["Наим"]!.ToString(),
            Version = json["data"]!["ОКВЭД"]!["Версия"]!.ToString()
        };

        ObservableCollection<Okved> okveds = new();
        foreach (var js in json["data"]!["ОКВЭДДоп"]!.AsArray())
        {
            okveds.Add(new Okved()
            {
                Code = js!["Код"]!.ToString(),
                Name = js["Наим"]!.ToString(),
                Version = js["Версия"]!.ToString()
            });
        }
        dataUl.Okveds = okveds;

        dataUl.Okopf = new Okopf()
        {
            Code = json["data"]!["ОКОПФ"]!["Код"]!.ToString(),
            Name = json["data"]!["ОКОПФ"]!["Наим"]!.ToString()

        };

        dataUl.Okfs = new Okfs()
        {
            Code = json["data"]!["ОКФС"]!["Код"]!.ToString(),
            Name = json["data"]!["ОКФС"]!["Наим"]!.ToString()
        };

        dataUl.Okogy = new Okogy()
        {
            Code = json["data"]!["ОКОГУ"]!["Код"]!.ToString(),
            Name = json["data"]!["ОКОГУ"]!["Наим"]!.ToString()
        };

        dataUl.Okato = new Okato()
        {
            Code = json["data"]!["ОКАТО"]!["Код"]!.ToString(),
            Name = json["data"]!["ОКАТО"]!["Наим"]!.ToString()
        };

        dataUl.Oktmo = new Oktmo()
        {
            Code = json["data"]!["ОКТМО"]!["Код"]!.ToString(),
            Name = json["data"]!["ОКТМО"]!["Наим"]!.ToString()
        };

        dataUl.RegFns = new RegFns()
        {
            CodeFns = json["data"]!["РегФНС"]!["КодОрг"]!.ToString(),
            NameFns = json["data"]!["РегФНС"]!["НаимОрг"]!.ToString(),
            AddressFns = json["data"]!["РегФНС"]!["АдресОрг"]!.ToString(),
        };

        dataUl.RegPfr = new RegPfr()
        {
            CodePfr = json["data"]!["РегПФР"]!["КодОрг"]!.ToString(),
            NamePfr = json["data"]!["РегПФР"]!["НаимОрг"]!.ToString(),
            RegNumber = json["data"]!["РегПФР"]!["РегНомер"]!.ToString(),
            DateReg = json["data"]!["РегПФР"]!["ДатаРег"]!.GetValue<DateTime>(),
        };

        dataUl.RegFss = new RegFss()
        {
            CodeFss = json["data"]!["РегФСС"]!["КодОрг"]!.ToString(),
            NameFss = json["data"]!["РегФСС"]!["НаимОрг"]!.ToString(),
            RegNumber = json["data"]!["РегФСС"]!["РегНомер"]!.ToString(),
            DateReg = json["data"]!["РегФСС"]!["ДатаРег"]!.GetValue<DateTime>(),
        };

        if (json["data"]!["УстКап"]!.ToString() != "{}")
        {
            dataUl.AuthorizedCapital = new AuthorizedCapital()
            {
                Type = json["data"]!["УстКап"]!["Тип"]!.ToString(),
                Amount = json["data"]!["УстКап"]!["Сумма"]!.GetValue<long>()
            };
        }

        if (json["data"]!["УпрОрг"]!["НаимПолн"] != null)
        {
            dataUl.ManagingOrganization = new ManagingOrganization()
            {
                OgrDostup = json["data"]!["УпрОрг"]!["ОгрДоступ"] != null ? json["data"]!["УпрОрг"]!["ОгрДоступ"]!.GetValue<bool>() : false,
                Ogrn = json["data"]!["УпрОрг"]!["ОГРН"] != null ? json["data"]!["УпрОрг"]!["ОГРН"]!.ToString() : null,
                Inn = json["data"]!["УпрОрг"]!["ИНН"] != null ? json["data"]!["УпрОрг"]!["ИНН"]!.ToString() : null,
                FullName = json["data"]!["УпрОрг"]!["НаимПолн"]!.ToString(),
                Unreliability = json["data"]!["УпрОрг"]!["Недост"]!.GetValue<bool>(),
                Incountry = json["data"]!["УпрОрг"]!["ИнСтрана"] != null ? json["data"]!["УпрОрг"]!["ИнСтрана"]!.ToString() : null,
                InAddress = json["data"]!["УпрОрг"]!["ИнАдрес"] != null ? json["data"]!["УпрОрг"]!["ИнАдрес"]!.ToString() : null,
                InRegNumber = json["data"]!["УпрОрг"]!["ИнРегНомер"] != null ? json["data"]!["УпрОрг"]!["ИнРегНомер"]!.ToString() : null,
                IndateReg = json["data"]!["УпрОрг"]!["ИнДатаРег"] != null ? json["data"]!["УпрОрг"]!["ИнДатаРег"]!.ToString() : null,
            };
        }

        dataUl.Director = new ObservableCollection<Director>();
        foreach (var js in json["data"]!["Руковод"]!.AsArray())
        {
            var director = new Director()
            {
                OgrDostup = js!["ОгрДоступ"] != null ? js["ОгрДоступ"]!.GetValue<bool>() : false,
                Fio = js["ФИО"]!.ToString(),
                Inn = js["ИНН"]!.ToString(),
                TypePosition = js["ВидДолжн"]!.ToString(),
                NamePosition = js["НаимДолжн"]!.ToString(),
                Unreliability = js["Недост"]!.GetValue<bool>(),
                Description = js["НедостОпис"] != null ? js["НедостОпис"]!.ToString() : null,
                MassManager = js["МассРуковод"]!.GetValue<bool>(),
                DisqualifiedPerson = js["ДисквЛицо"]!.GetValue<bool>(),
                DisqualifiedOn = js["ДисквДатаНач"] != null ? js["ДисквДатаНач"]!.GetValue<DateTime>() : null,
                DisqualifiedOff = js["ДисквДатаОконч"] != null ? js["ДисквДатаОконч"]!.GetValue<DateTime>() : null,

            };
            foreach (var ogrn in js["СвязРуковод"]!.AsArray())
            {
                director.RelatedGuide!.Add(new Ogrn() { NumberOgrn = ogrn!.ToString() });
            }
            foreach (var ogrn in js["СвязУчред"]!.AsArray())
            {
                director.RelatedFoundation!.Add(new Ogrn() { NumberOgrn = ogrn!.ToString() });
            }
            dataUl.Director.Add(director);
        }

        var founders = new Founder();
        if (json["data"]!["Учред"]!["ФЛ"]!.AsArray().Count > 0)
        {
            founders.FoundersFl = new();
            foreach (var fl in json["data"]!["Учред"]!["ФЛ"]!.AsArray())
            {
                var founder = new FounderFl()
                {
                    OgrDostup = fl!["ОгрДоступ"] != null ? fl["ОгрДоступ"]!.GetValue<bool>() : false,
                    Fio = fl["ФИО"]!.ToString(),
                    Inn = fl["ИНН"]!.ToString(),
                    Unreliability = fl["Недост"] != null ? fl["Недост"]!.GetValue<bool>() : false,
                    Description = fl["НедостОпис"] != null ? fl["НедостОпис"]!.ToString() : null,
                    MassFounder = fl["МассУчред"] != null ? fl["МассУчред"]!.GetValue<bool>() : false,
                    Share = new Share() { Nominal = fl["Доля"]!["Номинал"]!.GetValue<float>(), Percent = fl["Доля"]!["Процент"]!.GetValue<float>() }
                };
                if (fl["СвязРуковод"]!.AsArray().Count > 0)
                {
                    founder.RelatedGuide = new();
                    foreach (var ogrn in fl["СвязРуковод"]!.AsArray())
                    {
                        founder.RelatedGuide!.Add(new Ogrn() { NumberOgrn = ogrn!.ToString() });
                    }
                }

                if (fl["СвязУчред"]!.AsArray().Count > 0)
                {
                    founder.RelatedFoundation = new();
                    foreach (var ogrn in fl["СвязУчред"]!.AsArray())
                    {
                        founder.RelatedFoundation!.Add(new Ogrn() { NumberOgrn = ogrn!.ToString() });
                    }

                }
                founders.FoundersFl.Add(founder);
            }

        }

        if (json["data"]!["Учред"]!["РосОрг"]!.AsArray().Count > 0)
        {
            founders.FoundersUl = new();
            foreach (var ul in json["data"]!["Учред"]!["РосОрг"]!.AsArray())
            {
                founders.FoundersUl.Add(new FounderUl()
                {
                    OgrDostup = ul!["ОгрДоступ"] != null ? ul["ОгрДоступ"]!.GetValue<bool>() : false,
                    Ogrn = ul["ОГРН"]!.ToString(),
                    Inn = ul["ИНН"]!.ToString(),
                    FullName = ul["НаимПолн"]!.ToString(),
                    Unreliability = ul["Недост"]!.GetValue<bool>(),
                    Description = ul["НедостОпис"] != null ? ul["НедостОпис"]!.ToString() : null,
                    Share = new Share()
                    {
                        Nominal = ul["Доля"]!["Номинал"]!.GetValue<float>(),
                        Percent = ul["Доля"]!["Процент"]!.GetValue<float>()
                    }
                });
            }
        }

        if (json["data"]!["Учред"]!["ИнОрг"]!.AsArray().Count > 0)
        {
            founders.FoundersIn = new();
            foreach (var inOrg in json["data"]!["Учред"]!["ИнОрг"]!.AsArray())
            {
                founders.FoundersIn.Add(new FounderIn()
                {
                    OgrDostup = inOrg!["ОгрДоступ"] != null ? inOrg["ОгрДоступ"]!.GetValue<bool>() : false,
                    FullName = inOrg["НаимПолн"]!.ToString(),
                    Country = inOrg["Страна"]!.ToString(),
                    Address = inOrg["Адрес"]!.ToString(),
                    RegNumber = inOrg["РегНомер"]!.ToString(),
                    DateReg = inOrg["ДатаРег"]!.GetValue<DateTime>(),
                    Unreliability = inOrg["Недост"]!.GetValue<bool>(),
                    Description = inOrg["НедостОпис"] != null ? inOrg["НедостОпис"]!.ToString() : null,
                    Share = new Share()
                    {
                        Nominal = inOrg["Доля"]!["Номинал"]!.GetValue<float>(),
                        Percent = inOrg["Доля"]!["Процент"]!.GetValue<float>()
                    }
                });
            }
        }

        if (json["data"]!["Учред"]!["ПИФ"]!.AsArray().Count > 0)
        {
            founders.FoundersPif = new();
            foreach (var pif in json["data"]!["Учред"]!["ПИФ"]!.AsArray())
            {
                founders.FoundersPif.Add(new FounderPif()
                {
                    OgrDostup = pif!["ОгрДоступ"] != null ? pif["ОгрДоступ"]!.GetValue<bool>() : false,
                    FullName = pif["Наим"]!.ToString(),
                    Unreliability = pif["Недост"]!.GetValue<bool>(),
                    Description = pif["НедостОпис"] != null ? pif["НедостОпис"]!.ToString() : null,
                    ManagingOrganization = pif["УпрКом"] != null ? new ManagingOrganization()
                    {
                        Ogrn = pif["УпрКом"]!["ОГРН"]!.ToString(),
                        Inn = pif["УпрКом"]!["ИНН"]!.ToString(),
                        FullName = pif["УпрКом"]!["НаимПолн"]!.ToString()
                    } : null,
                    Share = new Share()
                    {
                        Nominal = pif["Доля"]!["Номинал"]!.GetValue<float>(),
                        Percent = pif["Доля"]!["Процент"]!.GetValue<float>()
                    }
                });
            }
        }

        if (json["data"]!["Учред"]!["РФ"]!.AsArray().Count > 0)
        {
            founders.FoundersMoRf = new();
            foreach (var moRf in json["data"]!["Учред"]!["РФ"]!.AsArray())
            {
                FounderMoRf foundersMoRf = new()
                {
                    OgrDostup = moRf!["ОгрДоступ"] != null ? moRf["ОгрДоступ"]!.GetValue<bool>() : false,
                    Type = moRf["Тип"]!.ToString(),
                    Region = new Region()
                    {
                        Code = moRf["Регион"]!["Код"]!.ToString(),
                        Name = moRf["Регион"]!["Наим"]!.ToString(),
                    },
                    Unreliability = moRf["Недост"]!.GetValue<bool>(),
                    Description = moRf["НедостОпис"] != null ? moRf["НедостОпис"]!.ToString() : null,
                    Share = new Share()
                    {
                        Nominal = moRf["Доля"]!["Номинал"]!.GetValue<float>(),
                        Percent = moRf["Доля"]!["Процент"]!.GetValue<float>()
                    }
                };

                if (json["data"]!["Учред"]!["ОргОсущПрав"]!.AsArray().Count > 0)
                {
                    foundersMoRf.OrgsMo = new();
                    foreach (var mo in json["data"]!["Учред"]!["ОргОсущПрав"]!.AsArray())
                    {
                        foundersMoRf.OrgsMo.Add(new UlShort()
                        {
                            Ogrn = mo!["ОГРН"]!.ToString(),
                            Inn = mo["ИНН"]!.ToString(),
                            FullName = mo["НаимПолн"]!.ToString(),
                        });
                    }
                }

                if (json["data"]!["Учред"]!["ФЛОсущПрав"]!.AsArray().Count > 0)
                {
                    foundersMoRf.FlsMo = new ObservableCollection<FlMo>();
                    foreach (var flmo in json["data"]!["Учред"]!["ФЛОсущПрав"]!.AsArray())
                    {
                        foundersMoRf.FlsMo.Add(new FlMo()
                        {
                            Fio = flmo!["ФИО"]!.ToString(),
                            Inn = flmo["ИНН"]!.ToString()
                        });
                    }
                }

                founders.FoundersMoRf.Add(foundersMoRf);
            }
        }

        dataUl.Founder = founders;

        if (json["data"]!["СвязУпрОрг"]!.AsArray().Count > 0)
        {
            dataUl.RelatedOrganizationsUpr = new();
            foreach (var org in json["data"]!["СвязУпрОрг"]!.AsArray())
            {
                dataUl.RelatedOrganizationsUpr.Add(new Ul()
                {
                    Ogrn = org!["ОГРН"]!=null! ? org["ОГРН"]!.ToString() : "",
                    Inn = org["ИНН"]!=null! ? org["ИНН"]!.ToString() : "",
                    Kpp = org["КПП"]!=null! ? org["КПП"]!.ToString() : "",
                    ShortName = org["НаимСокр"]!=null! ? org["НаимСокр"]!.ToString() : "",
                    FullName = org["НаимПолн"]!=null! ? org["НаимПолн"]!.ToString() : "",
                    DateReg = org["ДатаРег"]!=null ? org["ДатаРег"]!.ToString() : "",
                    Status = org["Статус"]!=null! ? org["Статус"]!.ToString() : "",
                    DateLikvid = org["ДатаЛикв"]!=null! ? org["ДатаЛикв"]!.ToString() : "",
                    CodeRegion = org["РегионКод"]!=null! ? org["РегионКод"]!.ToString() : "",
                    UrAddress = org["ЮрАдрес"]!=null! ? org["ЮрАдрес"]!.ToString() : "",
                    Okved = org["ОКВЭД"]!=null! ? org["ОКВЭД"]!.ToString() : ""
                });
            }
        }

        if (json["data"]!["СвязУчред"]!.AsArray().Count > 0)
        {
            dataUl.RelatedOrganizationsFounded = new();
            foreach (var org in json["data"]!["СвязУпрОрг"]!.AsArray())
            {
                dataUl.RelatedOrganizationsFounded.Add(new Ul()
                {
                    Ogrn = org!["ОГРН"] != null! ? org["ОГРН"]!.ToString() : "",
                    Inn = org["ИНН"] != null! ? org["ИНН"]!.ToString() : "",
                    Kpp = org["КПП"] != null! ? org["КПП"]!.ToString() : "",
                    ShortName = org["НаимСокр"] != null! ? org["НаимСокр"]!.ToString() : "",
                    FullName = org["НаимПолн"] != null! ? org["НаимПолн"]!.ToString() : "",
                    DateReg = org["ДатаРег"] != null ? org["ДатаРег"]!.ToString() : "",
                    Status = org["Статус"] != null! ? org["Статус"]!.ToString() : "",
                    DateLikvid = org["ДатаЛикв"] != null! ? org["ДатаЛикв"]!.ToString() : "",
                    CodeRegion = org["РегионКод"] != null! ? org["РегионКод"]!.ToString() : "",
                    UrAddress = org["ЮрАдрес"] != null! ? org["ЮрАдрес"]!.ToString() : "",
                    Okved = org["ОКВЭД"] != null! ? org["ОКВЭД"]!.ToString() : ""
                });
            }
        }

        if (json["data"]!["ДержРеестрАО"] != null)
        {
            dataUl.HolderRegister = json["data"]!["ДержРеестрАО"] != null ? new HolderRegister()
            {
            OgrDostup = json["data"]!["ДержРеестрАО"]!["ОгрДоступ"] !=null ? json["data"]!["ДержРеестрАО"]!["ОгрДоступ"]!.GetValue<bool>() : false,
            Ogrn = json["data"]!["ДержРеестрАО"]!["ОГРН"] !=null ? json["data"]!["ДержРеестрАО"]!["ОГРН"]!.ToString() : "",
            Inn = json["data"]!["ДержРеестрАО"]!["ИНН"] !=null ? json["data"]!["ДержРеестрАО"]!["ИНН"]!.ToString() : "",
            FullName = json["data"]!["ДержРеестрАО"]!["НаимПолн"] !=null ? json["data"]!["ДержРеестрАО"]!["НаимПолн"]!.ToString() : ""
            } : null;
        }


       

        if (json["data"]!["Лиценз"] != null)
        {
            dataUl.Licenses = new ObservableCollection<License>();
            foreach (var licenses in json["data"]!["Лиценз"]!.AsArray())
            {
                var lic = new License()
                {
                    Number = licenses!["Номер"]!.ToString(),
                    Date = licenses["Дата"]!.GetValue<DateTime>(),
                    LicOrg = licenses["ЛицОрг"]!.ToString(),
                };
                lic.LicView = new();
                foreach (var viewlic in licenses["ВидДеят"]!.AsArray())
                {
                    lic.LicView.Add(new LicView(){ ViewLic = viewlic!.ToString()});
                }

                dataUl.Licenses.Add(lic);

            }
        }


        if (json["data"]!["Подразд"] != null)
        {
            dataUl.Divisions = new Divisions();
            if (json["data"]!["Подразд"]!["Филиал"] != null)
            {
                dataUl.Divisions.Branches = new ObservableCollection<Branch>();
                foreach (var fil in json["data"]!["Подразд"]!["Филиал"]!.AsArray())
                {
                    Branch br = new Branch()
                    {
                        OgrDostup = fil!["ОгрДоступ"] != null ? fil["ОгрДоступ"]!.GetValue<bool>() : false,
                        FullName = fil["НаимПолн"] != null! ? fil["НаимПолн"]!.ToString() : null,
                        Kpp = fil["КПП"] != null ? fil["КПП"]!.ToString() : null,
                        LegalAddress = fil["Адрес"] != null ? fil["Адрес"]!.ToString() : null,
                        Country = fil["Страна"] != null ? fil["Страна"]!.ToString() : null,
                        InAddress = fil["ИнАдрес"] != null ? fil["ИнАдрес"]!.ToString() : null
                    };
                    dataUl.Divisions.Branches!.Add(br);
                }
            }

            if (json["data"]!["Подразд"]!["Представ"] != null)
            {
                dataUl.Divisions.RepresentativeOffices = new ObservableCollection<Branch>();
                foreach (var fil in json["data"]!["Подразд"]!["Представ"]!.AsArray())
                {
                    Branch br = new Branch()
                    {
                        OgrDostup = fil!["ОгрДоступ"] != null ? fil["ОгрДоступ"]!.GetValue<bool>() : false,
                        FullName = fil["НаимПолн"]!=null! ? fil["НаимПолн"]!.ToString() : null,
                        Kpp = fil["КПП"] != null ? fil["КПП"]!.ToString() : null,
                        LegalAddress = fil["Адрес"] != null ? fil["Адрес"]!.ToString() : null,
                        Country = fil["Страна"] != null ? fil["Страна"]!.ToString() : null,
                        InAddress = fil["ИнАдрес"] != null ? fil["ИнАдрес"]!.ToString() : null
                    };
                    dataUl.Divisions.RepresentativeOffices!.Add(br);
                }
            }
        }

        if (json["data"]!["Правопредш"] != null)
        {
            dataUl.Assignees = new ObservableCollection<UlShort>();
            foreach (var ass in json["data"]!["Правопредш"]!.AsArray())
            {
                dataUl.Assignees.Add(new UlShort()
                {
                    Ogrn = ass!["ОГРН"]!.ToString(),
                    Inn = ass["ИНН"]!.ToString(),
                    FullName = ass["НаимПолн"]!.ToString()

                });
            }
        }

        if (json["data"]!["Правопреем"] != null)
        {
            dataUl.LegalSuccessors = new ObservableCollection<UlShort>();
            foreach (var ass in json["data"]!["Правопредш"]!.AsArray())
            {
                dataUl.LegalSuccessors.Add(new UlShort()
                {
                    Ogrn = ass!["ОГРН"]!.ToString(),
                    Inn = ass["ИНН"]!.ToString(),
                    FullName = ass["НаимПолн"]!.ToString()

                });
            }
        }

        dataUl.DateDischarge = json["data"]!["ДатаВып"]!.GetValue<DateTime>();

        if (json["data"]!["Контакты"]!= null)
        {
            dataUl.Contacts = new Contacts();
            if (json["data"]!["Контакты"]!["Тел"] != null)
            {
                dataUl.Contacts.Phones = new ObservableCollection<Phone>();
                foreach (var phone in json["data"]!["Контакты"]!["Тел"]!.AsArray())
                {
                    dataUl.Contacts.Phones.Add(new Phone(){Number = phone!.ToString()});
                }
            }

            if (json["data"]!["Контакты"]!["Емэйл"] != null)
            {
                dataUl.Contacts.Emails = new ObservableCollection<Email>();
                foreach (var em in json["data"]!["Контакты"]!["Емэйл"]!.AsArray())
                {
                    dataUl.Contacts.Emails.Add(new Email(){Mail = em!.ToString()});
                }
            }

            dataUl.Contacts.Web = json["data"]!["Контакты"]!["ВебСайт"] != null
                ? json["data"]!["Контакты"]!["ВебСайт"]!.ToString()
                : null;
        }

        if (json["data"]!["Налоги"] != null!)
        {
            dataUl.Tax = new Tax();
            if (json["data"]!["Налоги"]!["ОсобРежим"]!=null!)
            {
                dataUl.Tax.Mode = new ObservableCollection<ModeNalog>();
                foreach (var mode in json["data"]!["Налоги"]!["ОсобРежим"]!.AsArray())
                {
                    dataUl.Tax.Mode.Add(new ModeNalog(){Mode = mode!.ToString()});
                }
            }

            if (json["data"]!["Налоги"]!["СведУпл"] != null!)
            {
                dataUl.Tax.PaymentTaxes = new ObservableCollection<PaymentTax>();
                foreach (var tax in json["data"]!["Налоги"]!["СведУпл"]!.AsArray())
                {
                    dataUl.Tax.PaymentTaxes.Add(new PaymentTax(){Name = tax!["Наим"]!.ToString() , Amount = tax["Сумма"]!.GetValue<float>() });
                }
            }

            dataUl.Tax.PayAmount = json["data"]!["Налоги"]!["СумУпл"] != null
                ? float.Parse(json["data"]!["Налоги"]!["СумУпл"]!.ToString().Replace(".", ","))
                : 0;

            dataUl.Tax.ArrearsAmount = json["data"]!["Налоги"]!["СумНедоим"] != null
                ? float.Parse(json["data"]!["Налоги"]!["СумНедоим"]!.ToString().Replace(".", ","))
                : 0;
        }

        if (json["data"]!["РМСП"] != null!)
        {
            dataUl.Rmsp = new Rmsp()
            {
                Cat = json["data"]!["РМСП"]!["Кат"] !=null ? json["data"]!["РМСП"]!["Кат"]!.ToString() : null!,
                Date = json["data"]!["РМСП"]!["ДатаВкл"] != null ? json["data"]!["РМСП"]!["ДатаВкл"]!.GetValue<DateTime>() : null!,
            };
        }
            dataUl.Ogrn = json["data"]!["ОГРН"]!.ToString();

            dataUl.Srh = json["data"]!["СЧР"] != null
                ? json["data"]!["СЧР"]!.GetValue<int>()
                : 0;

            dataUl.Unscrupulous = json["data"]!["НедобПост"] != null
                ? json["data"]!["НедобПост"]!.GetValue<bool>()
                : false;

            if (json["data"]!["НедобПостЗап"] != null!)
            {
                dataUl.UnscrupulousSupplierRecord = new();

                foreach (var unsc in json["data"]!["НедобПостЗап"]!.AsArray())
                {
                dataUl.UnscrupulousSupplierRecord.Add(new UnscrupulousSupplierRecord()
                {
                    RegistrationNumber = unsc!["РеестрНомер"]!=null! ? unsc["РеестрНомер"]!.ToString(): null,
                    DatePublication = unsc["ДатаПуб"] != null! ? unsc["ДатаПуб"]!.GetValue<DateTime>() : null,
                    DateApproval = unsc["ДатаУтв"] != null! ? unsc["ДатаУтв"]!.GetValue<DateTime>() : null,
                    ShortName = unsc["ЗаказНаимСокр"] != null! ? unsc["ЗаказНаимСокр"]!.ToString() : null,
                    FullName = unsc["ЗаказНаимПолн"] != null! ? unsc["ЗаказНаимПолн"]!.ToString() : null,
                    Inn = unsc["ЗаказИНН"] != null! ? unsc["ЗаказИНН"]!.ToString() : null,
                    Kpp = unsc["ЗаказКПП"] != null! ? unsc["ЗаказКПП"]!.ToString() : null,
                    PurchaseNumber = unsc["ЗакупНомер"] != null! ? unsc["ЗакупНомер"]!.ToString() : null,
                    PurchaseDescription = unsc["ЗакупОпис"] != null! ? unsc["ЗакупОпис"]!.ToString() : null,
                    ContractPrice = unsc["ЦенаКонтр"] != null! ? unsc["ЦенаКонтр"]!.GetValue<int>() : 0
                });
                }
            }

            dataUl.DisqualifiedPersons = json["data"]!["ДисквЛица"] != null! ? json["data"]!["ДисквЛица"]!.GetValue<bool>() : false;
            dataUl.MassManagers = json["data"]!["МассРуковод"] != null! ? json["data"]!["МассРуковод"]!.GetValue<bool>() : false;
            dataUl.MassFounders = json["data"]!["МассУчред"] != null! ? json["data"]!["МассУчред"]!.GetValue<bool>() : false;

            var description = new StringBuilder();
            string status = "Проверка пройдена. Замечаний нет!";

            if (dataUl.Status.Code != "001")
            {
                status = "Есть значительные замечания";
                description.Append($"Организация имеет статус: {dataUl.Status.Name}");
            }

            if (dataUl.Status.Code == "000")
            {
                status = $"Организация {dataUl.Status.Name} с {dataUl.Likved!.Date}";
                description.Append($"{dataUl.Likved!.Name}");
            }

            if (dataUl.Unscrupulous)
            {
                status = "Есть значительные замечания";
                description.Append("Организация включена в реестр недобросовестных поставщиков");
            }

            if (dataUl.DisqualifiedPersons)
            {
                status = "Есть значительные замечания";
                description.Append("В руководстве организации присутствуют дисквалифицированные лица");
            }

            if (dataUl.MassManagers)
            {
                status = "Есть значительные замечания";
                description.Append("В организации присутствуют массовые руководители");
            }

            if (dataUl.MassFounders)
            {
                status = "Есть значительные замечания";
                description.Append("В организации присутствуют массовые учредители");
            }

            if (dataUl.Tax!.ArrearsAmount > 5000)
            {
                status = "Есть значительные замечания";
                description.Append($"Организация имеет недоимку по налогам в сумме {dataUl.Tax!.ArrearsAmount} руб.");
        }

            //dataUl.FinancialStatements = await GetFinancialStatementAsync(inn);

        checkCounterparty.DataUl = dataUl;
            checkCounterparty.ResultStatus = status;
            checkCounterparty.Description= description.ToString();

        return checkCounterparty;
    }

    private static async Task<FinancialStatement?> GetFinancialStatementAsync(string inn)
    {
        var client = new HttpClient();
        var uri = new Uri($"https://api.checko.ru/v2/finances?key={ApiKey}&inn={inn}&extended=true");
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        JsonNode? json = JsonNode.Parse(result);
        var ss = json!["meta"]!["message"]!;
        if (ss != null!) throw new InvalidOperationException(json["meta"]!["message"]!.ToString());

        var fs = new FinancialStatement();
        fs.Ul = new()
        {
            Ogrn = json["company"]!["ОГРН"]!=null! ? json["company"]!["ОГРН"]!.ToString() : "",
            Inn = json["company"]!["ИНН"]!=null! ? json["company"]!["ИНН"]!.ToString() : "",
            Kpp = json["company"]!["КПП"]!=null! ? json["company"]!["КПП"]!.ToString() : "",
            ShortName = json["company"]!["НаимСокр"]!=null! ? json["company"]!["НаимСокр"]!.ToString() : "",
            FullName = json["company"]!["НаимПолн"]!=null! ? json["company"]!["НаимПолн"]!.ToString() : "",
            DateReg = json["company"]!["ДатаРег"]!=null! ? json["company"]!["ДатаРег"]!.ToString() : "",
            Status = json["company"]!["Статус"]!=null! ? json["company"]!["Статус"]!.ToString() : "",
            DateLikvid = json["company"]!["ДатаЛикв"]!=null! ? json["company"]!["ДатаЛикв"]!.ToString() : "",
            CodeRegion = json["company"]!["РегионКод"]!=null! ? json["company"]!["РегионКод"]!.ToString() : "",
            UrAddress = json["company"]!["ЮрАдрес"]!=null! ? json["company"]!["ЮрАдрес"]!.ToString() : "",
            Okved = json["company"]!["ОКВЭД"]!=null! ? json["company"]!["ОКВЭД"]!.ToString() : ""
        };
        var year = DateTime.Now.Year - 2;

        for (int i = 2011; i < DateTime.Now.Year; i++)
        {
            var chb = new CheckBalance();
            chb.Year = i;
        }
      
        return fs;
    }
}
