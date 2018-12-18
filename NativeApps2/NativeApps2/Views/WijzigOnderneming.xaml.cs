using NativeApps2.Domain;
using NativeApps2.ViewModel;
using NativeApps2.xaml_pages;
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

namespace NativeApps2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WijzigOnderneming : Page
    {

        private Onderneming _onderneming;
        private Services services;

        public WijzigOnderneming()
        {
            this.InitializeComponent();
            services = new Services();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _onderneming = e.Parameter as Onderneming;
            OndernemingGegevens.DataContext = _onderneming;
            cmbCategorie.DataContext = new CategorieViewModel();
            cmbCategorie.SelectedItem = _onderneming.Categorie;
        }

        private async void WijzigenGegevensButton_Click(object sender, RoutedEventArgs e)
        {

            if (!naam.Text.Equals("") && !cmbCategorie.SelectedItem.ToString().Equals("") && !adres.Text.Equals("") && !openingsuren.Text.Equals(""))
            {
                IEnumerable<Onderneming> ondernemingen = await services.getOndernemingen();
                Onderneming o = ondernemingen.FirstOrDefault(on => on.Naam.Equals(naam.Text));

                if (o == null || _onderneming.Naam == naam.Text)
                {
                    _onderneming.Naam = naam.Text;
                    _onderneming.Categorie = cmbCategorie.SelectedItem as string;
                    _onderneming.Adres = adres.Text;
                    _onderneming.Openingsuren = openingsuren.Text;

                    await services.UpdateOnderneming(_onderneming);

                    foutmelding.Text = "";
                    succesMessage.Text = "Onderneming aangepast";
                }
                else
                {
                    succesMessage.Text = "";
                    foutmelding.Text = "Er bestaat al een onderneming met deze naam!";
                }
                o = null;
            }
            else
            {
                succesMessage.Text = "";
                foutmelding.Text = "Onderneming niet aangepast, controleer of u alle gegevens correct hebt ingevuld!!";
            }
        }

        private void annuleer_Click(object sender, RoutedEventArgs e)
        {
            frameInstellingen.Navigate(typeof(OndernemingGegevens), _onderneming);
        }

    }
}
