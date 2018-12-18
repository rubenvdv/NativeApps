using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace NativeApps2.ViewModel
{
    public class NotificatieViewModel
    {
        private string titel;
        private string bericht;
        public string Titel { get; set; }
        public string Bericht { get; set; }

        public NotificatieViewModel(string titel, string bericht)
        {
            ZendNotificatie(titel, bericht);
        }

        public void ZendNotificatie(string titel, string bericht)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList toastTekstElementen = toastXml.GetElementsByTagName("text");
            toastTekstElementen[0].AppendChild(toastXml.CreateTextNode(titel));
            toastTekstElementen[1].AppendChild(toastXml.CreateTextNode(bericht));
            XmlNodeList toastAfbeeldingElementen = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastAfbeeldingElementen[0]).SetAttribute("src", "/Images/notification.png");
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "short");
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
            Titel = titel;
            Bericht = bericht;
        }
    }
}
