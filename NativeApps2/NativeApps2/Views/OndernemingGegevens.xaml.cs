using NativeApps2.Domain;
using NativeApps2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
    public sealed partial class OndernemingGegevens : Page
    {
        Services services;
        public ObservableCollection<Evenement> _evenementen = new ObservableCollection<Evenement>();
        public ObservableCollection<Promotie> _promoties = new ObservableCollection<Promotie>();
        private Onderneming _onderneming;
        public string AbonnementName { get; set; }

        public OndernemingGegevens()
        {
            this.InitializeComponent();
            
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _onderneming = (Onderneming)e.Parameter;
            ondernemingGrid.DataContext = _onderneming;

            Type check = ((App)Application.Current).huidigeGebruiker.GetType();
            if (check == typeof(IngelogdeGebruiker))
            {
                //VisualStateManager.GoToState(this, "IngelogdeGebruiker", false);
                IngelogdeGebruiker gebruiker = (IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker;

                List<Onderneming> volgend = gebruiker.VolgendeOndernemingen.ToList();

                Onderneming o = volgend.FirstOrDefault(ond => ond.Naam.Equals(_onderneming.Naam));
                if (o != null)
                    abonneer.Content = "Geabonneerd";
                else
                    abonneer.Content = "Abonneren";

                abonneer.Visibility = Visibility.Visible;
                verwijderOnderneming.Visibility = Visibility.Collapsed;
                wijzigOnderneming.Visibility = Visibility.Collapsed;

            }
            else if (check == typeof(Ondernemer))
            {
                //VisualStateManager.GoToState(this, "ondernemer", false);
                abonneer.Visibility = Visibility.Collapsed;
                //verwijderOnderneming.Visibility = Visibility.Visible;
            }
            else
            {
                //VisualStateManager.GoToState(this, "nietIngelogdeGebruiker", false);
                abonneer.Visibility = Visibility.Collapsed;
                verwijderOnderneming.Visibility = Visibility.Collapsed;
                wijzigOnderneming.Visibility = Visibility.Collapsed;
            }

            services = new Services();
            //Met deze methode nog de onderneming waarover het gaat weergeven
            //evenementen = await services.getEvenementenVanOnderneming(onderneming);

            _evenementen = await services.getEvenementenVanOnderneming(_onderneming);
            lvOndernemingEvenementen.ItemsSource = _evenementen;

            _promoties = await services.getPromotiesVanOnderneming(_onderneming);
            lvOndernemingPromoties.ItemsSource = _promoties;
        }


        private void Evenement_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Evenement evenement = sp.DataContext as Evenement;
            frameOndernemingGegevens.Navigate(typeof(EvenementGegevens), evenement);

        }


        private async void Abonneer_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            IngelogdeGebruiker gebruiker = (IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker;

            if (b.Content.ToString() == "Geabonneerd")
            {
                gebruiker.VolgendeOndernemingen.Remove(_onderneming);
                //await services.VerwijderVolgendeOnderneming(gebruiker, _onderneming.OndernemingID);
                b.Content = "Abonneer";

            }
            else
            {
                gebruiker.VolgendeOndernemingen.Add(_onderneming);
                //await services.VoegVolgendeOndernemingToe(gebruiker, _onderneming.OndernemingID);
                b.Content = "Geabonneerd";
            }

        }

        private void wijzigOnderneming_Click(object sender, RoutedEventArgs e)
        {
            frameOndernemingGegevens.Navigate(typeof(WijzigOnderneming), _onderneming);
        }

        private async void verwijderOnderneming_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Promotie> promoties = await services.getPromotiesVanOnderneming(_onderneming);
            IEnumerable<Evenement> ondernemingen = await services.getEvenementenVanOnderneming(_onderneming);

            if (promoties.Count().Equals(0) && ondernemingen.Count().Equals(0))
            {
                await services.verwijderOnderneming(_onderneming);
                frameOndernemingGegevens.Navigate(typeof(OndernemerBeheer));
            }
            else
            {
                foutmelding.Text = "Een onderneming kan niet verwijderd worden zolang ze evenementen of promoties heeft!";
            }
        }

        private void Promotie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Promotie promotie = sp.DataContext as Promotie;
            frameOndernemingGegevens.Navigate(typeof(PromotieGegevens), promotie);
        }
    }
}
