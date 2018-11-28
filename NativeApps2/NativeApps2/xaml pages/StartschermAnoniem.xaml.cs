using NativeApps2.Domain;
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
    public sealed partial class StartschermAnoniem : Page
    {
        public StartschermAnoniem()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Type check = ((App)Application.Current).huidigeGebruiker.GetType();

            if(check == typeof(Gebruiker))
            {
                VisualStateManager.GoToState(this, "anoniem", false);
            }
            else if(check == typeof(IngelogdeGebruiker))
            {
                VisualStateManager.GoToState(this, "aangemeld", false);
            }
            else
            {
                VisualStateManager.GoToState(this, "zakelijk", false);
            }


            frameRechts.Navigate(typeof(Overzicht));
        }
        //Eigen event-handlers
        private void Button_Click_1(object sender, RoutedEventArgs e) //Sluit/open pane (links scherm)
        {
            SplitViewAnoniem.IsPaneOpen = !SplitViewAnoniem.IsPaneOpen;
        }

        private void StackPanel_Tapped_1(object sender, TappedRoutedEventArgs e) //Home-scherm
        {
            frameRechts.Navigate(typeof(Overzicht));
            
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e) //Zoeken
        {
            frameRechts.Navigate(typeof(Zoeken));
        }

        private void StackPanel_Tapped_2(object sender, TappedRoutedEventArgs e) //Evenementen
        {
            frameRechts.Navigate(typeof(OverzichtEvenementen));
        }

        private void StackPanel_Tapped_3(object sender, TappedRoutedEventArgs e) //Geabboneerd
        {
            frameRechts.Navigate(typeof(OverzichtAbonnees));
        }

        private void StackPanel_Tapped_4(object sender, TappedRoutedEventArgs e) //Instellingen
        {
            frameRechts.Navigate(typeof(Instellingen));
        }

        private void StackPanel_Tapped_5(object sender, TappedRoutedEventArgs e) //Help
        {
            frameRechts.Navigate(typeof(help));
        }

        private void aanmelden_Tapped(object sender, TappedRoutedEventArgs e)
        {
            volledigscherm.Navigate(typeof(Login));
        }

        private void maakOnderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameRechts.Navigate(typeof(OndernemingAanmaken));
        }
    }
}
