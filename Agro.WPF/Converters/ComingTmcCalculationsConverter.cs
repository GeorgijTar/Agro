using Agro.DAL.Entities.Warehouse.Coming;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Agro.WPF.Converters
{
    class ComingTmcCalculationsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var calc = value as ComingTmcCalculations;
            if (calc!.AutoCalculation) return "Автоматически";
            if (calc!.ManualCalculation) return "По документу";
            if (calc!.NoCalculation) return "Не зачитывать";
            return "Не установлен";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
