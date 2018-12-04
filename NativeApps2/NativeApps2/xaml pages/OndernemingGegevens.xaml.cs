using NativeApps2.Domain;
using System;
using System.Collections.Generic;
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

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OndernemingGegevens : Page
    {
        public OndernemingGegevens()
        {
            this.InitializeComponent();

            //Test-fase
            Onderneming ikea = new Onderneming("Ikea", "Meubels", "Sweden", "Ma-Vrij 08u00-17u30 zat-zon 08u-21u00", "ikea.png");
            List<Evenement> evenementen = new List<Evenement>();
            evenementen.Add(new Evenement("Ikea", "Nieuwe opening winkel te Gent", new DateTime(2018, 11, 1), new DateTime(2018, 11, 1), ikea));
            evenementen.Add(new Evenement("Ikea", "Grote solden tot wel 70 procent korting", new DateTime(2018, 11, 1), new DateTime(2018, 11, 1), ikea));
            evenementen.Add(new Evenement("Ikea", "New Ikea brochure is launched today", new DateTime(2018, 1, 1), new DateTime(2018, 1, 1), ikea));

            this.DataContext = ikea;
            lvOndernemingEvenementen.ItemsSource = evenementen;
        }

        private void Evenement_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameOndernemingGegevens.Navigate(typeof(EvenementGegevens));

        }
    }
}
