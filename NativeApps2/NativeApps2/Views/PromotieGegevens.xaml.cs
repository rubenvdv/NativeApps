using NativeApps2.Domain;
using NativeApps2.Views;
using System;
using Windows.Data.Pdf;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NativeApps2.xaml_pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PromotieGegevens : Page
    {
        private Promotie _promotie;
        Services services;

        public PromotieGegevens()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Type check = ((App)Application.Current).huidigeGebruiker.GetType();
            if (check == typeof(Ondernemer))
            {
                VisualStateManager.GoToState(this, "zakelijk", false);

            }
            else
            {
                VisualStateManager.GoToState(this, "nietzakelijk", false);
            }

            services = new Services();
            _promotie = (Promotie)e.Parameter;
            promotieGrid.DataContext = _promotie;
            onderneming.DataContext = _promotie.Onderneming;
        }

        private void Onderneming_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            Onderneming o = sp.DataContext as Onderneming;
            framePromotieGegevens.Navigate(typeof(OndernemingGegevens), o);
        }

        private void MaakPdf_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //Leek mij wel leuk, maar blijkt een hel te zijn
            //Zo staat het in de readme van de package ...
            /*
            SelectPdf.PdfDocument doc = new SelectPdf.PdfDocument();

            SelectPdf.PdfFont font = doc.AddFont(SelectPdf.PdfStandardFont.Helvetica);
            font.Size = 20;

            SelectPdf.PdfTextElement text = new SelectPdf.PdfTextElement(50, 50, "Hello world!", font);
            page.Add(text);

            doc.Save("test.pdf");
            doc.Close();*/
        }

        private void wijzigPromotie_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            framePromotieGegevens.Navigate(typeof(WijzigPromotie), _promotie);
        }

        private async void verwijderPromotie_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await services.verwijderPromotie(_promotie);
            framePromotieGegevens.Navigate(typeof(OndernemerBeheer));
        }
    }
}
