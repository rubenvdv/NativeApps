using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
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
    public sealed partial class Aanmelden : Page
    {
        Services services;

        public Aanmelden()
        {
            this.InitializeComponent();
        }

        private async void aanmelden_Click(object sender, RoutedEventArgs e)
        {
            services = new Services();
            ObservableCollection<IngelogdeGebruiker> ingelogdeGebruikers = await services.getIngelogdeGebruikers();
            Debug.Write("Er is een lijst van ingelogde gebruikers: " + ingelogdeGebruikers.ToString());
            Gebruiker gebruiker = ingelogdeGebruikers.FirstOrDefault(g => g.Gebruikersnaam.Equals(gebruikersnaam.Text));
            //Gebruiker gebruiker = await services.getIngelogdeGebruiker(gebruikersnaam.Text);
            Debug.Write("De gebruiker is: " + gebruiker.ToString());
            if (gebruiker== null)
            {
                foutmelding.Text = "OPGELET: Gebruiker bestaat niet";
            }
            else if (!wachtwoord.Password.Equals(gebruiker.Wachtwoord))
            {
                foutmelding.Text = "OPGELET: Onjuiste combinatie gebruikersnaam/wachtwoord";
            }
            else
            {
                ((App)Application.Current).huidigeGebruiker = gebruiker;

                frameMeldAan.Navigate(typeof(StartschermAnoniem));
            }

        }
    }
}
