using System.Diagnostics;
using Agro.Dto.Warehouse;
using OfficeOpenXml;


namespace ReportExcelLib.Tmc;

public static class SprTmcToExcel
{
    public static void ToExcel(IEnumerable<TmcSprDto>? coll, string patch)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;



        using (var package = new ExcelPackage())
        {
            var sheet = package.Workbook.Worksheets.Add("My Sheet");

            sheet.Cells["A1"].Value = "ИД";
            sheet.Cells["B1"].Value = "Артикул";
            sheet.Cells["C1"].Value = "Наименование";
            sheet.Cells["D1"].Value = "Ед.изм.";
            sheet.Cells["E1"].Value = "Кол-во";
            sheet.Cells["F1"].Value = "Цена";
            sheet.Cells["G1"].Value = "Сумма";
            sheet.Cells["H1"].Value = "Сч.учета";
            sheet.Cells["I1"].Value = "Склад";

            var row = 2;
            foreach (TmcSprDto dto in coll!)
            {
                sheet.Cells["A" + row].Value = dto.Id;
                sheet.Cells["B" + row].Value = dto.Article;
                sheet.Cells["C" + row].Value = dto.NameTmc;
                sheet.Cells["D" + row].Value = dto.Unit;
                sheet.Cells["E" + row].Value = dto.Quantity;
                sheet.Cells["F" + row].Value = dto.Price;
                sheet.Cells["G" + row].Value = dto.Amount;
                sheet.Cells["H" + row].Value = dto.AccountingPlanCode;
                sheet.Cells["I" + row].Value = dto.StorageLocation;
                row++;
            }
            
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
