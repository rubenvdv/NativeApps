﻿using NativeApps2.Domain;
using System;
using System.Collections.Generic;
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
    public sealed partial class LoginZakelijk : Page
    {
        public LoginZakelijk()
        {
            this.InitializeComponent();
        }

        private void Registreer_Ondernemer(object sender, RoutedEventArgs e)
        {
            if (naam.Text != "" && voorNaam.Text !="" && mail.Text != "" && gebruikersnaam.Text != "" && wachtwoord.Text != "")
            {
                ((App)Application.Current).huidigeGebruiker = new Ondernemer(naam.Text, voorNaam.Text, gebruikersnaam.Text, wachtwoord.Text, mail.Text);

                //Notificatie
                ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText02;
                XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
                XmlNodeList toastTekstElementen = toastXml.GetElementsByTagName("text");
                toastTekstElementen[0].AppendChild(toastXml.CreateTextNode("Welkom"));
                toastTekstElementen[1].AppendChild(toastXml.CreateTextNode("U hebt zich succesvol geregistreerd!"));
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