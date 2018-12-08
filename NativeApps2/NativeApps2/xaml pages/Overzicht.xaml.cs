using NativeApps2.Domain;
using Newtonsoft.Json;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Overzicht : Page
    {
        private Services services;
        public ObservableCollection<Onderneming> ondernemingen = new ObservableCollection<Onderneming>();

        public Overzicht()
        {
            this.InitializeComponent();

            /* //Test-fase
             ondernemingen.Add(new Onderneming("Apple inc", "Technologie", "California", "Ma-Vrij 08u00-17u30", "apple.jpg"));
             ondernemingen.Add(new Onderneming("Ikea", "Meubels", "Sweden", "Ma-Vrij 08u00-17u30 zat-zon 08u-21u00", "ikea.png"));

             ondernemingen.Add(new Onderneming(((App)Application.Current).huidigeGebruiker.Naam, ((App)Application.Current).huidigeGebruiker.GetType().ToString(), "", "", "apple.jpg"));

             myLV.ItemsSource = ondernemingen;
             */
            //Lijst als datacontext (of itemsource) van listview
            /*
            myLV.ItemsSource = spelers;
            
            myLV.DataContext = ondernemingen;*/
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Test-fase
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
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ondernemings/"));
            ondernemingen = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);
            myLV.ItemsSource = ondernemingen;
        }



        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameOverzicht.Navigate(typeof(OndernemingGegevens));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tekstbox = sender as TextBox;
            List<Onderneming> filterLijst = ondernemingen.Where(o => o.Naam.IndexOf(tekstbox.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            myLV.ItemsSource = filterLijst;
        }

        private void abonneer_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Onderneming o = b.DataContext as Onderneming;
            IngelogdeGebruiker gebruiker = (IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker;

            if (b.Content.ToString() == "Geabonneerd")
            {
                gebruiker.VolgendeOndernemingen.Remove(o);

                b.Content = "Abonneer";

            }
            else
            {
                gebruiker.VolgendeOndernemingen.Add(o);
                b.Content = "Geabonneerd";
            }
        }
    }
}
