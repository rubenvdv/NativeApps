using NativeApps2.Domain;
using Windows.Data.Pdf;
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

        public PromotieGegevens()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

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
    }
}
