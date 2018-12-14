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

        //GET ALLE ONDERNEMINGEN DIE EEN GEBRUIKER VOLGT
        public async Task<ObservableCollection<Onderneming>> getVolgendeOndernemingenVanGebruiker(IngelogdeGebruiker gebruiker)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ingelogdeGebruikers/"));
            var ingelogdeGebruiker = JsonConvert.DeserializeObject<ObservableCollection<IngelogdeGebruiker>>(json);
            //var user = ingelogdeGebruiker.FirstOrDefault(g => g.Equals(gebruiker));
            var user = ingelogdeGebruiker.FirstOrDefault(g => g.Gebruikersnaam.Equals(gebruiker.Gebruikersnaam));
            return user.VolgendeOndernemingen;
        }

        //GET ALLE EVENEMENTEN
        public async Task<ObservableCollection<Evenement>> getEvenementen()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/evenements/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Evenement>>(json);
        }

        public async Task<ObservableCollection<Evenement>> getEvenementenVanOnderneming(Onderneming onderneming)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/evenements/"));
            return new ObservableCollection<Evenement>(JsonConvert.DeserializeObject<ObservableCollection<Evenement>>(json).Where(e => e.OndernemingID.Equals(onderneming.OndernemingID)));
        }

        //GET ALLE ONDERNEMINGEN VAN EEN ONDERNEMER
        public async Task<ObservableCollection<Onderneming>> getOndernemingenVanOndernemer(Ondernemer ondernemer)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ondernemings/"));
            return new ObservableCollection<Onderneming>(JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json).Where(e => e.OndernemerID.Equals(ondernemer.OndernemerID)));
        }

        //GET ONDERNEMING ADHV ID
        public async Task<Onderneming> getOnderneming(int ondernemingID)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ondernemings/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Onderneming>>(json).First(o => o.OndernemingID.Equals(ondernemingID));
        }

        //GET ALLE PROMOTIES
        public async Task<ObservableCollection<Promotie>> getPromoties()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/promoties/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Promotie>>(json);
        }

        //GET ALLE PROMOTIES VAN EEN ONDERNEMING
        public async Task<ObservableCollection<Promotie>> getPromotiesVanOnderneming(Onderneming onderneming)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/promoties/"));
            return new ObservableCollection<Promotie>(JsonConvert.DeserializeObject<ObservableCollection<Promotie>>(json).Where(p => p.OndernemingID.Equals(onderneming.OndernemingID)));
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

        //GET ALLE INGELOGDEGEBRUIKERS
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

        //REGISTREER GEWONE GEBRUIKER
        public async Task<HttpResponseMessage> registreerGewonegebruiker(IngelogdeGebruiker gebruiker)
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
            var ondernemerJson = JsonConvert.SerializeObject(ondernemer);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:57003/api/ondernemers/", new StringContent(ondernemerJson, System.Text.Encoding.UTF8, "application/json"));
            return res;
        }

        //VOEG EVENEMENT TOE
        public async Task<HttpResponseMessage> voegEvenementToe(Evenement evenement)
        {
            var evenementJson = JsonConvert.SerializeObject(evenement);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:57003/api/evenements/", new StringContent(evenementJson, System.Text.Encoding.UTF8, "application/json"));
            return res;
        }

        //VOEG PROMOTIE TOE
        public async Task<HttpResponseMessage> voegPromotieToe(Promotie promotie)
        {
            var promotieJson = JsonConvert.SerializeObject(promotie);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:57003/api/promoties/", new StringContent(promotieJson, System.Text.Encoding.UTF8, "application/json"));
            return res;
        }

        //VOEG ONDERNEMING TOE
        public async Task<HttpResponseMessage> voegOndernemingToe(Onderneming onderneming)
        {
            var ondernemingJson = JsonConvert.SerializeObject(onderneming);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:57003/api/ondernemings/", new StringContent(ondernemingJson, System.Text.Encoding.UTF8, "application/json"));
            return res;
        }

        //(UPDATE GEBRUIKER)
        public async Task<HttpResponseMessage> UpdateGebruiker(Gebruiker gebruiker)
        {
            HttpClient client = new HttpClient();

            if (gebruiker.GetType() == typeof(IngelogdeGebruiker))
            {
                IngelogdeGebruiker ingelogdeGebruiker = (IngelogdeGebruiker)gebruiker;
                var gebruikerJson = JsonConvert.SerializeObject(ingelogdeGebruiker);
                var res = await client.PutAsync("http://localhost:57003/api/ingelogdeGebruikers/", new StringContent(gebruikerJson, System.Text.Encoding.UTF8, "application/json"));
                return res;
            }
            else
            {
                Ondernemer ondernemer = (Ondernemer)gebruiker;
                var gebruikerJson = JsonConvert.SerializeObject(ondernemer);
                var res = await client.PutAsync("http://localhost:57003/api/ondernemers/", new StringContent(gebruikerJson, System.Text.Encoding.UTF8, "application/json"));
                return res;
            }
        }

        /* Met deze code kan je in de client kijken of een object succesvol is gecreëerd in de db.
            if(res.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    //Code bij true
                }
        */

        //UPDATE VOLGENDE ONDERNEMINGEN (klopt niet)
        /* public async Task<HttpResponseMessage> VoegVolgendeOndernemingToe(IngelogdeGebruiker gebruiker, int ondernemingsId)
         {
             var gebruikerJson = JsonConvert.SerializeObject(onderneming met id ondernemingsId);
             HttpClient client = new HttpClient();
             var res = await client.PutAsync($"http://localhost:57003/IngelogdeGebruikers/VoegVolgendeOndernemingToe/{gebruiker.Gebruikersnaam}", new StringContent(gebruikerJson, System.Text.Encoding.UTF8, "application/json"));
             return res;
         }*/
    }
}
