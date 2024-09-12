using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SevenLoops
{
    static public class Solutions
    {
        static void Loops()
        {
            // ===============================================================
            // 1. LOOP #1
            // Skapa ett program som skriver ut talen 0-10 på skärmen.
            // Lös detta med en for-loop.

            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"Result: {i}");
            }

            // ===============================================================
            // 2.LOOP #2

            // Skapa ett program där användaren får mata in två tal.
            // Låt sedan programmet skriva ut alla tal som finns 'mellan'
            // dessa två tal på skärmen.
            // Lös detta med en for-loop.

            // Läser in två tal från användaren
            Console.Write("Ange det första talet: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Ange det andra talet: ");
            int num2 = int.Parse(Console.ReadLine());

            // Se till att börja från det minsta talet och gå uppåt
            int start = Math.Min(num1, num2);
            int end = Math.Max(num1, num2);

            // Skriver ut alla tal mellan de två talen (exklusive start och end)
            for (int i = start + 1; i < end; i++)
            {
                Console.WriteLine(i);
            }

            // ===============================================================
            // 3.LOOP #3

            // Skapa ett program där användaren

            // a.Får mata in två tal.
            // b.Skriv sedan till skärmen summan av de två talen.
            // c.Skriv sedan en fråga - Vill du fortsätta(J/N)?
            // d.Svarar användaren J återupprepas punkt a-c
            // e.Svarar användaren N avbryts programmet

            string response;

            do
            {
                // Läser in två tal från användaren
                Console.Write("Ange det första talet: ");
                int num31 = int.Parse(Console.ReadLine());

                Console.Write("Ange det andra talet: ");
                int num32 = int.Parse(Console.ReadLine());

                // Beräknar och skriver ut summan
                int summa = num31 + num32;
                Console.WriteLine("Summan av de två talen är: " + summa);

                // Frågar om användaren vill fortsätta
                Console.Write("Vill du fortsätta (J/N)? ");
                response = Console.ReadLine().ToUpper(); // Gör svaret versalt för enkel kontroll

            } while (response == "J"); // Upprepar om användaren svarar "J"

            Console.WriteLine("Programmet avslutas.");

            // ===============================================================
            // 4.LOOP #4
            // Be användaren mata in ett tal.
            // Spara värdet i en variabel.
            // Upprepa detta 10 gånger.
            // För varje gång lägg till det inmatade värdet till variabelns värde.
            // När det är klart skriv ut-
            // Summan av det du matat in är: summan.

            int sum = 0;

            // Upprepa 10 gånger
            for (int i = 1; i <= 10; i++)
            {
                // Be användaren mata in ett tal
                Console.Write($"Ange tal {i}: ");
                int inputNumber = int.Parse(Console.ReadLine());

                // Lägg till det inmatade värdet till summan
                sum += inputNumber;
            }

            // Skriv ut summan av alla inmatade tal
            Console.WriteLine($"Summan av det du matat in är: {sum}");

            // ===============================================================
            // 5.LOOP #5
            // Skapa ett program där användaren får mata in ett tal.
            // Låt sedan programmet skriva ut alla siffor som är mindre än det
            // inmatade talet men större än 0.
            // Lös detta med en for loop.

            Console.Write("Ange ett tal: ");
            int number = int.Parse(Console.ReadLine());

            // Skriver ut alla siffror mindre än det inmatade talet och större än 0
            for (int i = 1; i < number; i++)
            {
                Console.WriteLine(i);
            }

            // ===============================================================
            // 6a.LOOP #6 - Tre rullande variabler
            // Skriv en loop som matar in värden(temperatur)

            // Om medelvärdet av sista tre > 25 så skriv ut ”Alarm”

            // a. lös detta med hjälp av tre rullande tre variabler
            // b. int senaste, int nästsenaste, int tidigaste
            // c. lös med lista istället (alla lagras i lista, räkna på tre sista)

            // Här sparas varje ny temperatur i den senaste variabeln och de
            // äldre temperaturerna flyttas ner i kedjan.
            // Medelvärdet av de tre senaste beräknas och om det är större än 25
            // skrivs "Alarm" ut.

            int latest = 0, secondLatest = 0, earliest = 0;
            while (true)
            {
                // Be användaren att mata in en temperatur
                Console.Write("Ange temperatur: ");
                Console.Write("Ange e för Exit! ");

                string temperatureStr = Console.ReadLine();
                if (temperatureStr == "e")
                    break;
                else
                {
                    int temperature = int.Parse(temperatureStr);

                    // Uppdatera de tre rullande variablerna
                    earliest = secondLatest;
                    secondLatest = latest;
                    latest = temperature;

                    // Kontrollera om medelvärdet av de tre senaste är > 25
                    if ((latest + secondLatest + earliest) / 3.0 > 25)
                    {
                        Console.WriteLine("Alarm");
                    }
                }
            }


            // ===============================================================
            // 6b.LOOP #6 - En lista
            // Skriv en loop som matar in värden(temperatur)

            // Om medelvärdet av sista tre > 25 så skriv ut ”Alarm”

            // a. lös detta med hjälp av tre rullande tre variabler
            // b. int senaste, int nästsenaste, int tidigaste
            // c. lös med lista istället (alla lagras i lista, räkna på tre sista)

            // I denna lösning använder vi en lista för att spara alla
            // temperaturvärden och beräknar medelvärdet av de tre senaste genom
            // att kolla på de sista tre elementen i listan.

            // Båda lösningarna uppfyller kraven, men listversionen är mer
            // flexibel om du vill utöka eller ändra antal temperaturer som
            // ska lagras och analyseras.

            List<int> temperatures = new List<int>();

            while (true)
            {
                // Be användaren att mata in en temperatur
                Console.Write("Ange temperatur: ");
                Console.Write("Ange e för Exit! ");

                string temperatureStr = Console.ReadLine();
                if (temperatureStr == "e")
                    break;
                else
                {
                    int temperature = int.Parse(temperatureStr);

                    // Lägg till temperaturen i listan
                    temperatures.Add(temperature);

                    // Kontrollera om vi har minst tre värden i listan
                    if (temperatures.Count >= 3)
                    {
                        // Räkna ut medelvärdet av de tre sista värdena
                        int count = temperatures.Count;
                        double average = (temperatures[count - 1] + temperatures[count - 2] + temperatures[count - 3]) / 3.0;

                        // Om medelvärdet är > 25, skriv ut "Alarm"
                        if (average > 25)
                        {
                            Console.WriteLine("Alarm");
                        }
                    }
                }
            }

            // ===============================================================
            // 7.LOOP #7

            Random random = new Random();
            string answer;

            do
            {
                // Kasta två tärningar
                int dice1 = random.Next(1, 7); // Slumpmässigt tal mellan 1 och 6
                int dice2 = random.Next(1, 7); // Slumpmässigt tal mellan 1 och 6

                // Visa resultatet
                Console.WriteLine($"Du kastade {dice1} och {dice2}.");

                // Fråga om användaren vill kasta igen
                Console.Write("Vill du kasta igen (j/n)? ");
                answer = Console.ReadLine().ToLower(); // Gör svaret till små bokstäver för enkel kontroll

            } while (answer == "j" || answer == "ja");

            Console.WriteLine("Spelet avslutas.");
        }
    }
}
