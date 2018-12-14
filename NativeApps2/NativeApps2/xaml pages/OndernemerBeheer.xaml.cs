using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
    public sealed partial class OndernemerBeheer : Page
    {

        Services services;
        public ObservableCollection<Onderneming> ondernemingen = new ObservableCollection<Onderneming>();
        public ObservableCollection<Evenement> evenementen = new ObservableCollection<Evenement>();
        public ObservableCollection<Promotie> promos = new ObservableCollection<Promotie>();


        public OndernemerBeheer()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Ondernemer huidig = (Ondernemer)((App)Application.Current).huidigeGebruiker;
            naam.Text = huidig.Naam;
            voorNaam.Text = huidig.Voornaam;
            mail.Text = huidig.Email;
            gebruikersnaam.Text = huidig.Gebruikersnaam;

            services = new Services();

            ondernemingen = await services.getOndernemingenVanOndernemer(huidig);
            lvOndernemingen.ItemsSource = ondernemingen;

            foreach ( Onderneming o in ondernemingen)
            {
                IList<Evenement> events = await services.getEvenementenVanOnderneming(o.OndernemingID);
                foreach (Evenement ev in events)
                    evenementen.Add(ev);

                IList<Promotie> promoties = await services.getPromotiesVanOnderneming(o);
                foreach (Promotie p in promoties)
                    promos.Add(p);
            }

            lvEvenementen.ItemsSource = evenementen;
            lvPromoties.ItemsSource = promos;

        }

        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameOndernemerBeheer.Navigate(typeof(OndernemingGegevens));
        }

        private void Promotie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameOndernemerBeheer.Navigate(typeof(PromotieGegevens));
        }

        private void Evenement_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameOndernemerBeheer.Navigate(typeof(EvenementGegevens));
        }

        private void ondernemingVoegToe_Click(object sender, RoutedEventArgs e)
        {
            frameOndernemerBeheer.Navigate(typeof(OndernemingAanmaken));
        }

        private void evenementVoegToe_Click(object sender, RoutedEventArgs e)
        {
            frameOndernemerBeheer.Navigate(typeof(EvenementAanmaken));
        }

        private void promotieVoegToe_Click(object sender, RoutedEventArgs e)
        {
            frameOndernemerBeheer.Navigate(typeof(PromotieAanmaken));
        }
    }
}
