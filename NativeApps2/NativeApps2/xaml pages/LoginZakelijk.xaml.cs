﻿using NativeApps2.Domain;
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

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginZakelijk : Page
    {
        public LoginZakelijk()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (naam.Text != "" && mail.Text != "" && gebruikersnaam.Text != "" && wachtwoord.Text != "")
            {
                ((App)Application.Current).huidigeGebruiker = new Ondernemer(naam.Text, gebruikersnaam.Text, wachtwoord.Text, mail.Text);
                frameZakelijk.Navigate(typeof(StartschermAnoniem));
            }
        }
    }
}
