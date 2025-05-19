using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var czytelnik = new Czytelnik("Janusz", "Nowak", 1)
                {
                    KsiazkiWypozyczone = null
                };
                BibliotekaSerwis bibliotekaSerwis = new BibliotekaSerwis();
                var wypozyczono= bibliotekaSerwis.WypozyczKsiazke(1, czytelnik);
                Console.WriteLine(wypozyczono? "Wypozyczono": "Nie wypozyczono");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            Console.ReadLine();
        }
    }
}
