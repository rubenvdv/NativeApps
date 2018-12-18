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
        private ObservableCollection<Onderneming> volgendeOndernemingen = new ObservableCollection<Onderneming>();

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

        public async Task<ObservableCollection<Onderneming>> HaalOnderenmingenVanOndernemerOp(Ondernemer ondernemer)
        {
            ondernemingen = new ObservableCollection<Onderneming>();
            services = new Services();
            ondernemingen = await services.getOndernemingenVanOndernemer(ondernemer);
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

        public List<Onderneming> FilterLijst(string cat, string naam, ObservableCollection<Onderneming> ondernemingen)
        {
            List<Onderneming> filterLijst = new List<Onderneming>();

            if (cat == null || cat.Equals("Alle") || cat.Equals(""))
            {
                if (naam == null || naam.Equals(""))
                {
                    return ondernemingen.ToList();
                }
                else
                {
                    filterLijst = ondernemingen.Where(o => o.Naam.IndexOf(naam, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
            }
            else
            {
                if (naam == null || naam.Equals(""))
                {
                    filterLijst = ondernemingen.Where(o => o.Categorie.IndexOf(cat, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                else
                {
                    filterLijst = ondernemingen.Where(o => o.Categorie.IndexOf(cat, StringComparison.OrdinalIgnoreCase) >= 0 && o.Naam.IndexOf(naam, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
            }

            return filterLijst;
        }

    }
}
