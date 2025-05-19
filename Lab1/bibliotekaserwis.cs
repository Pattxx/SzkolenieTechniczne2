using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication5
{
    public class BibliotekaSerwis
    {
        private static List<Ksiazka> Ksiazki = new List<Ksiazka>()
        {
            new Ksiazka() { Id = 1,Tytul = "Rzemieślnik oprogramowania", IloscStron = 500, Status = Ksiazka.StatusKsiazki.Aktywna},
            new Ksiazka() { Id = 2,Tytul = "Grafika w mediach", IloscStron = 670, Status = Ksiazka.StatusKsiazki.Aktywna},
            new Ksiazka() { Id = 3,Tytul = "PHP for lamers", IloscStron = 120, Status = Ksiazka.StatusKsiazki.Czytelnia},
            new Ksiazka() { Id = 4,Tytul = "Wzorce projektowe", IloscStron = 450},
        };

        private void WyslijInformacjeDoCzytelnika(string temat, string tresc, string emailDo, string emailFrom, FileStream zalacznik)
        {
            //logika wypozyczenia ksiazki
        }



        public bool WypozyczKsiazke(int idKsiazka, Czytelnik czytelnik)
        {

            if (Ksiazki.Any(x => x.Id == idKsiazka && x.CzyAktywna()))
            {

                var ksiazka = Ksiazki.First(x => x.Id == idKsiazka);

                if (czytelnik.Wypozycz(ksiazka))
                {
                    var temat = "Wypozyczono ksiązke";
                    var tresc = "wypozyczyles ksiazke tytul" + ksiazka.Tytul;
                    WyslijInformacjeDoCzytelnika(temat, tresc, "bb@wp.pl", "cc@wp.pl", null);
                    return true;
                }
                
            }
            return false;
        }
    }
}
