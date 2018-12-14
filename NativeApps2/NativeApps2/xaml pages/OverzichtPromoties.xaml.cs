using NativeApps2.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private ObservableCollection<Onderneming> volgendeOndernemingen = new ObservableCollection<Onderneming>();

        public OverzichtPromoties()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            services = new Services();

            Gebruiker gebruiker = ((App)Application.Current).huidigeGebruiker;
            Type typeGebruiker = gebruiker.GetType();

            if (typeGebruiker == typeof(IngelogdeGebruiker))
            {
                volgendeOndernemingen = ((IngelogdeGebruiker)gebruiker).VolgendeOndernemingen;
                bericht.Text = "Er worden voorlopig geen promoties georganiseerd door uw gevolgde ondernemingen";
            }
            else
            {
                volgendeOndernemingen = await services.getOndernemingenVanOndernemer((Ondernemer)gebruiker);
                bericht.Text = "Uw ondernemingen hebben momenteel geen lopende/aankomende promoties";

            }


            IList<Promotie> promotiesVanOnderneming = new List<Promotie>();
            foreach (Onderneming o in volgendeOndernemingen)
            {
                promotiesVanOnderneming = await services.getPromotiesVanOnderneming(o);
                foreach (Promotie promo in promotiesVanOnderneming)
                {
                    promoties.Add(promo);
                    Debug.WriteLine(promo.Naam);
                }
            }
            //Hier moeten enkel alle promoties die de gebruiker volgt meegegeven worden maar dat bestaat nog niet.

            int aantalElementen = promoties.Count;

            if (aantalElementen > 0)
            {
                bericht.Text = "";
                lvPromoties.ItemsSource = promoties;
            }
        }

        //VRAAG: moet hier geen onderneming meegegeven worden als parameter?
        //Een evenement heeft toch altijd een onderneming?
        /*internal void VoegPromotieToe(object selectedItem, string naam, string omschrijving, DateTime begindatum, DateTime einddatum, string korting)
        {
            Onderneming onderneming = (Onderneming)selectedItem;
            promoties.Add(new Promotie(naam, omschrijving, begindatum, einddatum, onderneming, korting));
        }*/

        private void Promotie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Promotie promotie = sp.DataContext as Promotie;
            frameOverzichtPromoties.Navigate(typeof(PromotieGegevens), promotie);

        }
    }
}
