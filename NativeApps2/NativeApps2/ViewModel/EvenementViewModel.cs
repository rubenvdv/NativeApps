using NativeApps2.Domain;
using NativeApps2.xaml_pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace NativeApps2.ViewModel
{
    class EvenementViewModel
    {
        private Services services;
        private ObservableCollection<Evenement> evenementen;
        private ObservableCollection<Onderneming> volgendeOndernemingen = new ObservableCollection<Onderneming>();

        public ObservableCollection<Evenement> Evenementen
        {
            get;
            set;
        }

        public async Task<ObservableCollection<Evenement>> HaalAlleEvenementenOp()
        {
            services = new Services();
            evenementen = new ObservableCollection<Evenement>();
            evenementen = await services.getEvenementen();
            Evenementen = evenementen;
            return Evenementen;
        }

        public async Task<ObservableCollection<Evenement>> HaalAlleEvenementenVanOndernemingOp(Onderneming onderneming)
        {
            services = new Services();
            evenementen = new ObservableCollection<Evenement>();
            evenementen = await services.getEvenementenVanOnderneming(onderneming);
            Evenementen = evenementen;
            return Evenementen;
        }

        public async Task<ObservableCollection<Evenement>> HaalEvenementenVanVolgendeOndernemingenOp(ObservableCollection<Onderneming> volgendeOndernemingen)
        {
            evenementen = new ObservableCollection<Evenement>();
            IList<Evenement> evenementenVanOnderneming = new List<Evenement>();
            services = new Services();
            foreach (Onderneming o in volgendeOndernemingen)
            {
                evenementenVanOnderneming = await services.getEvenementenVanOnderneming(o);
                foreach (Evenement ev in evenementenVanOnderneming)
                    evenementen.Add(ev);
            }
            Evenementen = evenementen;
            return Evenementen;
        }

        public async Task<string> BepaalString()
        {
            string resultaat = "controle";
            Gebruiker gebruiker = ((App)Application.Current).huidigeGebruiker;
            Type typeGebruiker = gebruiker.GetType();
            ObservableCollection<Onderneming> volgendeOndernemingen = new ObservableCollection<Onderneming>();

            if (typeGebruiker == typeof(IngelogdeGebruiker))
            {
                volgendeOndernemingen = ((IngelogdeGebruiker)gebruiker).VolgendeOndernemingen;
                resultaat = "Er worden voorlopig geen evenementen georganiseerd door uw gevolgde ondernemingen";

            }
            else
            {
                services = new Services();
                volgendeOndernemingen = await services.getOndernemingenVanOndernemer((Ondernemer)gebruiker);
                resultaat =  "Uw ondernemingen hebben momenteel geen lopende/aankomende evenementen";
            }

            ObservableCollection<Evenement> lijstVanEvenementen = await HaalEvenementenVanVolgendeOndernemingenOp(volgendeOndernemingen);

            int aantalElementen = lijstVanEvenementen.Count;
            if (aantalElementen > 0) resultaat = "";
            return resultaat;
        }


    }
}
