﻿using NativeApps2.Domain;
using NativeApps2.ViewModel;
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
    public sealed partial class EvenementAanmaken : Page
    {
        Services services;
        private ObservableCollection<Onderneming> ondernemingen = new ObservableCollection<Onderneming>();

        public EvenementAanmaken()
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
            if (!naam.Text.Equals("") && !omschrijving.Text.Equals("") && begindatum.Date != null && cmbOndernemingen.SelectedItem != null && !(begindatum.Date.DateTime < DateTime.Today) && !(begindatum.Date.DateTime > einddatum.Date.DateTime))
            {
                IEnumerable<Evenement> evenementen = await services.getEvenementen();
                Evenement ev = evenementen.FirstOrDefault(eve => eve.Naam.Equals(naam.Text));

                if (ev == null)
                {
                    Onderneming onderneming = cmbOndernemingen.SelectedItem as Onderneming;

                    Evenement evenement = new Evenement { Naam = naam.Text, Omschrijving = omschrijving.Text, Begindatum = begindatum.Date.DateTime, Einddatum = einddatum.Date.DateTime, OndernemingID = onderneming.OndernemingID };
                    await services.voegEvenementToe(evenement);
                    new NotificatieViewModel("Evenementen", String.Format("Evenement {0} aangemaakt!", naam.Text));
                    frameEvenementAanmaken.Navigate(typeof(OverzichtEvenementen));
                }
                else
                {
                    foutmelding.Text = "Er bestaat al een evenement met deze naam!";
                }
                ev = null;
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
