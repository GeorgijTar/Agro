using Agro.DAL.Entities;
using OfficeOpenXml;


namespace ReportExcelLib;

public class InvoiceReportExcel
{
    public void Print(string patch, Invoice invoice)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var package = new ExcelPackage())
        {
            var sheet = package.Workbook.Worksheets.Add("My Sheet");
            sheet.Cells["A1"].Value = "Hello World!";






            FileInfo fi = new FileInfo(patch);
            package.SaveAs(fi);


        }
    }



}
