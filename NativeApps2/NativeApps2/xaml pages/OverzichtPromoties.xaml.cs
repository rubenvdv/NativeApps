using NativeApps2.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OverzichtPromoties : Page
    {
        private Services services;
        private ObservableCollection<Promotie> promoties = new ObservableCollection<Promotie>();

        public OverzichtPromoties()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Test-fase
            /* List<Onderneming> ondernemingen = new List<Onderneming>();
             Onderneming apple = new Onderneming("Apple inc", "Technologie", "California", "Ma-Vrij 08u00-17u30", "apple.jpg");
             ondernemingen.Add(apple);
             Onderneming ikea = new Onderneming("Ikea", "Meubels", "Sweden", "Ma-Vrij 08u00-17u30 zat-zon 08u-21u00", "ikea.png");
             ondernemingen.Add(ikea);
             promoties.Add(new Promotie("Black Friday", "Kortingen tot 70 procent", new DateTime(2018, 1, 1), new DateTime(2018, 1, 1), ikea, "70% korting"));
             promoties.Add(new Promotie("Winkelopening Gent", "Openingsacties", new DateTime(2018, 2, 10), new DateTime(2018, 2, 17), apple, "Gratis goodiebag bij een aankoop naar keuze"));
             promoties.Add(new Promotie("Uitverkoop winkel Antwerpen", "Kortingen tot 50 procent", new DateTime(2018, 3, 12), new DateTime(2018, 3, 31), ikea, "50% korting"));
             */


            services = new Services();
            promoties = await services.getPromoties();
            lvPromoties.ItemsSource = promoties;
        }

        //VRAAG: moet hier geen onderneming meegegeven worden als parameter?
        //Een evenement heeft toch altijd een onderneming?
        internal void VoegPromotieToe(object selectedItem, string naam, string omschrijving, DateTime begindatum, DateTime einddatum, string korting)
        {
            Onderneming onderneming = (Onderneming)selectedItem;
            //promoties.Add(new Promotie(naam, omschrijving, begindatum, einddatum, onderneming, korting));
        }

        private void Promotie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameOverzichtPromoties.Navigate(typeof(PromotieGegevens));

        }
    }
}
