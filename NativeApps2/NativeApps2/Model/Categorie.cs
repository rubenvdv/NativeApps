using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApps2.Model
{
    class Categorie
    {

        public List<string> Categorieën
        {
            get { return Categorieën; }
            set
            {
                new List<String> {
            "Bakker",
            "Slager",
            "Beenhouwer",
            "Café",
            "Restaurant",
            "Club",
            "Kledingwinkel",
            "Supermarkt",
            "Interieurwinkel",
            "Boekenwinkel",
            "Reisbureau",
            "Apotheek",
            "Koffiehuis",
            "Parfumerie",
            "Speelgoedwinkel",
            "Warenhuis",
            "Dierenwinkel",
            "Drogist",
            "Fietsenmaker",
            "InternetCafé",
            "Juwlier",
            "Kruidenier",
            "Seksshop",
            "Souvenirwinkel",
            "Strijkwinkel",
            "Tuincentrum",
            "Andere"
        };
            }
        }






        enum OndernemingCategorie
        {
            Bakker,
            Slager,
            Beenhouwer,
            Café,
            Restaurant,
            Club,
            Kledingwinkel,
            Supermarkt,
            Andere,
            Interieurwinkel,
            Boekenwinkel,
            Reisbureau,
            Apotheek,
            Koffiehuis,
            Parfumerie,
            Speelgoedwinkel,
            Warenhuis,
            Dierenwinkel,
            Drogist,
            Fietsenmaker,
            InternetCafé,
            Juwlier,
            Kruidenier,
            Seksshop,
            Souvenirwinkel,
            Strijkwinkel,
            Tuincentrum

        }
    }
}

