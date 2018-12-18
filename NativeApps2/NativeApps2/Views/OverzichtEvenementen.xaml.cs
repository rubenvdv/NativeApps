using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;
using NativeApps2.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OverzichtEvenementen : Page
    {
        

        public OverzichtEvenementen()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            EvenementViewModel evenementViewModel = new EvenementViewModel();
            bericht.Text = await evenementViewModel.BepaalString();
            lvEvenementen.ItemsSource = evenementViewModel.Evenementen;
            
        }

        //VRAAG: moet hier geen onderneming meegegeven worden als parameter?
        //Een evenement heeft toch altijd een onderneming?
        /*internal void VoegEvenementToe(object selectedItem, string naam, string omschrijving, DateTime begindatum, DateTime einddatum)
        {
            Onderneming onderneming = (Onderneming)selectedItem;
            lijstVanEvenementen.Add(new Evenement(naam, omschrijving, begindatum, einddatum, onderneming));
            //Moet hier geen methode voorzien worden in services die een evenement in de databank bijsteekt?
        }*/

        private void Evenement_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Evenement evenement = sp.DataContext as Evenement;
            frameOverzichtEvenementen.Navigate(typeof(EvenementGegevens), evenement);

        }
    }
}
