using NativeApps2.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
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
            frameOverzicht.Navigate(typeof(OndernemingGegevens));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tekstbox = sender as TextBox;
            List<Onderneming> filterLijst = ondernemingen.Where(o => o.Naam.IndexOf(tekstbox.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            myLV.ItemsSource = filterLijst;
        }

        private async void abonneer_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Onderneming o = b.DataContext as Onderneming;
            IngelogdeGebruiker gebruiker = (IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker;

            if (b.Content.ToString() == "Geabonneerd")
            {
                gebruiker.VolgendeOndernemingen.Remove(o);
                await services.UpdateGebruiker(gebruiker);

                b.Content = "Abonneer";

            }
            else
            {
                gebruiker.VolgendeOndernemingen.Add(o);
                //await services.PutVolgen
                b.Content = "Geabonneerd";
            }
            
        }
    }
}
