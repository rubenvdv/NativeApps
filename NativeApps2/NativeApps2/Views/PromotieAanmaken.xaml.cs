using NativeApps2.Domain;
using NativeApps2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if ((!naam.Text.Equals("") && !omschrijving.Text.Equals("") && begindatum.Date != null && cmbOndernemingen.SelectedItem != null && !korting.Text.Equals("")) && !(begindatum.Date.DateTime < DateTime.Today) && !(begindatum.Date.DateTime > einddatum.Date.DateTime))
            {

                IEnumerable<Promotie> promoties = await services.getPromoties();
                Promotie p = promoties.FirstOrDefault(pr => pr.Naam.Equals(naam.Text));

                if (p == null)
                {
                    Onderneming onderneming = cmbOndernemingen.SelectedItem as Onderneming;

                    Promotie promotie = new Promotie { Naam = naam.Text, Omschrijving = omschrijving.Text, Begindatum = begindatum.Date.DateTime, Einddatum = einddatum.Date.DateTime, OndernemingID = onderneming.OndernemingID, Korting = korting.Text };
                    await services.voegPromotieToe(promotie);

                    new NotificatieViewModel("Promoties", String.Format("Promotie {0} aangemaakt!", naam.Text));
                    framePromotieAanmaken.Navigate(typeof(OverzichtPromoties));
                }
                else
                {
                    foutmelding.Text = "Er bestaat al een promotie met deze naam!";
                }
                p = null;
            }
            else if (begindatum.Date.DateTime < DateTime.Today)
            {
                foutmelding.Text = "De begindatum moet vandaag of later zijn!";
            }
            else if (begindatum.Date.DateTime > einddatum.Date.DateTime)
            {
                foutmelding.Text = "De einddatum mag niet voor de begindatum liggen!";
            }
            else
            {
                foutmelding.Text = "Vul alle gegevens correct in!";
            }
        }
    }
}
