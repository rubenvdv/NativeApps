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
    public sealed partial class Account : Page
    {
        public Account()
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
            //List<Onderneming> ondernemingen = new List<Onderneming>();
            //ondernemingen.Add(new Onderneming("Apple inc", "Technologie", "California", "Ma-Vrij 08u00-17u30"/*, "apple.jpg"*/));
            //ondernemingen.Add(new Onderneming("Ikea", "Meubels", "Sweden", "Ma-Vrij 08u00-17u30 zat-zon 08u-21u00"/*, "ikea.png"*/));
            //lvAccountAbonnees.ItemsSource = ondernemingen;
        }

        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameAccount.Navigate(typeof(OndernemingGegevens));
        }
    }
}
