using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhS_CB_Radio
{
    class CBRadio
    {
        //Ora;Perc;AdasDb;Nev
        public int Ora;
        public int Perc;
        public int AdasDb;
        public string Nev;
        public DateTime Ido;

        public int AtszamolPercre
         {
            get 
            {
                int myAtszamolPercre = 0;
                myAtszamolPercre = Ora * 60 + Perc;
                return myAtszamolPercre;
            }
        }

        public CBRadio(string sor)
        {
            var dbok = sor.Split(';');
            this.Ora = int.Parse(dbok[0]);
            this.Perc = int.Parse(dbok[1]);
            this.AdasDb = int.Parse(dbok[2]);
            this.Nev = dbok[3];
            this.Ido = DateTime.Parse(dbok[0] + ':' + dbok[1]);
        }
    }
}
