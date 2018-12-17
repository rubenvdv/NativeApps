using NativeApps2.Domain;
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

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WijzigEvenement : Page
    {

        private Evenement _evenement;
        private Services services;

        public WijzigEvenement()
        {
            this.InitializeComponent();
            services = new Services();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _evenement = e.Parameter as Evenement;
            evenementGegevens.DataContext = _evenement;
            begindatum.Date = _evenement.Begindatum.Date;
            einddatum.Date = _evenement.Einddatum.Date;
        }

        private async void WijzigenGegevensButton_Click(object sender, RoutedEventArgs e)
        {

            if(!naam.Text.Equals("") && !omschrijving.Text.Equals("") && !(begindatum.Date.DateTime < DateTime.Today) && !(begindatum.Date.DateTime > einddatum.Date.DateTime))
            {
                IEnumerable<Evenement> evenementen = await services.getEvenementen();
                Evenement ev = evenementen.FirstOrDefault(eve => eve.Naam.Equals(naam.Text));

                if (ev == null || _evenement.Naam == naam.Text)
                {
                    _evenement.Naam = naam.Text;
                    _evenement.Omschrijving = omschrijving.Text;
                    _evenement.Begindatum = begindatum.Date.DateTime;
                    _evenement.Einddatum = einddatum.Date.DateTime;
                    await services.UpdateEvenement(_evenement);

                    foutmelding.Text = "";
                    succesMessage.Text = "Evenement aangepast";
                }
                else
                {
                    succesMessage.Text = "";
                    foutmelding.Text = "Er bestaat al een evenement met deze naam!";
                }
                ev = null;
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
                foutmelding.Text = "Evenement niet aangepast, controleer of u alle gegevens correct hebt ingevuld!!";
            }            
        }
    }
}
