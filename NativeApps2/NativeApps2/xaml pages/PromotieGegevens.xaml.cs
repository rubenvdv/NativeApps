using NativeApps2.Domain;
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

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PromotieGegevens : Page
    {
        Services services;
        ObservableCollection<Promotie> promoties = new ObservableCollection<Promotie>();

        public PromotieGegevens()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            services = new Services();
            promoties = await services.getPromoties();
            //Hier moeten we nog weten over welke promotie het gaat en deze promotie uit de lijst van promoties halen
            //promotieNaam.DataContext = promotie;
            //promotieGrid.DataContext = promotie;
            //eigenaar.DataContext = onderneming;
        }

        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            framePromotieGegevens.Navigate(typeof(OndernemingGegevens));
        }
    }
}
