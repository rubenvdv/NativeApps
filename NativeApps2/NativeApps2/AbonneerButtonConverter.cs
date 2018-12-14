using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace NativeApps2
{
    class AbonneerButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Onderneming onderneming = (Onderneming) value;
            IngelogdeGebruiker ingelogdeGebruiker = (IngelogdeGebruiker)parameter;
            if (ingelogdeGebruiker.VolgendeOndernemingen.Contains(onderneming))
                return "Geabonneerd";
            else
                return "Abonneer";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
