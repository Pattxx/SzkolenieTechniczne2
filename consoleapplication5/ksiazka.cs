using System.Collections.Generic;

namespace ConsoleApplication5
{
    public class Ksiazka
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public int IloscStron { get; set; }
        public static List<string> Autorzy { get; set; }

        public enum StatusKsiazki
        {
            Zagubiono = 0,
            Aktywna = 1,
            Czytelnia = 2,
            Wypozyczona = 3,
        }

        public StatusKsiazki Status { get; set; }

        public void Wypozycz()
        {
            Status = StatusKsiazki.Wypozyczona;
        }
        public void Zwrot()
        {
            Status = StatusKsiazki.Aktywna;
        }

        public bool CzyAktywna() =>  Status == StatusKsiazki.Aktywna;
        
    }
}
