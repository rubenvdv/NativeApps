using NativeApps2.Domain;
using NativeApps2.xaml_pages;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NativeApps2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).huidigeGebruiker = new Gebruiker();

            //Notificatie
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTekstElementen = toastXml.GetElementsByTagName("text");
            toastTekstElementen[0].AppendChild(toastXml.CreateTextNode("Welkom"));
            toastTekstElementen[1].AppendChild(toastXml.CreateTextNode("U bent klaar om Gent te ontdekken!"));
            XmlNodeList toastAfbeeldingElementen = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastAfbeeldingElementen[0]).SetAttribute("src", "/Images/notification.png");
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);

            mainFrame.Navigate(typeof(StartschermAnoniem));
        }

        private void Aanmelden_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Aanmelden));
        }

        private void Ondernemer_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(LoginZakelijk));
        }

        private void Registreren_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Login));
        }
    }
}
