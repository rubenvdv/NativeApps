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
    public sealed partial class EvenementAanmaken : Page
    {
        public EvenementAanmaken()
        {
            this.InitializeComponent();
            //Dit nog implementeren
            //cmbOndernemingen.ItemsSource = typeof(Onderneming).GetHuidigeOndernemer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OverzichtEvenementen ozEv = new OverzichtEvenementen();
            //begindatum.SelectedDate werkt niet, waarom?
            ozEv.VoegEvenementToe(naam.Text, omschrijving.Text, new DateTime(), new DateTime());
            frameEvenementAanmaken.Navigate(typeof(OverzichtEvenementen));
        }
    }
}
