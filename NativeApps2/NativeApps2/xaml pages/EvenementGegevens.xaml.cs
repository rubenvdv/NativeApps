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
    public sealed partial class EvenementGegevens : Page
    {
        ObservableCollection<Evenement> evenementen = new ObservableCollection<Evenement>();
        Services services;

        public EvenementGegevens()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            services = new Services();
            evenementen = await services.getEvenementen();
            //Hier moeten we nog weten over welk evenement het gaat en dit evenement uit de lijst van evenementen halen
            //evenementImage.DataContext = evenement;
            //evenementGrid.DataContext = evenement;
            //eigenaar.DataContext = onderneming;
        }

        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameEvenementGegevens.Navigate(typeof(OndernemingGegevens));

        }
    }
}
