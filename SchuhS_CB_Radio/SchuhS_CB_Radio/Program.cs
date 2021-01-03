using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchuhS_CB_Radio
{
    class Program
    {
        static List<CBRadio> CBRadioList;
        static List<string> NevekList;
        static Dictionary<string, int> HivasiAdatok;
        static void Main(string[] args)
        {
            Feladat2Beolvasas(); Console.WriteLine("\n-----------------------------------------\n");
            Feladat3BejegyzesekSzama(); Console.WriteLine("\n-----------------------------------------\n");
            Feladat44Hivas(); Console.WriteLine("\n-----------------------------------------\n");
            Feladat5NevKeres(); Console.WriteLine("\n-----------------------------------------\n");
            Feladat7CB2(); Console.WriteLine("\n-----------------------------------------\n");
            Feladat8Becenevek(); Console.WriteLine("\n-----------------------------------------\n");
            Feladat9MAxHivas(); Console.WriteLine("\n-----------------------------------------\n");
            Console.ReadKey();
        }

        private static void Feladat9MAxHivas()
        {
            Console.WriteLine("9.Feladat: Határozza meg a legtöbb adást indító sofőr nevét");
            int MaxHivas = int.MinValue;
            string MaxNev = "cica";
            foreach (var h in HivasiAdatok)
            {
                if(h.Value>MaxHivas)
                { 
                    MaxHivas = h.Value;
                    MaxNev = h.Key;
                }
            }
            Console.WriteLine("\tA legtöbb hívást inditó személy: {0}\n\thívásainak száma: {1}", MaxNev, MaxHivas);
        }

        private static void Feladat8Becenevek()
        {
            Console.WriteLine("8.Feladat: Határozza meg és írja ki a minta szerint a sofőrök számát a forrásállományban található becenevek alapján!");
            Console.WriteLine("\tSoforök száma: {0}", NevekList.Count);
        }

        private static void Feladat7CB2()
        {
            Console.WriteLine("7.Feladat: Készítsen szöveges állományt cb2.txt néven");
            var sw = new StreamWriter(@"cb2.txt", false, Encoding.UTF8);
            int db = 0;
            foreach (var c in CBRadioList)
            {
                //Console.WriteLine("\t{0};{1},{2}",c.AtszamolPercre,c.AdasDb,c.Nev);
                sw.WriteLine("{0};{1},{2}", c.AtszamolPercre, c.AdasDb, c.Nev);
                db++;
            }
            sw.Close();
            if (db == CBRadioList.Count) { Console.WriteLine("\tSikeres file-ba írás"); }
            else { Console.WriteLine("\tSajnos sikertelen"); }
        }

        private static void Feladat5NevKeres()
        {
            Console.WriteLine("5.Feladat: Kérje be a felhasználótól egy sofőr nevét, majd határozza meg a sofőr által indított hívások \n\tszámát a napló bejegyzéseibő");
            NevekList = new List<string>();
            foreach (var c in CBRadioList)
            {
                if(!NevekList.Contains(c.Nev))
                {
                    NevekList.Add(c.Nev);
                }
            }
            HivasiAdatok = new Dictionary<string, int>();
            foreach (var n in NevekList)
            {
                int HivasSzama = 0;
                foreach (var c in CBRadioList)
                {
                    if(n==c.Nev)
                    { HivasSzama += c.AdasDb; }
                }
                HivasiAdatok.Add(n, HivasSzama);
            }
            /*foreach (var h in HivasiAdatok)
            {
                Console.WriteLine("{0,-20} : {1}",h.Key, h.Value);
            }*/
            Console.Write("\tKérem adjon meg egy nevet: ");
            string KeresettNev = Console.ReadLine();
            int Szamlalo = 0;
            while (Szamlalo < CBRadioList.Count && KeresettNev.ToLower()!=CBRadioList[Szamlalo].Nev.ToLower())
            { Szamlalo++; }
            if (Szamlalo == CBRadioList.Count) { Console.WriteLine("\tSajnos nincs ilyen személy a listában"); }
            else { Console.WriteLine("\tA Keresett személy : {0} Hivásainak száma : {1}", KeresettNev,HivasiAdatok.ElementAt(Szamlalo).Value); }


           
        }

        private static void Feladat44Hivas()
        {
            Console.WriteLine("4.Feladat:  található-e a naplóban olyan bejegyzés, amely szerint a sofőr egy percen belül pontosan 4 adást indított");
            bool Volt4Hivas = false;
            foreach (var c in CBRadioList)
            {
                if(c.AdasDb==4)
                { Volt4Hivas = true; break; }
            }
            if (Volt4Hivas == true) { Console.WriteLine("\tVolt olyan eset"); }
            else { Console.WriteLine("\tNem volt ilyen eset"); }
        }

        private static void Feladat3BejegyzesekSzama()
        {
            Console.WriteLine("3.Feladat: hány bejegyzés található a forrásállományban");
            Console.WriteLine("\tBejegyzések száma: {0}", CBRadioList.Count);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("2.Feladat: beolvasás");
            CBRadioList = new List<CBRadio>();
            int dbBeolvas = 0;
            var sr = new StreamReader(@"cb.txt", Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                CBRadioList.Add(new CBRadio(sr.ReadLine()));
                dbBeolvas++;
            }
            sr.Close();
            if (dbBeolvas > 0) { Console.WriteLine("\tSikeres beolvasás, beolvasott sorok száma :{0}", dbBeolvas); }
            else { Console.WriteLine("\tSiketelen beolvasás."); }
        }
    }
}
