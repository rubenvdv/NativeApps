using NativeApps2.Domain;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
        }

        private void Annuleer_Click(object sender, RoutedEventArgs e)
        {
            frameInstellingen.Navigate(typeof(Overzicht));
        }

        private async void WijzigenGegevens_Click(object sender, RoutedEventArgs e)
        {
            if (!naam.Text.Equals("") && !voorNaam.Text.Equals("") && !mail.Text.Equals("") && !gebruikersnaam.Text.Equals(""))
            {
                Gebruiker gebr = ((App)Application.Current).huidigeGebruiker;
                IEnumerable<Gebruiker> gebruikers;
                if (gebr.GetType() == typeof(IngelogdeGebruiker))
                {
                    gebruikers = await services.getIngelogdeGebruikers();
                }
                else
                {
                    gebruikers = await services.getOndernemers();
                }

                Gebruiker gMetGNaam = gebruikers.FirstOrDefault(ge => ge.Gebruikersnaam.Equals(gebruikersnaam.Text));
                Gebruiker gMetEmail = gebruikers.FirstOrDefault(ge => ge.Email.Equals(mail.Text));

                if ((gMetGNaam == null && gMetEmail == null) || (gebr.Gebruikersnaam == gebruikersnaam.Text && gMetEmail == null) || (gMetGNaam == null && gebr.Email == mail.Text) || (gebr.Gebruikersnaam == gebruikersnaam.Text && gebr.Email == mail.Text))
                {
                    Gebruiker g = ((App)Application.Current).huidigeGebruiker;
                    //int gebruikersId = g.gebruikersId;
                    g.Voornaam = voorNaam.Text;
                    g.Naam = naam.Text;
                    g.Email = mail.Text;
                    g.Gebruikersnaam = gebruikersnaam.Text;

                    await services.UpdateGebruikerGegevens(g);
                    succesMessage.Text = "Gegevens succesvol aangepast!";
                    foutmeldingGegevens.Text = "";
                }
                else
                {
                    if (gMetGNaam != null)
                    {
                        succesMessage.Text = "Gegevens succesvol aangepast!";
                        foutmeldingGegevens.Text = "Er bestaat al een gebruiker met deze gebruikersnaam!";
                    }
                    else
                    {
                        succesMessage.Text = "Gegevens succesvol aangepast!";
                        foutmeldingGegevens.Text = "Er bestaat al een gebruiker met dit emailadres!";
                    }
                    gMetGNaam = null;
                    gMetEmail = null;
                }
            }
            else
            {
                succesMessage.Text = "";
                foutmeldingGegevens.Text = "Gelieve alle gegevens in te vullen!";
            }

        }

        private async void WijzigenPassword_Click(object sender, RoutedEventArgs e)
        {
            if (!wachtwoord.Password.Equals("") && wachtwoord.Password.Equals(bevestigWachtwoord.Password))
            {
                Gebruiker g = ((App)Application.Current).huidigeGebruiker;
                g.Wachtwoord = wachtwoord.Password;

                await services.UpdateGebruikerPassword(g);
                succesMessage.Text = "Wachtwoord succesvol aangepast!";
                foutmeldingPasswd.Text = "";
            }
            else
            {
                succesMessage.Text = "";
                foutmeldingPasswd.Text = "Gelieve een correct wachtwoord in te vullen!";
            }
        }
    }
}
