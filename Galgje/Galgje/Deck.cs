using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Deck
    {
        private List<Kaart> kaarten = new List<Kaart>();
        private Random random = new Random();

        public Deck()
        {
            foreach (Type type in Enum.GetValues(typeof(Type)))
            {
                foreach (Waarde waarde in Enum.GetValues(typeof(Waarde)))
                {
                    kaarten.Add(new Kaart(waarde, type));
                }
            }
        }

        public Kaart TrekKaart()
        {
            int index = random.Next(kaarten.Count);
            Kaart getrokkenKaart = kaarten[index];
            kaarten.RemoveAt(index);
            return getrokkenKaart;
        }

        public int KaartenOver()
        {
            return kaarten.Count;
        }

        public void SpeelKaartspel()
        {
            Console.Write("Voer je naam in: ");
            string spelerNaam = Console.ReadLine();
            Kaart huidigeKaart = TrekKaart();
            int score = 0;

            while (KaartenOver() > 0)
            {
                Console.WriteLine($"Huidige kaart: {huidigeKaart}");
                Console.WriteLine($"Huidige score: {score}\n");
                Console.WriteLine("Hoger (H), Lager (L), of Kleur (K)? Druk ESC om te stoppen.");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Einde van het spel.");
                    break;
                }

                Kaart volgendeKaart = TrekKaart();

                if (keyInfo.Key == ConsoleKey.H)
                {
                    if (IsHoger(volgendeKaart, huidigeKaart))
                    {
                        score++;
                        Console.Clear();
                        Console.WriteLine($"Goed geraden! Je score is: {score}\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Fout geraden! Je score is: {score}\n");
                    }
                }
                else if (keyInfo.Key == ConsoleKey.L)
                {
                    if (IsLager(volgendeKaart, huidigeKaart))
                    {
                        score++;
                        Console.Clear();
                        Console.WriteLine($"Goed geraden! Je score is: {score}\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Fout geraden! Je score is: {score}\n");
                    }
                }
                else if (keyInfo.Key == ConsoleKey.K)
                {
                    Console.Write("Raad de kleur (Harten, Ruiten, Klaveren, Schoppen): ");
                    string gok = Console.ReadLine();
                    if (gok.Equals(volgendeKaart.Type.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        score++;
                        Console.Clear();
                        Console.WriteLine($"Goed geraden! Je score is: {score}\n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Fout geraden! Je score is: {score}\n");
                    }
                }
                huidigeKaart = volgendeKaart;
            }
            Console.Clear();
            Console.WriteLine($"{spelerNaam}, je eindscore is: {score}");
        }

        private bool IsHoger(Kaart volgende, Kaart huidige)
        {
            return volgende.Waarde >= huidige.Waarde;
        }

        private bool IsLager(Kaart volgende, Kaart huidige)
        {
            return volgende.Waarde <= huidige.Waarde;
        }
    }
}
