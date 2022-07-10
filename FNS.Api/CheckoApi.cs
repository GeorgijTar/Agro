using System.Text.Json;
using System.Text.Json.Nodes;
using Agro.DAL.Entities;

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
        var ss = json["meta"]["message"];
        if (ss != null)
            throw new InvalidOperationException(json["meta"]["message"].ToString());
        if (json["data"]["Статус"]["Код"].ToString()=="000")
            throw new InvalidOperationException(
                $"Организация имеет статус: {json["data"]["Статус"]["Наим"]} ликвидировано" +
                $" {json["data"]["Ликвид"]["Дата"]} с формулировкой {json["data"]["Ликвид"]["Наим"]}");

        counterparty.Kpp = json["data"]["КПП"].ToString();
        counterparty.Ogrn = json["data"]["ОГРН"].ToString();
        counterparty.PayName = json["data"]["НаимПолн"].ToString();
        counterparty.Inn= json["data"]["ИНН"].ToString();
        if (json["data"]["НаимСокр"] == null)
        {
            counterparty.Name = counterparty.PayName;
        }
        else
        {
            counterparty.Name = json["data"]["НаимСокр"].ToString();
        }
        counterparty.Okpo = json["data"]["ОКПО"].ToString();

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


}