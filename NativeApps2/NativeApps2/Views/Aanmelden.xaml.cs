﻿using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        Services services;
        public Aanmelden()
        {
            this.InitializeComponent();
        }

        private void aanmelden_Click(object sender, RoutedEventArgs e)
        {
            services = new Services();

            if(ondernemer.IsChecked == true)
            {
                meldOndernemerAan();
            }
            else
            {
                meldGebruikerAan();
            }
        }

        private void annuleer_Click(object sender, RoutedEventArgs e)
        {
            frameMeldAan.Navigate(typeof(MainPage));
        }

        private async void meldGebruikerAan()
        {
            bool correct = false;
            try
            {
                correct = await services.controleerInlogGegevensIngelogdeGebruiker(gebruikersnaam.Text, wachtwoord.Password);
            }
            catch (Exception)
            {
                foutmelding.Text = "Geen gebruiker met deze inlognaam gevonden";
            }
            if (!correct)
            {
                foutmelding.Text = "OPGELET: Onjuiste combinatie gebruikersnaam/wachtwoord";
            }
            if (correct)
            {

                ((App)Application.Current).huidigeGebruiker = await services.getIngelogdeGebruiker(gebruikersnaam.Text);

                frameMeldAan.Navigate(typeof(StartschermAnoniem));
            }
        }

        private async void meldOndernemerAan()
        {
            bool correct = false;
            try
            {
                correct = await services.controleerInlogGegevensOndernemer(gebruikersnaam.Text, wachtwoord.Password);
            }
            catch (Exception)
            {
                foutmelding.Text = "Geen ondernemer met deze inlognaam gevonden";
            }
            if (!correct)
            {
                foutmelding.Text = "OPGELET: Onjuiste combinatie gebruikersnaam/wachtwoord";
            }
            if (correct)
            {

                ((App)Application.Current).huidigeGebruiker = await services.getOndernemer(gebruikersnaam.Text);

                frameMeldAan.Navigate(typeof(StartschermAnoniem));
            }
        }
    }
}
