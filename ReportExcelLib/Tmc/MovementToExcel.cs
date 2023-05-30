using Agro.DAL.Entities.Registers;
using Agro.Dto.Warehouse;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace ReportExcelLib.Tmc;

public static class MovementToExcel
{
    public static void ToExcel(IEnumerable<TmcRegister>? tmcRegisters, TmcSprDto tmcSprDto, string patch)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;



        using (var package = new ExcelPackage())
        {
            var sheet = package.Workbook.Worksheets.Add("My Sheet");
            sheet.Column(1).Width = 5.78;
            sheet.Column(2).Width = 12.44;
            sheet.Column(3).Width = 11;
            sheet.Column(4).Width = 20.22;
            sheet.Column(5).Width = 17.89;
            sheet.Column(6).Width = 10;
            sheet.Column(7).Width = 10.22;
            sheet.Column(8).Width = 13;
            sheet.Column(9).Width = 17.89;
            sheet.Column(10).Width = 8.11;
            sheet.Column(11).Width = 8.11;
            sheet.Column(12).Width = 18.33;
            sheet.Column(13).Width = 15;
            sheet.Column(14).Width = 28.80;

            sheet.Cells["A1:N1"].Merge=true;
            sheet.Cells["A1:N1"].Style.Font.Bold=true;
            sheet.Cells["A1"].Value = "Движение ТМЦ";
            sheet.Cells["A2:B2"].Merge=true;
            sheet.Cells["A2"].Value = "по состоянию на";
            sheet.Cells["C2"].Value = DateTime.Now.Date;
            sheet.Cells["C2"].Style.Numberformat.Format = "dd.MM.yyyy";
            sheet.Cells["C2"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells["A3:B3"].Merge = true;
            sheet.Cells["A3"].Value = "Наименование ТМЦ:";
            sheet.Cells["C3:N3"].Merge= true;
            sheet.Cells["C3:N3"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            sheet.Cells["C3:N3"].Style.Font.Bold = true;
            sheet.Cells["C3"].Value = tmcSprDto.NameTmc;
            sheet.Cells["A4:B4"].Merge = true;
            sheet.Cells["A4"].Value = "Ед. измерения:";
            sheet.Cells["C4:D4"].Merge = true;
            sheet.Cells["C4"].Value = tmcSprDto.Unit;
            sheet.Cells["A5:B5"].Merge = true;
            sheet.Cells["A5"].Value = "Текущий остаток:";
            sheet.Cells["C5"].Value = tmcSprDto.Quantity;
            sheet.Cells["C5"].Style.Numberformat.Format = "#,###0.000";

            sheet.Cells["A7"].Value = "№ п/п";
            sheet.Cells["B7"].Value = "Тип движения";
            sheet.Cells["C7"].Value = "Дата";
            sheet.Cells["D7"].Value = "Документ поступления";
            sheet.Cells["E7"].Value = "Документ списания";
            sheet.Cells["F7"].Value = "Кол-во";
            sheet.Cells["G7"].Value = "Цена, руб.";
            sheet.Cells["H7"].Value = "Сумма, руб.";
            sheet.Cells["I7"].Value = "Склад";
            sheet.Cells["J7"].Value = "Дт.";
            sheet.Cells["K7"].Value = "Кт.";
            sheet.Cells["L7"].Value = "Поставщик";
            sheet.Cells["M7"].Value = "МОЛ";
            sheet.Cells["N7"].Value = "Объект списания";

            int row = 8;
            int n = 1;
            foreach (var register in tmcRegisters!)
            {
                sheet.Cells["A" + row].Value = n;
                sheet.Cells["B" + row].Value = register.TypeDoc;
                sheet.Cells["C" + row].Value= register.DateRegister;
                sheet.Cells["C" + row].Style.Numberformat.Format = "dd.MM.yyyy";
                if (register.ComingTmc != null!)
                {
                    sheet.Cells["D" + row].Value=$"№ {register.ComingTmc.NumberDoc} от {register.ComingTmc.DateDoc.ToShortDateString()}";
                    sheet.Cells["L" + row].Value = register.ComingTmc.Counterparty.Name;
                }
                    
                if (register.DecommissioningTmc != null!)
                {
                    sheet.Cells["E" + row].Value= $"№ {register.DecommissioningTmc!.Number} от {register.DecommissioningTmc.Date.ToShortDateString()}";
                    sheet.Cells["M" + row].Value = register.DecommissioningTmc.Mol.People;
                    string invReg = "";

                    if (!string.IsNullOrEmpty(register.DecommissioningTmc.WriteOffObject.RegNumber))
                    {
                        invReg += $" Рег. № {register.DecommissioningTmc.WriteOffObject.RegNumber}";
                       
                    }
                    if (!string.IsNullOrEmpty(register.DecommissioningTmc.WriteOffObject.InvNumber))
                    {
                        invReg += $" Инв. № {register.DecommissioningTmc.WriteOffObject.InvNumber}";
                    }

                    sheet.Cells["N" + row].Value = register.DecommissioningTmc.WriteOffObject.Name + invReg;
                    sheet.Cells["N" + row].Style.WrapText= true;
                }
                
                sheet.Cells["F" + row].Value = register.Quantity;
                sheet.Cells["F" + row].Style.Numberformat.Format = "#,###0.000";
                sheet.Cells["G" + row].Value = register.Price;
                sheet.Cells["G" + row].Style.Numberformat.Format = "#,##0.00";
                sheet.Cells["H" + row].Value = register.Amount;
                sheet.Cells["H" + row].Style.Numberformat.Format = "#,##0.00";
                sheet.Cells["I" + row].Value = register.StorageLocation;
                sheet.Cells["J" + row].Value = register.Debit.Code;
                sheet.Cells["K" + row].Value = register.Credit.Code;
                
                n++;
                row++;
            }

            sheet.Cells["A8:N" + row].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            sheet.Cells["A8:N" + row].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            sheet.Cells["A8:N" + row].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            sheet.Cells["A8:N" + row].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

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