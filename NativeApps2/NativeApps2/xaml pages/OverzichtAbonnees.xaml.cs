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
    public sealed partial class OverzichtAbonnees : Page
    {
        public OverzichtAbonnees()
        {
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Testfase
            ObservableCollection<Onderneming> lijstAbonnees = new ObservableCollection<Onderneming>();
            lijstAbonnees.Add(new Onderneming("Apple inc", "Technologie", "California", "Ma-Vrij 08u00-17u30"));
            lijstAbonnees.Add(new Onderneming("Ikea", "Meubels", "Sweden", "Ma-Vrij 08u00-17u30 zat-zon 08u-21u00"));

            /* Wordt zoiets met databank ->
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ondernemings/"));
            var lijstAbonnees = JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);
            */
            lvAbonnees.ItemsSource = lijstAbonnees;
        }
    }
}
