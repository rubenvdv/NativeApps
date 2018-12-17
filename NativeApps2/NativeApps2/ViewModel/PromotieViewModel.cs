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

        public ObservableCollection<Promotie> Promoties
        {
            get;
            set;
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
    }
}
