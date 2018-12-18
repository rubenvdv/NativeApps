using NativeApps2.Domain;
using NativeApps2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class OverzichtPromoties : Page
    {
        
        public OverzichtPromoties()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            PromotieViewModel promotieViewModel = new PromotieViewModel();
            bericht.Text = await promotieViewModel.BepaalString();
            lvPromoties.ItemsSource = promotieViewModel.Promoties;
        }

        //VRAAG: moet hier geen onderneming meegegeven worden als parameter?
        //Een evenement heeft toch altijd een onderneming?
        /*internal void VoegPromotieToe(object selectedItem, string naam, string omschrijving, DateTime begindatum, DateTime einddatum, string korting)
        {
            Onderneming onderneming = (Onderneming)selectedItem;
            promoties.Add(new Promotie(naam, omschrijving, begindatum, einddatum, onderneming, korting));
        }*/

        private void Promotie_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Promotie promotie = sp.DataContext as Promotie;
            frameOverzichtPromoties.Navigate(typeof(PromotieGegevens), promotie);

        }
    }
}
