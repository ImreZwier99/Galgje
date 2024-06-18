using System;
using System.Collections.Generic;

namespace game
{
    internal class galgje
    {
        public void Code()
        {
            List<string> woorden = new List<string>
            {
                "Tyrannosaurus", "Triceratops", "Velociraptor", "Stegosaurus", "Brachiosaurus",
                "Spinosaurus", "Allosaurus", "Ankylosaurus", "Diplodocus", "Iguanodon",
                "Pterodactyl", "Archaeopteryx", "Pachycephalosaurus", "Parasaurolophus", "Carnotaurus",
                "Gallimimus", "Deinonychus", "Gigantosaurus", "Megalosaurus", "Mosasaurus",

                "Plesiosaurus", "Quetzalcoatlus", "Sauropelta", "Therizinosaurus", "Troodon",
                "Albertosaurus", "Amargasaurus", "Anatotitan", "Apatosaurus", "Baryonyx",
                "Camarasaurus", "Carcharodontosaurus", "Centrosaurus", "Coelophysis", "Corythosaurus",
                "Cryolophosaurus", "Daspletosaurus", "Dilophosaurus", "Dracorex", "Edmontonia",

                "Edmontosaurus", "Einiosaurus", "Giganotosaurus", "Herrerasaurus", "Hesperosaurus",
                "Hypsilophodon", "Kentrosaurus", "Lesothosaurus", "Maiasaura", "Mamenchisaurus",
                "Monolophosaurus", "Nodosaurus", "Ornitholestes", "Ouranosaurus", "Pachyrhinosaurus",
                "Procompsognathus", "Psittacosaurus", "Saltasaurus", "Saurophaganax", "Scelidosaurus",

                "Segnosaurus", "Shantungosaurus", "Shunosaurus", "Sinoceratops", "Stygimoloch",
                "Supersaurus", "Torosaurus", "Utahraptor", "Yangchuanosaurus", "Yutyrannus",
                "Zalmoxes", "Zephyrosaurus", "Zuniceratops", "Cryodrakon", "Dromaeosaurus",
                "Eoraptor", "Fukuiraptor", "Gasosaurus", "Gorgosaurus", "Irritator",

                "Juravenator", "Kritosaurus", "Leptoceratops", "Lufengosaurus", "Microraptor",
                "Minmi", "Nanuqsaurus", "Oviraptor", "Pachysaurus", "Panoplosaurus",
                "Pelicanimimus", "Protoceratops", "Rajasaurus", "Rhabdodon", "Rugops",
                "Saurornithoides", "Struthiomimus", "Titanosaurus", "Torvosaurus", "Wuerhosaurus"
            };

            while (true)
            {
                Random random = new Random();
                string gekozenWoord = woorden[random.Next(woorden.Count)].ToLower();

                char[] geradenLetters = new string('_', gekozenWoord.Length).ToCharArray();
                List<char> foutGeradenLetters = new List<char>();
                List<char> geradenLettersList = new List<char>();
                int levens = 10;

                while (levens > 0 && new string(geradenLetters) != gekozenWoord)
                {
                    Console.Clear();
                    Console.WriteLine($"Woord: {new string(geradenLetters)}");
                    Console.WriteLine($"Levens: {levens}");
                    Console.WriteLine($"Fout geraden letters: {string.Join(", ", foutGeradenLetters)}");
                    Console.Write("Raad een letter: ");
                    string input = Console.ReadLine().ToLower();

                    if (input.Length == 1 && char.IsLetter(input[0]))
                    {
                        char gok = input[0];

                        if (!geradenLettersList.Contains(gok))
                        {
                            geradenLettersList.Add(gok);

                            if (gekozenWoord.Contains(gok))
                            {
                                for (int i = 0; i < gekozenWoord.Length; i++)
                                {
                                    if (gekozenWoord[i] == gok)
                                    {
                                        geradenLetters[i] = gok;
                                    }
                                }
                            }
                            else
                            {
                                foutGeradenLetters.Add(gok);
                                levens--;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Je hebt deze letter al geraden. Probeer een andere letter.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ongeldige invoer. Voer één letter in.");
                        Console.ReadKey();
                    }
                }

                Console.Clear();
                if (new string(geradenLetters) == gekozenWoord)
                {
                    Console.WriteLine($"Gefeliciteerd! Je hebt het woord geraden: {gekozenWoord}");
                }
                else
                {
                    Console.WriteLine($"Helaas, je hebt verloren. Het woord was: {gekozenWoord}");
                }

                Console.WriteLine("Wil je opnieuw spelen? (ja/nee)");
                string antwoord = Console.ReadLine().ToLower();
                if (antwoord == "nee")
                {
                    break;
                }
                else if (antwoord != "ja")
                {
                    Console.WriteLine("Ongeldige invoer");
                    Console.ReadKey();
                    continue;
                }
            }
        }
    }
}
