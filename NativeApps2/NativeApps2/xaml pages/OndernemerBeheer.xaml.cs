using NativeApps2.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
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
                IList<Evenement> events = await services.getEvenementenVanOnderneming(o);
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
            StackPanel sp = sender as StackPanel;
            Onderneming onderneming = sp.DataContext as Onderneming;
            frameOndernemerBeheer.Navigate(typeof(OndernemingGegevens), onderneming);
        }

        private void Promotie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Promotie promotie = sp.DataContext as Promotie;
            frameOndernemerBeheer.Navigate(typeof(PromotieGegevens),promotie);
        }

        private void Evenement_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Evenement evenement = sp.DataContext as Evenement;
            frameOndernemerBeheer.Navigate(typeof(EvenementGegevens), evenement);
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
