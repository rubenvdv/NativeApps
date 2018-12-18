using NativeApps2.Domain;
using NativeApps2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginZakelijk : Page
    {
        Services services;

        public LoginZakelijk()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            cmbCategorie.DataContext = new CategorieViewModel();
            cmbCategorie.SelectedItem = "Andere";
        }

        private async void Registreer_Ondernemer(object sender, RoutedEventArgs e)
        {
            if (!naam.Text.Equals("") && !voorNaam.Text.Equals("") && !mail.Text.Equals("") && !gebruikersnaam.Text.Equals("") && !wachtwoord.Password.Equals("")
                && !naamOnderneming.Text.Equals("") && !cmbCategorie.SelectedItem.ToString().Equals("") && !adresOnderneming.Text.Equals("") && !openingsurenOnderneming.Text.Equals(""))
            {
                services = new Services();

                IEnumerable<Gebruiker> gebruikers = await services.getOndernemers();
                IEnumerable<Onderneming> ondernemingen = await services.getOndernemingen();

                Gebruiker gMetGNaam = gebruikers.FirstOrDefault(ge => ge.Gebruikersnaam.Equals(gebruikersnaam.Text));
                Gebruiker gMetEmail = gebruikers.FirstOrDefault(ge => ge.Email.Equals(mail.Text));
                Onderneming o = ondernemingen.FirstOrDefault(on => on.Naam.Equals(naamOnderneming.Text));

                if (gMetGNaam == null && o == null && gMetEmail == null)
                {
                    services = new Services();
                    Ondernemer ondernemer = new Ondernemer(naam.Text, voorNaam.Text, gebruikersnaam.Text, wachtwoord.Password, mail.Text);
                    
                    await services.registreerOndernemer(ondernemer);
                    
                    

                    Ondernemer ondernemerMetId = await services.getOndernemer(gebruikersnaam.Text);
                    Onderneming onderneming = new Onderneming { Naam = naamOnderneming.Text, Categorie = cmbCategorie.SelectedItem as string, Adres = adresOnderneming.Text, Openingsuren = openingsurenOnderneming.Text, OndernemerID = ondernemerMetId.OndernemerID };
                    await services.voegOndernemingToe(onderneming);

                    ((App)Application.Current).huidigeGebruiker = ondernemerMetId;
                    new NotificatieViewModel("Welkom", "U heeft zich succesvol geregistreerd!");
                    frameZakelijk.Navigate(typeof(StartschermAnoniem));
                }
                else
                {
                    if (gMetGNaam != null)
                    {
                        foutmelding.Text = "Er bestaat al een ondernemer met deze gebruikersnaam!";
                    }
                    else if (gMetEmail != null)
                    {
                        foutmelding.Text = "Er bestaat al een ondernemer met dit emailadres!";
                    }
                    else
                    {
                        foutmelding.Text = "Er bestaat al een onderneming met deze naam!";
                    }

                    gMetGNaam = null;
                    gMetEmail = null;
                    o = null;
                }
            }
            else
            {
                //Foutmelding weergeven
                foutmelding.Text = "Vul alle gegevens correct in!";
            }
        }

        private void Meld_Aan(object sender, RoutedEventArgs e)
        {
            frameZakelijk.Navigate(typeof(Aanmelden));
        }

        private void annuleer_Click(object sender, RoutedEventArgs e)
        {
            frameZakelijk.Navigate(typeof(MainPage));
        }
    }
}
