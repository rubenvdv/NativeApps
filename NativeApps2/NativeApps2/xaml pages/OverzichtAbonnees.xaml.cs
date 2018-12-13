﻿using NativeApps2.Domain;
using Newtonsoft.Json;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OverzichtAbonnees : Page
    {

        Services services;
        public ObservableCollection<Onderneming> ondernemingen = new ObservableCollection<Onderneming>();

        public OverzichtAbonnees()
        {
            
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            services = new Services();
            IngelogdeGebruiker gebruiker = ((IngelogdeGebruiker)((App)Application.Current).huidigeGebruiker);
            ondernemingen = await services.getVolgendeOndernemingenVanGebruiker(gebruiker);
            lvAbonnees.ItemsSource = ondernemingen;
        }

        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Onderneming onderneming = sp.DataContext as Onderneming;
            frameOverzichtAbonnees.Navigate(typeof(OndernemingGegevens), onderneming);

        }
    }
}
