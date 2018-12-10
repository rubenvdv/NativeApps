using NativeApps2.Domain;
using NativeApps2.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.ViewModels
{
    class OverzichtViewModel
    {
        public ObservableCollection<Onderneming> Ondernemingen { get; set; }
        public RelayCommand RelayCommand { get; set; }
        public Services services;
        public OverzichtViewModel()
        {
            services = new Services();
            Ondernemingen = new ObservableCollection<Onderneming>(services.getOndernemingen().Result);
        }

    }
}
