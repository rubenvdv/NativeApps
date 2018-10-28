using NativeApps2.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OverzichtEvenementen : Page
    {
        public OverzichtEvenementen()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Testfase
            ObservableCollection<Evenement> lijstEvenementen = new ObservableCollection<Evenement>();
            lijstEvenementen.Add(new Evenement("Launch event iPhone Xs/Xs Max", "Announcing the all new iPhone Xs and Xs Max", new DateTime(2018, 09, 30), new DateTime(2018, 09, 30)));
            lijstEvenementen.Add(new Evenement("Launch event iPhone Xs/Xs Max", "Announcing the all new iPhone Xs and Xs Max", new DateTime(2018, 09, 30), new DateTime(2018, 09, 30)));

            /* Wordt zoiets met databank ->
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:61012/api/ToDoLists/"));
            var lijstEvenementen = JsonConvert.DeserializeObject<ObservableCollection<Evenement>>(json);
            */
            lvEvenementen.ItemsSource = lijstEvenementen;
        }
    }
}
