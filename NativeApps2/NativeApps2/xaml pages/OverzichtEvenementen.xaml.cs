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

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ObservableCollection<Evenement> lst = new ObservableCollection<Evenement>();
            lst.Add(new Evenement("Apple keynote", "Apple launching the new iPhone Xs", new DateTime(2018, 11, 1), new DateTime(2018, 11, 1)));
            lst.Add(new Evenement("Apple keynote", "Apple launching the new iPhone Xs max", new DateTime(2018, 11, 1), new DateTime(2018, 11, 1)));
            lst.Add(new Evenement("Ikea", "New Ikea brochure is launched today", new DateTime(2018, 1, 1), new DateTime(2018, 1, 1)));


            /*HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/evenements/"));
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Evenement>>(json);*/
            lvEvenementen.ItemsSource = lst;
        }
    }
}
