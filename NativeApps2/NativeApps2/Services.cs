using NativeApps2.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;

namespace NativeApps2
{
    class Services
    {
        //HashAlgProviderApp hashAlgorithm;
        //Hash hash;

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
            var user = ingelogdeGebruiker.FirstOrDefault(g => g.IngelogdeGebruikerID.Equals(gebruiker.IngelogdeGebruikerID));
            return user.VolgendeOndernemingen;
        }

        //GET ALLE EVENEMENTEN
        public async Task<ObservableCollection<Evenement>> getEvenementen()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/evenements/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Evenement>>(json);
        }

        //GET ALLE EVENEMENTEN VAN EEN ONDERNEMING
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

        //CONTROLEER INLOGGEGEVENS INGELOGDE GEBRUIKER
        internal async Task<bool> controleerInlogGegevensIngelogdeGebruiker(string userName, string password)
        {
            var passwordhash = HashPassword(password);
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ingelogdeGebruikers/"));
            return JsonConvert.DeserializeObject<ObservableCollection<IngelogdeGebruiker>>(json).First(g => g.Gebruikersnaam == userName).Wachtwoord.Equals(passwordhash);
        }

        //CONTROLEER INLOGGEGEVENS ONDERNEMER
        internal async Task<bool> controleerInlogGegevensOndernemer(string userName, string password)
        {
            var passwordhash = HashPassword(password);
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:57003/api/ondernemers/"));
            return JsonConvert.DeserializeObject<ObservableCollection<Ondernemer>>(json).First(o => o.Gebruikersnaam  == userName).Wachtwoord.Equals(passwordhash);
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
            gebruiker.Wachtwoord = HashPassword(gebruiker.Wachtwoord);
            var gewoneGebruikerJson = JsonConvert.SerializeObject(gebruiker);
            HttpClient client = new HttpClient();
            var res = await client.PostAsync("http://localhost:57003/api/ingelogdeGebruikers/", new StringContent(gewoneGebruikerJson, System.Text.Encoding.UTF8, "application/json"));
            return res;
        }

        //REGISTREER ONDERNEMER
        public async Task<HttpResponseMessage> registreerOndernemer(Ondernemer ondernemer)
        {
            ondernemer.Wachtwoord = HashPassword(ondernemer.Wachtwoord);
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

        //UPDATE GEBRUIKER GEGEVENS
        public async Task<HttpResponseMessage> UpdateGebruikerGegevens(Gebruiker gebruiker)
        {
            HttpClient client = new HttpClient();

            if (gebruiker.GetType() == typeof(IngelogdeGebruiker))
            {
                IngelogdeGebruiker ingelogdeGebruiker = (IngelogdeGebruiker)gebruiker;
                int gebruikersId = ingelogdeGebruiker.IngelogdeGebruikerID;
                var gebruikerJson = JsonConvert.SerializeObject(ingelogdeGebruiker);
                var res = await client.PutAsync($"http://localhost:57003/api/ingelogdeGebruikers/{gebruikersId}", new StringContent(gebruikerJson, System.Text.Encoding.UTF8, "application/json"));
                return res;
            }
            else
            {
                Ondernemer ondernemer = (Ondernemer)gebruiker;
                int gebruikersId = ondernemer.OndernemerID;
                var gebruikerJson = JsonConvert.SerializeObject(ondernemer);
                var res = await client.PutAsync($"http://localhost:57003/api/ondernemers/{gebruikersId}", new StringContent(gebruikerJson, System.Text.Encoding.UTF8, "application/json"));
                return res;
            }
        }

        //UPDATE GEBRUIKER PASSWORD
        public async Task<HttpResponseMessage> UpdateGebruikerPassword(Gebruiker gebruiker)
        {
            HttpClient client = new HttpClient();

            if (gebruiker.GetType() == typeof(IngelogdeGebruiker))
            {
                IngelogdeGebruiker ingelogdeGebruiker = (IngelogdeGebruiker)gebruiker;
                ingelogdeGebruiker.Wachtwoord = HashPassword(ingelogdeGebruiker.Wachtwoord);
                int gebruikersId = ingelogdeGebruiker.IngelogdeGebruikerID;
                var gebruikerJson = JsonConvert.SerializeObject(ingelogdeGebruiker);
                var res = await client.PutAsync($"http://localhost:57003/api/ingelogdeGebruikers/{gebruikersId}", new StringContent(gebruikerJson, System.Text.Encoding.UTF8, "application/json"));
                return res;
            }
            else
            {
                Ondernemer ondernemer = (Ondernemer)gebruiker;
                ondernemer.Wachtwoord = HashPassword(ondernemer.Wachtwoord);
                int gebruikersId = ondernemer.OndernemerID;
                var gebruikerJson = JsonConvert.SerializeObject(ondernemer);
                var res = await client.PutAsync($"http://localhost:57003/api/ondernemers/{gebruikersId}", new StringContent(gebruikerJson, System.Text.Encoding.UTF8, "application/json"));
                return res;
            }
        }

        public async Task<HttpResponseMessage> UpdateEvenement(Evenement evenement)
        {
            HttpClient client = new HttpClient();
            int evenementId = evenement.EvenementID;
            var evenementJson = JsonConvert.SerializeObject(evenement);
            var res = await client.PutAsync($"http://localhost:57003/api/evenements/{evenementId}", new StringContent(evenementJson, System.Text.Encoding.UTF8, "application/json"));
            return res;
        }

        /* Met deze code kan je in de client kijken of een object succesvol is gecreëerd in de db.
            if(res.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    //Code bij true
                }
        */

        //UPDATE VOLGENDE ONDERNEMINGEN (klopt niet)
         public async Task<HttpResponseMessage> VoegVolgendeOndernemingToe(IngelogdeGebruiker gebruiker, int ondernemingsid)
         {
             var gebruikerJson = JsonConvert.SerializeObject(ondernemingsid);
             HttpClient client = new HttpClient();
             var res = await client.PutAsync($"http://localhost:57003/IngelogdeGebruikers/VoegVolgendeOndernemingToe/{gebruiker.Gebruikersnaam}", new StringContent(gebruikerJson, System.Text.Encoding.UTF8, "application/json"));
             return res;
         }


        public string HashPassword(string passwd)
        {
            //if (hashAlgorithm == null)//(hash == null) 
            {
                //hash = new Hash();
                //hashAlgorithm = new HashAlgProviderApp();
            }
            //return hash.SampleDeriveFromPbkdf(passwd, 1000);
            return HashMsg(passwd);
        }

        public String HashMsg(String strMsg)
        {
            // Convert the message string to binary data.
            IBuffer buffUtf8Msg = CryptographicBuffer.ConvertStringToBinary(strMsg, BinaryStringEncoding.Utf8);

            // Create a HashAlgorithmProvider object.
            HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha512);

            // Demonstrate how to retrieve the name of the hashing algorithm.
            String strAlgNameUsed = objAlgProv.AlgorithmName;

            // Hash the message.
            IBuffer buffHash = objAlgProv.HashData(buffUtf8Msg);

            // Verify that the hash length equals the length specified for the algorithm.
            if (buffHash.Length != objAlgProv.HashLength)
            {
                throw new Exception("There was an error creating the hash");
            }

            // Convert the hash to a string (for display).
            String strHashBase64 = CryptographicBuffer.EncodeToBase64String(buffHash);

            // Return the encoded string
            return strHashBase64;
        }

        public string SampleDeriveFromPbkdf(
    String strAlgName,
    UInt32 targetSize)
        {
            // Open the specified algorithm.
            KeyDerivationAlgorithmProvider objKdfProv = KeyDerivationAlgorithmProvider.OpenAlgorithm(strAlgName);

            // Create a buffer that contains the secret used during derivation.
            String strSecret = "MyPassword";
            IBuffer buffSecret = CryptographicBuffer.ConvertStringToBinary(strSecret, BinaryStringEncoding.Utf8);

            // Create a random salt value.
            IBuffer buffSalt = CryptographicBuffer.GenerateRandom(32);

            // Specify the number of iterations to be used during derivation.
            UInt32 iterationCount = 10000;

            // Create the derivation parameters.
            KeyDerivationParameters pbkdf2Params = KeyDerivationParameters.BuildForPbkdf2(buffSalt, iterationCount);

            // Create a key from the secret value.
            CryptographicKey keyOriginal = objKdfProv.CreateKey(buffSecret);

            // Derive a key based on the original key and the derivation parameters.
            IBuffer keyDerived = CryptographicEngine.DeriveKeyMaterial(
                keyOriginal,
                pbkdf2Params,
                targetSize);

            // Encode the key to a hexadecimal value (for display)
            String strKeyHex = CryptographicBuffer.EncodeToHexString(keyDerived);

            // Return the encoded string
            return strKeyHex;
        }

    }
}
