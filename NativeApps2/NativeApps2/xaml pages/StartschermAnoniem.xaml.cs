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
        //Eigen event-handlers
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SplitViewAnoniem.IsPaneOpen = !SplitViewAnoniem.IsPaneOpen;
        }

        private void StackPanel_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            frameAnoniem.Navigate(typeof(StartschermAnoniem));
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frameAnoniem.Navigate(typeof(StartschermAnoniem));
        }

        private void StackPanel_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            frameAnoniem.Navigate(typeof(StartschermAnoniem));
        }

        private void StackPanel_Tapped_3(object sender, TappedRoutedEventArgs e)
        {
            frameAnoniem.Navigate(typeof(StartschermAnoniem));
        }

        private void StackPanel_Tapped_4(object sender, TappedRoutedEventArgs e)
        {
            frameAnoniem.Navigate(typeof(StartschermAnoniem));
        }

        private void StackPanel_Tapped_5(object sender, TappedRoutedEventArgs e)
        {
            frameAnoniem.Navigate(typeof(help));
        }
    }
}
