using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace NativeApps2.ViewModel
{
    public class OndernemingViewModel
    {
        private Services services;

        public ObservableCollection<Onderneming> Ondernemingen
        {
            get;
            set;
        }

        public async Task<ObservableCollection<Onderneming>> HaalOndernemingenOp()
        {
            ObservableCollection<Onderneming> ondernemingen = new ObservableCollection<Onderneming>();
            services = new Services();
            IngelogdeGebruiker gebruiker = ((IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker);
            ondernemingen = await services.getVolgendeOndernemingenVanGebruiker(gebruiker);
            Ondernemingen = ondernemingen;
            return Ondernemingen;
        }
    }
}
