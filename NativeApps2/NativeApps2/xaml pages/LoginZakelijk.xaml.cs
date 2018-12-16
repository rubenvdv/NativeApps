﻿using NativeApps2.Domain;
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
    public sealed partial class LoginZakelijk : Page
    {
        Services services;

        public LoginZakelijk()
        {
            this.InitializeComponent();
        }

        private async void Registreer_Ondernemer(object sender, RoutedEventArgs e)
        {
            if (!naam.Text.Equals("") && !voorNaam.Text.Equals("") && !mail.Text.Equals("") && !gebruikersnaam.Text.Equals("") && !wachtwoord.Password.Equals("")
                && !naamOnderneming.Text.Equals("") && !categorieOnderneming.Text.Equals("") && !adresOnderneming.Text.Equals("") && !openingsurenOnderneming.Text.Equals(""))
            {

                IEnumerable<Gebruiker> gebruikers = await services.getOndernemers();

                Gebruiker o = gebruikers.FirstOrDefault(g => g.Gebruikersnaam.Equals(gebruikersnaam.Text));

                if (o == null)
                {
                    services = new Services();
                    Ondernemer ondernemer = new Ondernemer(naam.Text, voorNaam.Text, gebruikersnaam.Text, wachtwoord.Password, mail.Text);
                    await services.registreerOndernemer(ondernemer);
                    ((App)Application.Current).huidigeGebruiker = ondernemer;

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

                    frameZakelijk.Navigate(typeof(StartschermAnoniem));
                }
                else
                {
                    foutmelding.Text = "Er bestaat al een ondernemer met deze gebruikersnaam!";
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
    }
}
