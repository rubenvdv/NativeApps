using NativeApps2.Domain;
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
                Gebruiker g = ((App)Application.Current).huidigeGebruiker;
                //int gebruikersId = g.gebruikersId;
                g.Voornaam = voorNaam.Text;
                g.Naam = naam.Text;
                g.Email = mail.Text;
                g.Gebruikersnaam = gebruikersnaam.Text;

                await services.UpdateGebruikerGegevens(g);
                succesMessage.Text = "Gegevens succesvol aangepast!";
                foutmelding.Text = "";
            }
            else
            {
                succesMessage.Text = "";
                foutmelding.Text = "Gelieve alle gegevens in te vullen!";
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
                foutmelding.Text = "";
            }
            else
            {
                succesMessage.Text = "";
                foutmelding.Text = "Gelieve een correct wachtwoord in te vullen!";
            }
        }
    }
}
