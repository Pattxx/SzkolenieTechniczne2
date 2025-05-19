using System.Collections.Generic;

namespace ConsoleApplication5
{
    public class Czytelnik
    {
        const int MAX_LICZBA_WYPOZYCZONYCH = 2;
        public Czytelnik(string imie, string nazwisko, int id)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Id = id;
            KsiazkiWypozyczone = new List<int>();
        }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Id { get; set; }
        public List<int> KsiazkiWypozyczone { get; set; }

        public bool Wypozycz(Ksiazka ksiazka)
        {
            if (ksiazka.CzyAktywna() && CzyMogeWypozyczyc())
            {
                KsiazkiWypozyczone.Add(ksiazka.Id);
                ksiazka.Wypozycz();
                return true;
            }
            return false;
        }

        public bool CzyMogeWypozyczyc()
        {
            return KsiazkiWypozyczone.Count < MAX_LICZBA_WYPOZYCZONYCH;
        }

    }
}
