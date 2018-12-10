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
        private ObservableCollection<Evenement> lijstVanEvenementen = new ObservableCollection<Evenement>();

        public OverzichtEvenementen()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Test-fase
            IEnumerable<Onderneming> ondernemingen = ((IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker).VolgendeOndernemingen;
            /*Onderneming apple = new Onderneming("Apple inc", "Technologie", "California", "Ma-Vrij 08u00-17u30", "apple.jpg");
            ondernemingen.Add(apple);
            Onderneming ikea = new Onderneming("Ikea", "Meubels", "Sweden", "Ma-Vrij 08u00-17u30 zat-zon 08u-21u00", "ikea.png");
            ondernemingen.Add(ikea);
            lst.Add(new Evenement("Apple keynote", "Apple launching the new iPhone Xs", new DateTime(2018, 11, 1), new DateTime(2018, 11, 1), apple));
            lst.Add(new Evenement("Apple keynote", "Apple launching the new iPhone Xs max", new DateTime(2018, 11, 1), new DateTime(2018, 11, 1), apple));
            lst.Add(new Evenement("Ikea", "New Ikea brochure is launched today", new DateTime(2018, 1, 1), new DateTime(2018, 1, 1), ikea));
            
            foreach(Onderneming o in ondernemingen)
            {
                foreach(Evenement ev in o.Evenementen)
                {
                    lst.Add(ev);
                }
            }
            */

            /*
             HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:61012/api/ToDoLists"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<ToDoList>>(json);

            lv.ItemsSource = lst;
             */


            services = new Services();
            lijstVanEvenementen = await services.getEvenementen();
            lvEvenementen.ItemsSource = lijstVanEvenementen;
        }

        //VRAAG: moet hier geen onderneming meegegeven worden als parameter?
        //Een evenement heeft toch altijd een onderneming?
        internal void VoegEvenementToe(object selectedItem, string naam, string omschrijving, DateTime begindatum, DateTime einddatum)
        {
            Onderneming onderneming = (Onderneming)selectedItem;
            lijstVanEvenementen.Add(new Evenement(naam, omschrijving, begindatum, einddatum, onderneming));
            //Moet hier geen methode voorzien worden in services die een evenement in de databank bijsteekt?
        }

        private void Evenement_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameOverzichtEvenementen.Navigate(typeof(EvenementGegevens));

        }
    }
}
