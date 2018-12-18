using NativeApps2.Domain;
using NativeApps2.xaml_pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

namespace NativeApps2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AlleEvenementen : Page
    {
        private Services services;
        private ObservableCollection<Evenement> lijstVanEvenementen = new ObservableCollection<Evenement>();

        public AlleEvenementen()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            services = new Services();

            bericht.Text = "Er worden voorlopig geen evenementen georganiseerd.";
            lijstVanEvenementen = await services.getEvenementen();
            lvEvenementen.ItemsSource = lijstVanEvenementen;
            if (lijstVanEvenementen.Count > 0)
            {
                bericht.Text = "";
            }
        }

        private void Evenement_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Evenement evenement = sp.DataContext as Evenement;
            frameOverzichtEvenementen.Navigate(typeof(EvenementGegevens), evenement);

        }
    }
}
