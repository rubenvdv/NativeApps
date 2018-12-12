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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OverzichtEvenementen : Page
    {
        private Services services;
        private ObservableCollection<Onderneming> volgendeOndernemingen = new ObservableCollection<Onderneming>();
        private ObservableCollection<Evenement> lijstVanEvenementen = new ObservableCollection<Evenement>();

        public OverzichtEvenementen()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            services = new Services();
            IngelogdeGebruiker gebruiker = (IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker;
            //volgendeOndernemingen = await services.getVolgendeOndernemingenVanGebruiker(gebruiker);

            //Hier moeten enkel alle evenementen die de gebruiker volgt meegegeven worden maar dat bestaat nog niet.
            lijstVanEvenementen = await services.getEvenementen();
            lvEvenementen.ItemsSource = lijstVanEvenementen;
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
