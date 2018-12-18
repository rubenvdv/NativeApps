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
    public class PromotieViewModel
    {
        private Services services;
        private ObservableCollection<Promotie> promoties;
        private ObservableCollection<Onderneming> volgendeOndernemingen = new ObservableCollection<Onderneming>();

        public ObservableCollection<Promotie> Promoties
        {
            get;
            set;
        }

        public async Task<ObservableCollection<Promotie>> HaalPromotiesVanOndernemingOp(Onderneming onderneming)
        {
            services = new Services();
            promoties = new ObservableCollection<Promotie>();
            promoties = await services.getPromotiesVanOnderneming(onderneming);
            Promoties = promoties;
            return Promoties;
        }



        public async Task<ObservableCollection<Promotie>> HaalPromotiesVanVolgendeOndernemingenOp(ObservableCollection<Onderneming> volgendeOndernemingen)
        {
            promoties = new ObservableCollection<Promotie>();
            IList<Promotie> promotiesVanOnderneming = new List<Promotie>();
            services = new Services();
            foreach (Onderneming o in volgendeOndernemingen)
            {
                promotiesVanOnderneming = await services.getPromotiesVanOnderneming(o);
                foreach (Promotie promo in promotiesVanOnderneming)
                {
                    promoties.Add(promo);
                }
            }
            Promoties = promoties;
            return Promoties;
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
                volgendeOndernemingen = await services.getOndernemingenVanOndernemer((Ondernemer)gebruiker);
                resultaat = "Uw ondernemingen hebben momenteel geen lopende/aankomende evenementen";
            }

            ObservableCollection<Promotie> lijstVanPromoties = await HaalPromotiesVanVolgendeOndernemingenOp(volgendeOndernemingen);

            int aantalElementen = lijstVanPromoties.Count;
            if (aantalElementen > 0) resultaat = "";
            return resultaat;
        }
    }
}
