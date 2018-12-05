using NativeApps2.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace NativeApps2
{
    class Services
    {
        //HashAlgProviderApp hashAlgorithm = new HashAlgProviderApp();

        //GET ALLE ONDERNEMINGEN
        public async Task<ObservableCollection<Onderneming>> getOndernemingen()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ondernemings/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json);
        }

        //GET ALLE EVENEMENTEN VAN EEN ONDERNEMING
        public async Task<ObservableCollection<Evenement>> getEvenementenVanOnderneming(string onderneming)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/evenements/"));
            return new ObservableCollection<Evenement>(JsonConvert.DeserializeObject<ObservableCollection<Evenement>>(json).Where(e => e.Onderneming.Naam == onderneming));
        }
        //Nog eens serieus goed nakijken want ik ben niet zeker dat deze werkt.

        //GET ALLE PROMOTIES VAN EEN ONDERNEMING
        public async Task<ObservableCollection<Promotie>> getPromotiesVanOnderneming(string onderneming)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/promoties/"));
            return new ObservableCollection<Promotie>(JsonConvert.DeserializeObject<ObservableCollection<Promotie>>(json).Where(p => p.Onderneming.Naam == onderneming));
        }
        //Nog eens serieus goed nakijken want ik ben niet zeker dat deze werkt.

        public async Task<Promotie> getPromotiesVanOnderneming2(string onderneming)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/promoties/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Promotie>>(json).First(p => p.OndernemingID == 5);
        }

        //GET ALLE ONDERNEMERS
        public async Task<ObservableCollection<Ondernemer>> getOndernemers()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ondernemers/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Ondernemer>>(json);
        }

        //GET ALLE GEBRUIKERS
        public async Task<ObservableCollection<IngelogdeGebruiker>> getIngelogdeGebruikers()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ingelogdeGebruikers/"));
            return JsonConvert.DeserializeObject<ObservableCollection<IngelogdeGebruiker>>(json);
        }

        //GET EEN INGELOGDEGEBRUIKER (MET GEBRUIKERSNAAM)
        public async Task<IngelogdeGebruiker> getIngelogdeGebruiker(string gebruikersNaam)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ingelogdeGebruikers/"));
            return JsonConvert.DeserializeObject<ObservableCollection<IngelogdeGebruiker>>(json).First(g => g.Gebruikersnaam == gebruikersNaam);
        }

        //GET EEN ONDERNEMER (MET GEBRUIKERSNAAM)
        public async Task<Ondernemer> getOndernemer(string gebruikersNaam)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ondernemers/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Ondernemer>>(json).First(o => o.Gebruikersnaam == gebruikersNaam);
        }

        /* Met deze code kan je in de client kijken of de gewone gebruiker of ondernemer succesvol is gecreëerd.
         if(res.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //Code bij true
            }
         */

        //REGISTREER GEWONE GEBRUIKER
        public async Task<HttpResponseMessage> registreerGewonegebruiker(Gebruiker gebruiker)
        {
            //gebruiker.Wachtwoord = hashAlgorithm.HashMsg(gebruiker.Wachtwoord);
            var gewoneGebruikerJson = JsonConvert.SerializeObject(gebruiker);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:57003/api/ingelogdeGebruikers/", new StringContent(gewoneGebruikerJson, System.Text.Encoding.UTF8,"application/json"));
            return res;
        }


        //REGISTREER ONDERNEMER
        public async Task<HttpResponseMessage> registreerOndernemer(Ondernemer ondernemer)
        {
            //ondernemer.Wachtwoord = hashAlgorithm.HashMsg(ondernemer.Wachtwoord);
            var gewoneGebruikerJson = JsonConvert.SerializeObject(ondernemer);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:57003/api/ondernemers/", new StringContent(gewoneGebruikerJson, System.Text.Encoding.UTF8, "application/json"));
            return res;
        }

    }
}
