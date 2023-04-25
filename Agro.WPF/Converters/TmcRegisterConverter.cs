
using Agro.DAL.Entities.Warehouse.Coming;
using System;
using System.Globalization;
using System.Windows.Data;
using Agro.DAL.Entities.Warehouse.Decommissioning;

namespace Agro.WPF.Converters;
public class TmcRegisterConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null!)
        {
            if ((parameter as string) == "Comming")
            {
                var com = (ComingTmc)value;
                return $"№ {com.NumberDoc} от {com.DateDoc.ToShortDateString()}";
            }
            else if ((parameter as string) == "Decommissioning")
            {
                var dec = (DecommissioningTmc)value;
                return $"№ {dec.Number} от {dec.Date.ToShortDateString()}";
            }
            else if ((parameter as string) == "WriteOffObject")
            {
                var wr = (WriteOffObject)value;
                string invReg = "";

                if (!string.IsNullOrEmpty(wr.RegNumber))
                {
                    invReg += $" Рег. № {wr.RegNumber}";
                }
                if (!string.IsNullOrEmpty(wr.InvNumber))
                {
                    invReg += $" Инв. № {wr.InvNumber}";
                }
                
                return wr.Name + invReg;
            }
            else
            {
                return "";
            }
        }

        return "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
