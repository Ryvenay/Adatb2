using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Models.Records
{
    class Gitar
    {
        private string sorozatszam;

        public string Sorozatzam
        {
            get { return sorozatszam; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentException("A sorozatszám nem lehet üres!");
                }
                sorozatszam = value;
            }
        }

        private string tipus;

        public string Tipus
        {
            get { return tipus; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("A típus nem lehet üres!");
                }
                tipus = value;
            }
        }

        private string gyarto;

        public string Gyarto
        {
            get { return gyarto; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentException("A gyártó nem lehet üres!");
                }
                gyarto = value; 
            }
        }

        private DateTime gyartasDatum;

        public DateTime GyartasDatum
        {
            get { return gyartasDatum; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("A gyártás dátuma nem lehet üres!");
                }
                gyartasDatum = value;
            }
        }


        private bool balkezes;

        public bool Balkezes
        {
            get { return balkezes; }
            set
            {
                balkezes = value; 
            }
        }

        private int erintokSzama;

        public int ErintokSzama
        {
            get { return erintokSzama; }
            set 
            {
                erintokSzama = value;
            }
        }



    }
}
