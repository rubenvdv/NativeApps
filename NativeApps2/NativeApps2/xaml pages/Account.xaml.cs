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
    public sealed partial class Account : Page
    {
        Services services;
        ObservableCollection<Onderneming> volgendeOndernemingen = new ObservableCollection<Onderneming>();

        public Account()
        {
            this.InitializeComponent();
            
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            IngelogdeGebruiker huidig = (IngelogdeGebruiker) ((App)Application.Current).huidigeGebruiker;
            naam.Text = huidig.Naam;
            voorNaam.Text = huidig.Voornaam;
            mail.Text = huidig.Email;
            gebruikersnaam.Text = huidig.Gebruikersnaam;

            services = new Services();
            volgendeOndernemingen = await services.getVolgendeOndernemingenVanGebruiker(huidig);
            lvAccountAbonnees.ItemsSource = volgendeOndernemingen;
        }

        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameAccount.Navigate(typeof(OndernemingGegevens));
        }
    }
}
