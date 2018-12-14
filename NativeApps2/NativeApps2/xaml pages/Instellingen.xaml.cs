using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class Instellingen : Page
    {
        private Services services;
        public Instellingen()
        {
            this.InitializeComponent();
            services = new Services();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Gebruiker g = ((App)Application.Current).huidigeGebruiker;
            voorNaam.Text = g.Voornaam;
            naam.Text = g.Naam;
            mail.Text = g.Email;
            gebruikersnaam.Text = g.Gebruikersnaam;
            wachtwoord.Text = g.Wachtwoord;
        }

        private void Annuleer_Click(object sender, RoutedEventArgs e)
        {
            frameInstellingen.Navigate(typeof(Overzicht));
        }

        public async void Wijzigen_Click(object sender, RoutedEventArgs e)
        {
            Gebruiker g = ((App)Application.Current).huidigeGebruiker;
            g.Voornaam = voorNaam.Text;
            g.Naam = naam.Text;
            g.Email = mail.Text;
            g.Gebruikersnaam = gebruikersnaam.Text;
            g.Wachtwoord = wachtwoord.Text;

            await services.UpdateGebruiker(g, g.GetType());
            frameInstellingen.Navigate(typeof(Instellingen));
        }
    }
}
