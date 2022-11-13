using System.Diagnostics;
using Agro.DAL.Entities.InvoiceEntity;
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace ReportExcelLib;

public static class InvoiceReportExcel
{
    public static void Print(string patch, Invoice invoice)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var package = new ExcelPackage())
        {
            var sheet = package.Workbook.Worksheets.Add("My Sheet");
            sheet.Cells["A1"].Value = "Hello World!";
            sheet.Columns[1].Width = 0.7;
            for (int i = 2; i < 38; i++)
            {
                sheet.Columns[i].Width = 2.7;
            }

            sheet.Rows[1].Height = 35;
            sheet.Cells[1, 2, 1, 33].Merge = true;
            sheet.Cells[1, 2, 1, 33].Style.WrapText = true;
            sheet.Cells[1, 2, 1, 33].Style.Font.Size = 8;
            sheet.Cells[1, 2].Value = "Внимание! Оплата данного счета означает согласие с условиями поставки товара. Уведомление об оплате " +
            "обязательно, в противном случае не гарантируется наличие товара на складе.Товар отпускается по факту" +
            "прихода денег на р/с Поставщика, самовывозом";
            sheet.Cells[3, 2, 4, 18].Merge = true;
            sheet.Cells[5, 2, 5, 18].Merge = true;
            sheet.Cells[5, 2, 5, 18].Style.Font.Size = 8;
            sheet.Cells[5, 2].Value = "Банк получателя";
            sheet.Cells[3, 2, 4, 18].Style.WrapText = true;
            sheet.Cells[3, 2, 4, 18].Value = $"{invoice.BankDetailsOrg!.NameBank} {invoice.BankDetailsOrg!.City}";
            sheet.Cells[3, 2, 5, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[3, 2, 3, 18].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            sheet.Cells[3, 2, 5, 18].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[5, 2, 5, 18].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[3, 19, 3, 22].Merge = true;
            sheet.Cells[3, 19, 5, 22].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[3, 19, 5, 22].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            sheet.Cells[3, 19, 5, 22].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[3, 19, 5, 22].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[4, 19, 5, 22].Merge = true;
            sheet.Cells[3, 19].Value = "БИК";
            sheet.Cells[4, 19].Value = "Сч. №";
            sheet.Cells[3, 23, 3, 33].Merge = true;
            sheet.Cells[4, 23, 5, 33].Merge = true;
            sheet.Cells[3, 23, 3, 33].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            sheet.Cells[3, 23, 5, 33].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[5, 23, 5, 33].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[3, 23].Value = invoice.BankDetailsOrg.Bik;
            sheet.Cells[4, 23].Value = invoice.BankDetailsOrg.Ks;
            sheet.Cells[6, 2, 6, 3].Merge = true;
            sheet.Cells[6, 4, 6, 10].Merge = true;
            sheet.Cells[6, 11, 6, 12].Merge = true;
            sheet.Cells[6, 13, 6, 18].Merge = true;
            sheet.Cells[6, 2].Value = "ИНН";
            sheet.Cells[6, 11].Value = "КПП";
            sheet.Cells[6, 4].Value = invoice.BankDetailsOrg!.Organization!.Inn;
            sheet.Cells[6, 13].Value = invoice.BankDetailsOrg!.Organization!.Kpp;
            sheet.Cells[6, 2, 6, 10].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[6, 2, 6, 10].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[6, 2, 6, 10].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            sheet.Cells[6, 11, 6, 18].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[6, 11, 6, 18].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[6, 11, 6, 18].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            sheet.Cells[7, 2, 8, 18].Merge = true;
            sheet.Cells[7, 2].Value = invoice.BankDetailsOrg!.Organization!.AbbreviatedName;
            sheet.Cells[9, 2, 9, 18].Merge = true;
            sheet.Cells[9, 2].Value = "Получатель";
            sheet.Cells[9, 2].Style.Font.Size = 8;

            sheet.Cells[7, 19, 8, 22].Merge = true;
            sheet.Cells[7, 19].Value = "Сч. №";

            sheet.Cells[7, 23, 8, 33].Merge = true;
            sheet.Cells[7, 23].Value = invoice.BankDetailsOrg.Bs;

            sheet.Cells[7, 2, 7, 18].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            sheet.Cells[7, 2, 9, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[7, 18, 9, 18].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[9, 2, 9, 18].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            sheet.Cells[6, 19, 9, 19].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[6, 22, 9, 22].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[9, 19, 9, 22].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            sheet.Cells[6, 33, 9, 33].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[9, 23, 9, 33].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            sheet.Cells[11, 2, 11, 33].Merge = true;
            sheet.Cells[11, 2].Value = $"Счет на оплату № {invoice.Number} от {invoice.DateInvoice.ToShortDateString()} г.";
            sheet.Cells[11, 2].Style.Font.Bold = true;
            sheet.Cells[11, 2].Style.Font.Size = 14;

            sheet.Cells[13, 2, 13, 7].Merge = true;
            sheet.Cells[13, 2].Value = "Поставщик:";
            sheet.Cells[13, 8, 15, 33].Merge = true;
            sheet.Cells[13, 8].Value = $"{invoice.BankDetailsOrg.Organization.AbbreviatedName} " +
                                       $"ИНН {invoice.BankDetailsOrg.Organization.Inn} КПП {invoice.BankDetailsOrg.Organization.Kpp}, " +
                                       $"{invoice.BankDetailsOrg.Organization!.AddressUr!.AddressRf}";
            sheet.Cells[13, 8].Style.WrapText = true;
            sheet.Cells[13, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Top;

            sheet.Cells[17, 2, 17, 7].Merge = true;
            sheet.Cells[17, 2].Value = "Покупатель:";
            sheet.Cells[17, 8, 19, 33].Merge = true;
            sheet.Cells[17, 8].Value = $"{invoice.Counterparty.Name} " +
                                       $"ИНН {invoice.Counterparty.Inn} КПП {invoice.Counterparty.Kpp}, " +
                                       $"{invoice.Counterparty.ActualAddress!.AddressRf}";
            sheet.Cells[17, 8, 19, 33].Style.WrapText = true;
            sheet.Cells[17, 8].Style.VerticalAlignment = ExcelVerticalAlignment.Top;


            sheet.Cells[21, 2, 21, 7].Merge = true;
            sheet.Cells[21, 2].Value = "Основание:";

            sheet.Rows[16].Height = 4;
            sheet.Rows[20].Height = 4;

            sheet.Cells[21, 8, 21, 33].Merge = true;
            string osn="";
            if (invoice.Contract != null!)
            {
                osn = $"{invoice.Contract!.Type.Name} № {invoice.Contract.Number} от {invoice.Contract.Date.ToShortDateString()}";
                if (invoice.Specification != null!)
                {
                    osn += $" ({invoice.Specification.Type.Name} № {invoice.Specification.Number} от {invoice.Specification.Date.ToShortDateString()})";
                }
            }
            sheet.Cells[21, 8].Value = osn;
            // Табличная часть
            sheet.Cells[23, 2, 23, 3].Merge = true;
            sheet.Cells[23, 2].Value = "№";
            sheet.Cells[23, 4, 23, 16].Merge = true;
            sheet.Cells[23, 4].Value = "Товары (работы, услуги)";
            sheet.Cells[23, 17, 23, 20].Merge = true;
            sheet.Cells[23, 17].Value = "Кол-во";
            sheet.Cells[23, 21, 23, 22].Merge = true;
            sheet.Cells[23, 21].Value = "Ед.";
            sheet.Cells[23, 23, 23, 26].Merge = true;
            sheet.Cells[23, 23].Value = "Цена";
            sheet.Cells[23, 27, 23, 33].Merge = true;
            sheet.Cells[23, 27].Value = "Сумма";

            sheet.Cells[23, 2, 23, 33].Style.Font.Size = 10;
            sheet.Cells[23, 2, 23, 33].Style.Font.Bold = true;
            sheet.Cells[23, 2, 23, 33].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            sheet.Cells[23, 2, 23, 33].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            sheet.Cells[23, 2, 23, 33].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells[23, 2, 23, 33].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells[23, 2, 23, 33].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            

            var row = 24;
            var count = 1;

            foreach (var product in invoice.ProductsInvoice!)
            {
                sheet.Cells[row, 2, row, 3].Merge = true;
                sheet.Cells[row, 2].Value = count;
                sheet.Cells[row, 4, row, 16].Merge = true;
                sheet.Cells[row, 4].Value = product.Product.Name;
                sheet.Cells[row, 17, row, 20].Merge = true;
                sheet.Cells[row, 17].Value = product.Quantity;
                sheet.Cells[row, 17].Style.Numberformat.Format = "#,###0.000";
                sheet.Cells[row, 21, row, 22].Merge = true;
                sheet.Cells[row, 21].Value = product.Product.Unit.Abbreviation;
                sheet.Cells[row, 23, row, 26].Merge = true;
                sheet.Cells[row, 23].Value = product.UnitPrice;
                sheet.Cells[row, 23].Style.Numberformat.Format = "#,##0.00";
                sheet.Cells[row, 27, row, 33].Merge = true;
                sheet.Cells[row, 27].Value = product.Amount;
                sheet.Cells[row, 27].Style.Numberformat.Format = "#,##0.00";
                sheet.Cells[row, 2, row, 33].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                sheet.Cells[row, 2, row, 33].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                sheet.Cells[row, 2, row, 33].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                sheet.Cells[row, 2, row, 33].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                count += 1;
                row += 1;
            }

            sheet.Rows[row].Height = 4;
           
            sheet.Cells[row + 1, 22, row+1, 26].Merge=true;
            sheet.Cells[row + 1, 22].Value = "Итого:";
            sheet.Cells[row + 1, 22].Style.HorizontalAlignment=ExcelHorizontalAlignment.Right;

            sheet.Cells[row + 1, 27, row + 1, 33].Merge = true;
            sheet.Cells[row + 1, 27].Value = invoice.Amount;
            sheet.Cells[row + 1, 27].Style.Numberformat.Format = "#,##0.00";

            string nds;
            if (invoice.Nds.Id == 1)
            {
                nds=invoice.Nds.Name;
            }
            else
            {
                nds = $"НДС {invoice.Nds.Name}";
            }

           
            sheet.Cells[row + 2, 19, row + 2, 26].Merge = true;
            sheet.Cells[row + 2, 19].Value = nds;
            sheet.Cells[row + 2, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            sheet.Cells[row + 2, 27, row + 2, 33].Merge = true;
            sheet.Cells[row + 2, 27].Value = invoice.AmountNds;
            sheet.Cells[row + 2, 27].Style.Numberformat.Format = "#,##0.00";

            sheet.Cells[row + 3, 19, row + 3, 26].Merge = true;
            sheet.Cells[row + 3, 19].Value = "Всего к оплате:";
            sheet.Cells[row + 3, 19].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            sheet.Cells[row + 3, 27, row + 3, 33].Merge = true;
            sheet.Cells[row + 3, 27].Value = invoice.TotalAmount;
            sheet.Cells[row + 3, 27].Style.Numberformat.Format = "#,##0.00";

            sheet.Cells[row + 1, 19, row + 3, 33].Style.Font.Bold = true;

            sheet.Cells[row + 4, 2, row + 4, 33].Merge=true;
            sheet.Cells[row + 4, 2].Value = $"Всего наименований {count-1}, на сумму {invoice.TotalAmount:N2} руб.";

            sheet.Cells[row + 5, 2, row + 5, 33].Merge = true;
            sheet.Cells[row + 5, 2].Value = RusCurrency.Str((double)invoice.TotalAmount);
            sheet.Rows[row + 5].Height = 26;
            sheet.Cells[row + 5, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Top;

            sheet.Cells[row + 6, 2, row + 6, 33].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;

            sheet.Cells[row+8,2, row+8,6].Merge=true;
            sheet.Cells[row + 8, 2].Value = "Руководитель";

            sheet.Cells[row + 8, 7, row + 8, 17].Merge = true;
            sheet.Cells[row + 8, 7, row + 8, 17].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[row + 8, 7].Value = invoice.BankDetailsOrg.Organization.Director!.Post.Name;

            sheet.Cells[row + 8, 19, row + 8, 24].Merge = true;
            sheet.Cells[row + 8, 19, row + 8, 24].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            sheet.Cells[row + 8, 26, row + 8, 33].Merge = true;
            sheet.Cells[row + 8, 26, row + 8, 33].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells[row + 8, 26].Value = $"{invoice.BankDetailsOrg.Organization.Director!.People.Surname} " +
                                             $"{invoice.BankDetailsOrg.Organization.Director!.People.Name[0]}. " +
                                             $"{invoice.BankDetailsOrg.Organization.Director!.People.Patronymic[0]}.";

            sheet.Cells[row + 9, 7, row + 9, 17].Merge = true;
            sheet.Cells[row + 9, 7].Value = "должность";

            sheet.Cells[row + 9, 19, row + 9, 24].Merge = true;
            sheet.Cells[row + 9, 19].Value = "подпись";

            sheet.Cells[row + 9, 26, row + 9, 33].Merge = true;
            sheet.Cells[row + 9, 26].Value = "расшифровка подписи";
            sheet.Cells[row + 9, 7, row + 9, 33].Style.Font.Size = 8;
            sheet.Cells[row + 9, 7, row + 9, 33].Style.VerticalAlignment= ExcelVerticalAlignment.Top;
            sheet.Cells[row + 9, 7, row + 9, 33].Style.HorizontalAlignment= ExcelHorizontalAlignment.Center;

            sheet.Cells[row + 10, 7].Value = "М.П.";

            FileInfo fi = new FileInfo(patch);
            package.SaveAs(fi);
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(patch)
            {
                UseShellExecute = true
            };
            p.Start();
        }
    }



}
