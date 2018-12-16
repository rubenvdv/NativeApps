﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplashScreen : Page
    {
        DispatcherTimer dT = new DispatcherTimer();

        public SplashScreen()
        {
            InitializeComponent();
            splashScreen.Navigate(typeof(MainPage));
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            splashScreen.Navigate(typeof(MainPage));
            dT.Stop();
        }
    }
}
