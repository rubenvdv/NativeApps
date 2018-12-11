using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Services services;

        public Aanmelden()
        {
            this.InitializeComponent();
        }

        private async void aanmelden_Click(object sender, RoutedEventArgs e)
        {
            //List<Gebruiker> bestaande = new List<Gebruiker>();
            services = new Services();
            ObservableCollection<IngelogdeGebruiker> bestaande = await services.getIngelogdeGebruikers();
            //bestaande.Add(new IngelogdeGebruiker("ruben", "", "ruben", "ruben", "ruben"));

            IngelogdeGebruiker gebruiker = bestaande.FirstOrDefault(g => g.Gebruikersnaam.Equals(gebruikersnaam.Text));
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

                ////Notificatie
                //ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText02;
                //XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
                //XmlNodeList toastTekstElementen = toastXml.GetElementsByTagName("text");
                //toastTekstElementen[0].AppendChild(toastXml.CreateTextNode("Account"));
                //toastTekstElementen[1].AppendChild(toastXml.CreateTextNode("U bent aangemeld!"));
                //XmlNodeList toastAfbeeldingElementen = toastXml.GetElementsByTagName("image");
                //((XmlElement)toastAfbeeldingElementen[0]).SetAttribute("src", "/Images/notification.png");
                //IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
                //((XmlElement)toastNode).SetAttribute("duration", "short");
                //ToastNotification toast = new ToastNotification(toastXml);
                //ToastNotificationManager.CreateToastNotifier().Show(toast);

                frameMeldAan.Navigate(typeof(StartschermAnoniem));
            }

        }
    }
}
