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
        private ObservableCollection<Onderneming> ondernemingen;

        public ObservableCollection<Onderneming> Ondernemingen
        {
            get;
            set;
        }

        public async Task<ObservableCollection<Onderneming>> HaalVolgendeOnderenmingenVanGebruikerOp()
        {
            ondernemingen = new ObservableCollection<Onderneming>();
            services = new Services();
            IngelogdeGebruiker gebruiker = ((IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker);
            ondernemingen = await services.getVolgendeOndernemingenVanGebruiker(gebruiker);
            Ondernemingen = ondernemingen;
            return Ondernemingen;
        }

        public async Task<ObservableCollection<Onderneming>> HaalAlleOndernemingenOp()
        {
            ondernemingen = new ObservableCollection<Onderneming>();
            services = new Services();
            ondernemingen = await services.getOndernemingen();
            Ondernemingen = ondernemingen;
            return Ondernemingen;
        }

    }
}
