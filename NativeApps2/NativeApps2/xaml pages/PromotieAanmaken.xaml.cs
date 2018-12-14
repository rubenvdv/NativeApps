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
    public sealed partial class PromotieAanmaken : Page
    {
        Services services;
        private ObservableCollection<Onderneming> ondernemingen = new ObservableCollection<Onderneming>();

        public PromotieAanmaken()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            services = new Services();
            Ondernemer ondernemer = (Ondernemer)((App)Application.Current).huidigeGebruiker;
            ondernemingen = await services.getOndernemingenVanOndernemer(ondernemer);
            cmbOndernemingen.ItemsSource = ondernemingen;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Onderneming onderneming = cmbOndernemingen.SelectedItem as Onderneming;

            Promotie promotie = new Promotie(naam.Text, omschrijving.Text, begindatum.Date.DateTime, einddatum.Date.DateTime, onderneming.OndernemingID, korting.Text);
            await services.voegPromotieToe(promotie);


            framePromotieAanmaken.Navigate(typeof(OverzichtPromoties));

            //Notifications manier 1
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTekstElementen = toastXml.GetElementsByTagName("text");
            toastTekstElementen[0].AppendChild(toastXml.CreateTextNode("Promoties"));
            //toastTekstElementen[1].AppendChild(toastXml.CreateTextNode("Nieuwe promotie aangemaakt!"));
            toastTekstElementen[1].AppendChild(toastXml.CreateTextNode(String.Format("Promotie {0} aangemaakt!", naam.Text)));
            XmlNodeList toastAfbeeldingElementen = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastAfbeeldingElementen[0]).SetAttribute("src", "/Images/notification.png");
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);

            //Notifications manier 2
            /*
            var categorie = "Evenementen";
            var bericht = "Nieuw evenement!";
            var afbeelding = "/Images/notification.png";
            var altBericht = "Notification";
            var xml = $"<?xml version=\"1.0\"?><toast><visual><binding template=\"ToastImageAndText02\"><image id=\"1\" src=\"/Images/notification.png\" alt=\"Notification\"/><text id=\"1\">{categorie}</text><text id=\"2\">{bericht}</text></binding></visual></toast>";
            var toastXml = new XmlDocument();
            toastXml.LoadXml(xml);
            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier("Sample toast").Show(toast);
            */

            //Notifications manier 3: via internet
        }
    }
}
