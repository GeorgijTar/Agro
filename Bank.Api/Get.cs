﻿
using System.Text.Json.Nodes;
using Agro.DAL.Entities;

namespace Bank.Api;
public static class Get
{
    public static async Task<BankDetails> GetBankByBik(string bik)
    {
        if (bik.Length != 9)
            throw new InvalidOperationException($"Неверный формат БИК {bik}");
        var bank = new BankDetails();

        var client = new HttpClient();
        var uri = new Uri($"https://bik-info.ru/api.html?type=json&bik={bik}");
        var response = await client.GetAsync(uri);
        var result = await response.Content.ReadAsStringAsync();
        JsonNode? json = JsonNode.Parse(result);
        if (json?["error"] != null)
            throw new InvalidOperationException($"Банк по БИК {bik} не найден");
        bank.Bik = json?["bik"]!.ToString()!;
        bank.NameBank= json?["name"]!.ToString().Replace("&quot;", "\"")!;
        bank.Ks= json?["ks"]!.ToString()!;
        bank.City = $"г. {json?["city"]!.ToString()}";
        return bank;
    }
}