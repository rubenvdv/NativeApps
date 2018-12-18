using NativeApps2.Domain;
using NativeApps2.xaml_pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WijzigPromotie : Page
    {
        private Promotie _promotie;
        private Services services;

        public WijzigPromotie()
        {
            this.InitializeComponent();
            services = new Services();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _promotie = e.Parameter as Promotie;
            PromotieGegevens.DataContext = _promotie;
            begindatum.Date = _promotie.Begindatum.Date;
            einddatum.Date = _promotie.Einddatum.Date;
        }

        private async void WijzigenGegevensButton_Click(object sender, RoutedEventArgs e)
        {

            if (!naam.Text.Equals("") && !omschrijving.Text.Equals("") && !korting.Text.Equals("") && !(begindatum.Date.DateTime < DateTime.Today) && !(begindatum.Date.DateTime > einddatum.Date.DateTime))
            {
                IEnumerable<Promotie> promoties = await services.getPromoties();
                Promotie p = promoties.FirstOrDefault(pr => pr.Naam.Equals(naam.Text));

                if (p == null || _promotie.Naam == naam.Text)
                {
                    _promotie.Naam = naam.Text;
                    _promotie.Omschrijving = omschrijving.Text;
                    _promotie.Korting = korting.Text;
                    _promotie.Begindatum = begindatum.Date.DateTime;
                    _promotie.Einddatum = einddatum.Date.DateTime;
                    await services.UpdatePromotie(_promotie);

                    foutmelding.Text = "";
                    succesMessage.Text = "Promotie aangepast";
                }
                else
                {
                    succesMessage.Text = "";
                    foutmelding.Text = "Er bestaat al een promotie met deze naam!";
                }
                p = null;
            }
            else if (begindatum.Date.DateTime < DateTime.Today)
            {
                succesMessage.Text = "";
                foutmelding.Text = "De begindatum moet vandaag of later zijn!";
            }
            else if (begindatum.Date.DateTime > einddatum.Date.DateTime)
            {
                succesMessage.Text = "";
                foutmelding.Text = "De einddatum mag niet voor de begindatum liggen!";
            }
            else
            {
                succesMessage.Text = "";
                foutmelding.Text = "Promotie niet aangepast, controleer of u alle gegevens correct hebt ingevuld!!";
            }
        }

        private void annuleer_Click(object sender, RoutedEventArgs e)
        {
            frameInstellingen.Navigate(typeof(PromotieGegevens), _promotie);
        }
    }
}
