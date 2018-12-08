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
    public sealed partial class PromotieGegevens : Page
    {
        public PromotieGegevens()
        {
            //Test-fase
            this.InitializeComponent();
            //Onderneming ikea = new Onderneming("Ikea", "Meubels", "Sweden", "Ma-Vrij 08u00-17u30 zat-zon 08u-21u00", "ikea.png");
            //Promotie promotie = new Promotie("Black Friday", "Kortingen tot 70 procent", new DateTime(2018, 1, 1), new DateTime(2018, 1, 1), ikea, "70% korting");
            //promotieNaam.DataContext = promotie;
            //promotieGrid.DataContext = promotie;
            //eigenaar.DataContext = ikea;
        }

        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            framePromotieGegevens.Navigate(typeof(OndernemingGegevens));
        }
    }
}
