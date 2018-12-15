using NativeApps2.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
        public string abonnementName = "Geabonneerd";
        public string AbonnementName { get { return abonnementName; } }
        public Overzicht()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            this.DataContext = ((App)Application.Current).huidigeGebruiker;
            
            Type check = ((App)Application.Current).huidigeGebruiker.GetType();
            if (check == typeof(Gebruiker))
            {
                VisualStateManager.GoToState(this, "anoniem", false);
                
            }
            else if (check == typeof(IngelogdeGebruiker))
            {
                VisualStateManager.GoToState(this, "aangemeld", false);
                abonnementName = "Verander";
            }
            else
            {
                VisualStateManager.GoToState(this, "zakelijk", false);
            }

            services = new Services();
            ondernemingen = await services.getOndernemingen();
            myLV.ItemsSource = ondernemingen;

        }



        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Onderneming o = sp.DataContext as Onderneming;
            //OndernemingGegevens og = new OndernemingGegevens(o);
            frameOverzicht.Navigate(typeof(OndernemingGegevens), o);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tekstbox = sender as TextBox;
            List<Onderneming> filterLijst = new List<Onderneming>();
            if(radiobtnNaam.IsChecked == true)
            {
                filterLijst = ondernemingen.Where(o => o.Naam.IndexOf(tekstbox.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            } else if(radiobtnCategorie.IsChecked == true)
            {
                filterLijst = ondernemingen.Where(o => o.Categorie.IndexOf(tekstbox.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            } else if (radiobtnAdres.IsChecked == true)
            {
                filterLijst = ondernemingen.Where(o => o.Adres.IndexOf(tekstbox.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            } else if(radiobtnOpeningsuren.IsChecked == true)
            {
                filterLijst = ondernemingen.Where(o => o.Openingsuren.IndexOf(tekstbox.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            myLV.ItemsSource = filterLijst;
        }

        private void KeerTerug_Click(object sender, RoutedEventArgs e)
        {
            /*
            NavigationService ns = this.NavigationService;
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            */
        }


    }
}
