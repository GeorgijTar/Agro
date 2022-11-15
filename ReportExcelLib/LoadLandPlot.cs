
using Agro.DAL.Entities.Agronomy;
using OfficeOpenXml;

namespace ReportExcelLib;

public static class LoadLandPlot
{
    public static List<LandPlot> Get(string filPath)
    {
        List<LandPlot> landPlots = new List<LandPlot>();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var package = new ExcelPackage(new FileInfo(filPath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault()!;

            int rows = worksheet!.Dimension.Rows; // 20
            int columns = worksheet.Dimension.Columns; // 7

            for (int i = 1; i <= rows; i++)
            {
                LandPlot landPlot = new LandPlot();
                landPlot.Number = worksheet.Cells[i, 1].Value.ToString()!;
                landPlot.Area= (double) worksheet.Cells[i, 2].Value;
                landPlot.Cost=decimal.Parse(worksheet.Cells[i, 3].Value.ToString()!);
                landPlot.BalanceValue = decimal.Parse(worksheet.Cells[i, 3].Value.ToString()!);
                landPlots.Add(landPlot);
            }
        }
        return landPlots;
    }
}
