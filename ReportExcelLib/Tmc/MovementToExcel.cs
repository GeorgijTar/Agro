using Agro.Dto.Warehouse;
using OfficeOpenXml;

namespace ReportExcelLib.Tmc;

public static class MovementToExcel
{
    public static void ToExcel(IEnumerable<TmcSprDto>? coll, string patch)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;



        using (var package = new ExcelPackage())
        {
            var sheet = package.Workbook.Worksheets.Add("My Sheet");

            sheet.Cells["A1"].Value = "ИД";
        }
    }
}