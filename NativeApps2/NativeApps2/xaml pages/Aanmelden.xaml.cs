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
    public sealed partial class Aanmelden : Page
    {
        public Aanmelden()
        {
            this.InitializeComponent();
        }

        private void aanmelden_Click(object sender, RoutedEventArgs e)
        {
            List<Gebruiker> bestaande = new List<Gebruiker>();
            bestaande.Add(new IngelogdeGebruiker("ruben", "ruben", "ruben", "ruben"));

            Gebruiker gebruiker = bestaande.FirstOrDefault(g => g.Gebruikersnaam.Equals(gebruikersnaam.Text));
            if(gebruiker== null)
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
