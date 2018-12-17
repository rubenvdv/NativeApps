using NativeApps2.Domain;
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
                VisualStateManager.GoToState(this, "IngelogdeGebruiker", false);
                IngelogdeGebruiker gebruiker = (IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker;

                List<Onderneming> volgend = gebruiker.VolgendeOndernemingen.ToList();

                Onderneming o = volgend.FirstOrDefault(ond => ond.Naam.Equals(_onderneming.Naam));

                if (o != null)
                    abonneer.Content = "Geabonneerd";
                else
                    abonneer.Content = "Abonneren";

            }
            else
            {
                VisualStateManager.GoToState(this, "nietIngelogdeGebruiker", false);
            }

            services = new Services();
            //Met deze methode nog de onderneming waarover het gaat weergeven
            //evenementen = await services.getEvenementenVanOnderneming(onderneming);

            _evenementen = await services.getEvenementenVanOnderneming(_onderneming);
            lvOndernemingEvenementen.ItemsSource = _evenementen;
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
                b.Content = "Abonneer";

            }
            else
            {
                gebruiker.VolgendeOndernemingen.Add(_onderneming);
                await services.VoegVolgendeOndernemingToe(gebruiker, _onderneming.OndernemingID);
                b.Content = "Geabonneerd";
            }

        }

        
    }
}
