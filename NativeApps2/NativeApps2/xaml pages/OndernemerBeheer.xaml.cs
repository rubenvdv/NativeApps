using NativeApps2.Domain;
using System;
using System.Collections.Generic;
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
        public OndernemerBeheer()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //this.DataContext = ((App)Application.Current).huidigeGebruiker;
            Gebruiker huidig = ((App)Application.Current).huidigeGebruiker;
            naam.Text = huidig.Naam;
            voorNaam.Text = huidig.Voornaam;
            mail.Text = huidig.Email;
            gebruikersnaam.Text = huidig.Gebruikersnaam;

            //Dit werkt nog niet
            //lvAccountAbonnees.ItemsSource = ((App)Application.Current).huidigeGebruiker.VolgendeOndernemingen;

            //Test-fase
            List<Onderneming> ondernemingen = new List<Onderneming>();
            Onderneming apple = new Onderneming("Apple inc", "Technologie", "California", "Ma-Vrij 08u00-17u30", "apple.jpg");
            ondernemingen.Add(apple);
            Onderneming ikea = new Onderneming("Ikea", "Meubels", "Sweden", "Ma-Vrij 08u00-17u30 zat-zon 08u-21u00", "ikea.png");
            ondernemingen.Add(ikea);
            lvOnderemingen.ItemsSource = ondernemingen;

            List<Evenement> evenementen = new List<Evenement>();
            evenementen.Add(new Evenement("Apple keynote", "Apple launching the new iPhone Xs", new DateTime(2018, 11, 1), new DateTime(2018, 11, 1), apple));
            evenementen.Add(new Evenement("Apple keynote", "Apple launching the new iPhone Xs max", new DateTime(2018, 11, 1), new DateTime(2018, 11, 1), apple));
            evenementen.Add(new Evenement("Ikea", "New Ikea brochure is launched today", new DateTime(2018, 1, 1), new DateTime(2018, 1, 1), ikea));
            lvEvenementen.ItemsSource = evenementen;

            List<Promotie> promoties = new List<Promotie>();
            promoties.Add(new Promotie("Black Friday", "Kortingen tot 70 procent", new DateTime(2018, 1, 1), new DateTime(2018, 1, 1), ikea, "70% korting"));
            promoties.Add(new Promotie("Winkelopening Gent", "Openingsacties", new DateTime(2018, 2, 10), new DateTime(2018, 2, 17), apple, "Gratis goodiebag bij een aankoop naar keuze"));
            promoties.Add(new Promotie("Uitverkoop winkel Antwerpen", "Kortingen tot 50 procent", new DateTime(2018, 3, 12), new DateTime(2018, 3, 31), ikea, "50% korting"));
            lvPromoties.ItemsSource = promoties;
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
