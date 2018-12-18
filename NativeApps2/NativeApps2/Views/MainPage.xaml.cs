using NativeApps2.Domain;
using NativeApps2.ViewModel;
using NativeApps2.xaml_pages;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NativeApps2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).huidigeGebruiker = new Gebruiker();
            new NotificatieViewModel("Welkom", "U bent klaar om Gent te ontdekken!");
            mainFrame.Navigate(typeof(StartschermAnoniem));
        }

        private void Aanmelden_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Aanmelden));
        }

        private void Ondernemer_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(LoginZakelijk));
        }

        private void Registreren_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Login)); //Is dus eigenlijk de registreerpagina maar fout genoemd
        }
    }
}
