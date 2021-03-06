﻿using NativeApps2.Domain;
using NativeApps2.Views;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartschermAnoniem : Page
    {
        public StartschermAnoniem()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = ((App)Application.Current).huidigeGebruiker;
            frameRechts.Navigate(typeof(Overzicht));

            Type check = ((App)Application.Current).huidigeGebruiker.GetType();
            if (check == typeof(Gebruiker))
            {
                VisualStateManager.GoToState(this, "anoniem", false);
               
            }
            else if(check == typeof(IngelogdeGebruiker))
            {
                VisualStateManager.GoToState(this, "aangemeld", false);
            }
            else
            {
                VisualStateManager.GoToState(this, "zakelijk", false);
                frameRechts.Navigate(typeof(OndernemerBeheer));
            }


            
        }
        //Eigen event-handlers
        private void Button_Click_1(object sender, RoutedEventArgs e) //Sluit/open pane (links scherm)
        {
            SplitViewAnoniem.IsPaneOpen = !SplitViewAnoniem.IsPaneOpen;
        }

        private void Overzicht_Tapped(object sender, TappedRoutedEventArgs e) //Home-scherm
        {
            frameRechts.Navigate(typeof(Overzicht));
            
        }

        private void Account_Tapped(object sender, TappedRoutedEventArgs e) //Account
        {
            frameRechts.Navigate(typeof(Account));

        }

        private void Evenementen_Tapped(object sender, TappedRoutedEventArgs e) //Evenementen
        {
            frameRechts.Navigate(typeof(OverzichtEvenementen));
        }

        private void Promoties_Tapped(object sender, TappedRoutedEventArgs e) //Evenementen
        {
            frameRechts.Navigate(typeof(OverzichtPromoties));
        }

        private void Abonnementen_Tapped(object sender, TappedRoutedEventArgs e) //Geabboneerd
        {
            frameRechts.Navigate(typeof(OverzichtAbonnees));
        }

        private void Instellingen_Tapped(object sender, TappedRoutedEventArgs e) //Instellingen
        {
            frameRechts.Navigate(typeof(Instellingen));
        }

        private void Help_Tapped(object sender, TappedRoutedEventArgs e) //Help
        {
            frameRechts.Navigate(typeof(help));
        }

        private void aanmelden_Tapped(object sender, TappedRoutedEventArgs e)
        {
            volledigscherm.Navigate(typeof(Login));
        }

        private void maakOnderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameRechts.Navigate(typeof(OndernemingAanmaken));
        }

        private void maakEvenement_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameRechts.Navigate(typeof(EvenementAanmaken));
        }
        private void maakPromotie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameRechts.Navigate(typeof(PromotieAanmaken));
        }

        private void MijnBeheer_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameRechts.Navigate(typeof(OndernemerBeheer));
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).huidigeGebruiker = null;
            volledigscherm.Navigate(typeof(MainPage));
        }

        private void AlleEvenementen_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameRechts.Navigate(typeof(AlleEvenementen));
        }

        private void AllePromoties_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameRechts.Navigate(typeof(AllePromoties));
        }
    }
}
