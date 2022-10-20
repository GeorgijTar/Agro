using System.Text.Json;
using System.Text.Json.Nodes;
using Agro.DAL.Entities.Counter;
using Agro.DAL.Entities.Organization;

namespace FNS.Api;
public static class CheckoApi
{
    public static async Task<Counterparty> GetUl(string inn)
    {
     if (inn.Length!=10)
         throw new InvalidOperationException(nameof(inn));

        var counterparty=new Counterparty();
        var client = new HttpClient();
        var uri=new Uri($"https://api.checko.ru/v2/company?key=zpKipA8XmoNldFmM&inn={inn}");
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        JsonNode? json = JsonValue.Parse(result);
        var ss = json?["meta"]!["message"]!;
        if (ss != null)
            throw new InvalidOperationException(json?["meta"]!["message"]!.ToString());
        if (json?["data"]!["Статус"]!["Код"]!.ToString()=="000")
            throw new InvalidOperationException(
                $"Организация имеет статус: {json["data"]!["Статус"]!["Наим"]} ликвидировано" +
                $" {json["data"]!["Ликвид"]!["Дата"]} с формулировкой {json["data"]!["Ликвид"]!["Наим"]}");

        counterparty.Kpp = json["data"]!["КПП"]!.ToString();
        counterparty.Ogrn = json["data"]!["ОГРН"]!.ToString();
        counterparty.PayName = json["data"]!["НаимПолн"]!.ToString();
        counterparty.Inn= json["data"]!["ИНН"]!.ToString();
        if (json["data"]!["НаимСокр"] == null!)
        {
            counterparty.Name = counterparty.PayName;
        }
        else
        {
            counterparty.Name = json["data"]!["НаимСокр"]!.ToString();
        }
        counterparty.Okpo = json["data"]!["ОКПО"]!.ToString();

        counterparty.ActualAddress!.City = json["data"]!["ЮрАдрес"]!["НасПункт"]!.ToString();
        counterparty.ActualAddress.AddressRf = json["data"]!["ЮрАдрес"]!["АдресРФ"]!.ToString();
        counterparty.ActualAddress.GarId = json["data"]!["ЮрАдрес"]!["ИдГАР"] != null ? json["data"]!["ЮрАдрес"]!["ИдГАР"]!.ToString() : "";
        counterparty.ActualAddress.Unreliability = bool.Parse(json["data"]!["ЮрАдрес"]!["Недост"]!.ToString()!);
        counterparty.ActualAddress.UnreliabilityDescription = json["data"]!["ЮрАдрес"]!["НедостОпис"]!= null ? json["data"]!["ЮрАдрес"]!["НедостОпис"]!.ToString() : "";


        return counterparty;
    }


    public static async Task<Counterparty> GetIp(string inn)
    {
        if(inn.Length != 12)
        throw new InvalidOperationException(nameof(inn));
        Counterparty counterparty = new Counterparty();
        HttpClient client = new HttpClient();
        Uri? uri= new Uri($"https://api.checko.ru/v2/entrepreneur?key=zpKipA8XmoNldFmM&inn={inn}");
      
        var response = await client.GetAsync(uri);
        string? result = await response.Content.ReadAsStringAsync();
        JsonNode? json = JsonValue.Parse(result);
        var ss = json["meta"]["message"];
        if (ss != null)
            throw new InvalidOperationException(json["meta"]["message"].ToString());
        counterparty.Kpp = "";
        counterparty.Ogrn = json["data"]["ОГРНИП"].ToString();
        counterparty.Name = json["data"]["ФИО"].ToString();
        counterparty.PayName = json["data"]["ФИО"].ToString();
        counterparty.Okpo = json["data"]["ОКПО"].ToString();
        counterparty.Inn= json["data"]["ИНН"].ToString();

        return counterparty;
    }


    public static async Task<Organization> GetOrgUl(string inn)
    {
        if (inn.Length != 10)
            throw new InvalidOperationException(nameof(inn));

        var organization = new Organization();
        var client = new HttpClient();
        var uri = new Uri($"https://api.checko.ru/v2/company?key=zpKipA8XmoNldFmM&inn={inn}");
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        JsonNode? json = JsonNode.Parse(result);
        var ss = json?["meta"]!["message"]!;
        if (ss != null)
            throw new InvalidOperationException(json?["meta"]!["message"]!.ToString());
        if (json?["data"]!["Статус"]!["Код"]!.ToString() == "000")
            throw new InvalidOperationException(
                $"Организация имеет статус: {json["data"]!["Статус"]!["Наим"]!} ликвидировано" +
                $" {json["data"]!["Ликвид"]!["Дата"]!} с формулировкой {json["data"]!["Ликвид"]!["Наим"]!}");

        organization.Kpp = json?["data"]!["КПП"]!.ToString()!;
        organization.Ogrn = json?["data"]!["ОГРН"]!.ToString()!;
        organization.Name = json?["data"]!["НаимПолн"]!.ToString()!;
        organization.Inn = json?["data"]!["ИНН"]!.ToString()!;
        if (json?["data"]!["НаимСокр"]! == null!)
        {
            organization.AbbreviatedName = organization.Name;
        }
        else
        {
            organization.AbbreviatedName = json["data"]!["НаимСокр"]!.ToString();
        }
        organization.Okpo = json?["data"]!["ОКПО"]!.ToString()!;
        organization.Okved.Code= json?["data"]!["ОКВЭД"]!["Код"]!.ToString()!;
        organization.Okved.Name = json?["data"]!["ОКВЭД"]!["Наим"]!.ToString()!;
        organization.AddressUr!.City= json?["data"]!["ЮрАдрес"]!["НасПункт"]!.ToString()!;
        organization.AddressUr.AddressRf = json?["data"]!["ЮрАдрес"]!["АдресРФ"]!.ToString()!;
        organization.AddressUr.GarId = json?["data"]!["ЮрАдрес"]!["ИдГАР"] != null ? json["data"]!["ЮрАдрес"]!["ИдГАР"]!.ToString(): "" ;
        organization.AddressUr.Unreliability = bool.Parse(json?["data"]!["ЮрАдрес"]!["Недост"]!.ToString()!);
        organization.AddressUr.UnreliabilityDescription = json?["data"]!["ЮрАдрес"]!["НедостОпис"] !=null ? json["data"]!["ЮрАдрес"]!["НедостОпис"]!.ToString():"";
        organization.Okopf!.Code = json?["data"]!["ОКОПФ"]!["Код"]!.ToString()!;
        organization.Okopf.Name = json?["data"]!["ОКОПФ"]!["Наим"]!.ToString()!;
        organization.Okfs!.Code = json?["data"]!["ОКФС"]!["Код"]!.ToString()!;
        organization.Okfs!.Name = json?["data"]!["ОКФС"]!["Наим"]!.ToString()!;
        organization.Okogy!.Code = json?["data"]!["ОКОГУ"]!["Код"]!.ToString()!;
        organization.Okogy!.Name = json?["data"]!["ОКОГУ"]!["Наим"]!.ToString()!;
        organization.Okato!.Code = json?["data"]!["ОКАТО"]!["Код"]!.ToString()!;
        organization.Okato!.Name = json?["data"]!["ОКАТО"]!["Наим"]!.ToString()!;
        organization.Oktmo!.Code = json?["data"]!["ОКТМО"]!["Код"]!.ToString()!;
        organization.Oktmo!.Name = json?["data"]!["ОКТМО"]!["Наим"]!.ToString()!;
        organization.RegFns!.CodeFns= json?["data"]!["РегФНС"]!["КодОрг"]!.ToString()!;
        organization.RegFns!.AddressFns = json?["data"]!["РегФНС"]!["АдресОрг"]!.ToString()!;
        organization.RegFns!.NameFns = json?["data"]!["РегФНС"]!["НаимОрг"]!.ToString()!;
        organization.RegPfr!.CodePfr= json?["data"]!["РегПФР"]!["КодОрг"]!.ToString()!;
        organization.RegPfr!.DateReg = DateTime.Parse(json?["data"]!["РегПФР"]!["ДатаРег"]!.ToString()!);
        organization.RegPfr!.NamePfr = json?["data"]!["РегПФР"]!["НаимОрг"]!.ToString()!;
        organization.RegPfr!.RegNumber = json?["data"]!["РегПФР"]!["РегНомер"]!.ToString()!;
        organization.RegFss!.CodeFss= json?["data"]!["РегФСС"]!["КодОрг"]!.ToString()!;
        organization.RegFss!.RegNumber = json?["data"]!["РегФСС"]!["РегНомер"]!.ToString()!;
        organization.RegFss!.NameFss = json?["data"]!["РегФСС"]!["НаимОрг"]!.ToString()!;
        organization.RegFss!.DateReg = DateTime.Parse(json?["data"]!["РегФСС"]!["ДатаРег"]!.ToString()!);

        return organization;
    }
}