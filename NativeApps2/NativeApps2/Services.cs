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

        //GET EEN INGELOGDEGEBRUIKER (MET EMAILADRES)
        public async Task<IngelogdeGebruiker> getIngelogdeGebruiker(string email)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ingelogdeGebruikers/"));
            return JsonConvert.DeserializeObject<ObservableCollection<IngelogdeGebruiker>>(json).First(g => g.Email == email);
        }

        //GET EEN ONDERNEMER (MET EMAILADRES)
        public async Task<IngelogdeGebruiker> getOndernemer(string email)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ondernemers/"));
            return JsonConvert.DeserializeObject<ObservableCollection<IngelogdeGebruiker>>(json).First(o => o.Email == email);
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
