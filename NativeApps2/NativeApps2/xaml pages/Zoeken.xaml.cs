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
    public sealed partial class Zoeken : Page
    {
        ObservableCollection<Onderneming> lijstOndernemingen = new ObservableCollection<Onderneming>();
        public Zoeken()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

           /* //Testfase
            lijstOndernemingen.Add(new Onderneming("Apple inc", "Technologie", "California", "Ma-Vrij 08u00-17u30", "apple.jpg"));
            lijstOndernemingen.Add(new Onderneming("Ikea", "Meubels", "Sweden", "Ma-Vrij 08u00-17u30 zat-zon 08u-21u00", "ikea.png"));
            */
            /* Wordt zoiets met databank ->
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:61012/api/ToDoLists/"));
            var lijstAbonnees = JsonConvert.DeserializeObject<ObservableCollection<Evenement>>(json);
            */
            lvZoeken.ItemsSource = lijstOndernemingen;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tekstbox = sender as TextBox;
            List<Onderneming> filterLijst = lijstOndernemingen.Where(o => o.Naam.IndexOf(tekstbox.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            lvZoeken.ItemsSource = filterLijst;
        }
    }
}
