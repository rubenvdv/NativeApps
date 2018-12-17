using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        Services services;

        public Login()
        {
            this.InitializeComponent();
            services = new Services();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!naam.Text.Equals("") && !voorNaam.Text.Equals("") && !mail.Text.Equals("") && !gebruikersnaam.Text.Equals("") && !wachtwoord.Password.Equals(""))
            {
                IEnumerable<Gebruiker> gebruikers = await services.getIngelogdeGebruikers();

                Gebruiker igGNaam = gebruikers.FirstOrDefault(g => g.Gebruikersnaam.Equals(gebruikersnaam.Text));
                Gebruiker igEmail = gebruikers.FirstOrDefault(g => g.Email.Equals(mail.Text));

                if (igGNaam == null && igEmail == null)
                {
                    IngelogdeGebruiker user = new IngelogdeGebruiker(naam.Text, voorNaam.Text, gebruikersnaam.Text, wachtwoord.Password, mail.Text);
                    await services.registreerGewonegebruiker(user);

                    IngelogdeGebruiker iGMetId = await services.getIngelogdeGebruiker(gebruikersnaam.Text);
                    ((App)Application.Current).huidigeGebruiker = iGMetId;

                    //Notificatie
                    ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText02;
                    XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
                    XmlNodeList toastTekstElementen = toastXml.GetElementsByTagName("text");
                    toastTekstElementen[0].AppendChild(toastXml.CreateTextNode("Welkom"));
                    toastTekstElementen[1].AppendChild(toastXml.CreateTextNode("U heeft zich succesvol geregistreerd!"));
                    XmlNodeList toastAfbeeldingElementen = toastXml.GetElementsByTagName("image");
                    ((XmlElement)toastAfbeeldingElementen[0]).SetAttribute("src", "/Images/notification.png");
                    IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
                    ((XmlElement)toastNode).SetAttribute("duration", "long");
                    ToastNotification toast = new ToastNotification(toastXml);
                    ToastNotificationManager.CreateToastNotifier().Show(toast);

                    frameLogIn.Navigate(typeof(StartschermAnoniem));
                }
                else
                {
                    if (igGNaam != null)
                    {
                        foutmelding.Text = "Er bestaat al een gebruiker met deze gebruikersnaam!";
                    }
                    else
                    {
                        foutmelding.Text = "Er bestaat al een gebruiker met dit emailadres!";
                    }

                    igGNaam = null;
                    igEmail = null;

                }
                
            }
            else
            {
                foutmelding.Text = "Vul alle gegevens correct in!";
            }
        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frameLogIn.Navigate(typeof(Aanmelden));
        }

        private void annuleer_Click(object sender, RoutedEventArgs e)
        {
            frameLogIn.Navigate(typeof(MainPage));
        }
    }
}
