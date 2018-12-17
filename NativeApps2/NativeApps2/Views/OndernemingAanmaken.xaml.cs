using NativeApps2.Domain;
using NativeApps2.ViewModel;
using Newtonsoft.Json;
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
    public sealed partial class OndernemingAanmaken : Page
    {

        Services services;

        public OndernemingAanmaken()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            cmbCategorie.DataContext = new CategorieViewModel();
            services = new Services();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!naam.Text.Equals("") && !cmbCategorie.SelectedItem.ToString().Equals("") && !adres.Text.Equals("") && !openingsuren.Text.Equals(""))
            {
                IEnumerable<Onderneming> ondernemingen = await services.getOndernemingen();
                Onderneming o = ondernemingen.FirstOrDefault(on => on.Naam.Equals(naam.Text));

                if (o == null)
                {
                    Ondernemer ondernemer = (Ondernemer)((App)Application.Current).huidigeGebruiker;
                    int ondernemerId = ondernemer.OndernemerID;
                    Onderneming onderneming = new Onderneming { Naam = naam.Text, Categorie = cmbCategorie.SelectedItem as string, Adres = adres.Text, Openingsuren = openingsuren.Text, OndernemerID = ondernemerId };
                    await services.voegOndernemingToe(onderneming);


                    //Notificatie
                    ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText02;
                    XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
                    XmlNodeList toastTekstElementen = toastXml.GetElementsByTagName("text");
                    toastTekstElementen[0].AppendChild(toastXml.CreateTextNode("Ondernemingen"));
                    toastTekstElementen[1].AppendChild(toastXml.CreateTextNode(String.Format("Onderneming {0} toegevoegd!", naam.Text)));
                    XmlNodeList toastAfbeeldingElementen = toastXml.GetElementsByTagName("image");
                    ((XmlElement)toastAfbeeldingElementen[0]).SetAttribute("src", "/Images/notification.png");
                    IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
                    ((XmlElement)toastNode).SetAttribute("duration", "long");
                    ToastNotification toast = new ToastNotification(toastXml);
                    ToastNotificationManager.CreateToastNotifier().Show(toast);

                    frameOnderneming.Navigate(typeof(OndernemerBeheer));
                }
                else
                {
                    foutmelding.Text = "Er bestaat al een onderneming met deze naam!";
                }
                o = null;
            }
            else
            {
                foutmelding.Text = "Vul alle gegevens correct in!";
            }
        }
    }
}
