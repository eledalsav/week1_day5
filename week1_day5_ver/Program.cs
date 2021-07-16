using System;
using System.Threading;

namespace week1_day5_ver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n*****Benvenuto a Tombola!*****\n");
            Console.ResetColor();
            int[] sceltanumeri = new int[15];
            int[] numestratti = new int[70];
            bool check = false;
            bool check2 = false;
            int difficoltà = 0;
            int vittoria = 0;
            char risposta;

            do
            {
                FunzScelta(sceltanumeri, check);//fa scegliere all'utente i numeri da inserire

                difficoltà = FunzSceltaDiff(check2, difficoltà);//fa scegliere all'utente la difficoltà

                FunzEstrazione(difficoltà, numestratti);//estrae i numeri

                FunzControllo(vittoria, sceltanumeri, numestratti);//controlla la corrispondenza con i numeri scelti dall'utente

                Console.WriteLine("\n\nVuoi giocare ancora? Scrivi s per continuare:");
                risposta = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");
                if (risposta != 's')
                {
                    Console.WriteLine("Arrivederci, alla prossima!");
                }
            }
            while (risposta == 's');


            

           


           
            












        }

        private static void FunzControllo(int w, int[] array3, int[] array4)
        {
            int[] array5 = new int[70];
            for (int i = 0; i < array4.Length; i++)
            {
                for (int j = 0; j < array3.Length; j++)
                {
                    if (array4[i] == array3[j])
                    {
                        array5[w] = array4[i];
                        w++;
                    }
                }
            }
            Array.Resize(ref array5, w);
            if (w == 2)
            {
                Console.WriteLine("Bravo! Hai fatto ambo :)");
            }else if (w == 3)
            {
                Console.WriteLine("Bravo! Hai fatto terna :)");
            }else if (w == 4)
            {
                Console.WriteLine("Bravo! Hai fatto quaterna :)");
            }else if (w == 5)
            {
                Console.WriteLine("Bravo! Hai fatto cinquina :)");
            }else if(w>5 && w < 15)
            {
                Console.WriteLine("Bravo! Hai fatto cinquina :)");
            }else if (w == 5)
            {
                Console.WriteLine("Bravissimo! Hai fatto tombola!!");
            }
            Console.WriteLine("Ecco i numeri vincenti...");
            Thread.Sleep(2000); 

            if (array5.Length == 0)
            {
                Console.WriteLine("nessuno :'(");
            }
            for (int i = 0; i < array5.Length; i++)
            {
                Console.Write($"{array5[i]}\t");
                
            }
            if(array5.Length<2)
            {
                Console.WriteLine("Mi dispiace hai perso!");
            }
        }

        private static int[] FunzEstrazione(int y, int[] array2)
        {
            int z=0;
            bool check3 = false;
            if (y == 1)
            {
                z = 70;
            }
            else if (y == 2)
            {
                z = 40;
            }
            else if (y == 3)
            {
                z = 20;
            }

            Array.Resize(ref array2, z);
            
            for (int i = 0; i < z; i++)
            {
                Random random = new Random();
                array2[i] = random.Next(1, 91);
                do
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (array2[i] == array2[j])
                        {
                            array2[i] = random.Next(1, 91);
                            check3 = true;
                        }
                        else
                        {
                            check3 = false;
                        }
                    }
                } while (check3 == true);
            }
           // for (int i = 0; i < array2.Length; i++)
           // {
           //     Console.WriteLine($"{array2[i]}");
           // }
            
            return array2;
        }

        private static int FunzSceltaDiff(bool b, int x)
        {
            Console.WriteLine("\n\nOra scegli la difficoltà inserendo il numero corrispondente:\n1.Facile\n2.Medio\n3.Difficile\n");
            b = int.TryParse(Console.ReadLine(), out x);
            while (b == false || x < 1 || x > 3)
            {
                Console.WriteLine("scelta non corretta, scegli un numero tra 1 e 3:");
                b = int.TryParse(Console.ReadLine(), out x);
            }
            Console.WriteLine($"Hai scelto {x}, continuiamo :)\n");
            return x;
        }

        private static void FunzScelta(int[] array, bool a)
        {
            Console.WriteLine("Inserisci 15 numeri:");
            for (int i = 0; i < array.Length; i++)
            {
                a = int.TryParse(Console.ReadLine(), out array[i]);
                while (a == false || array[i] < 1 || array[i] > 90)
                {
                    Console.WriteLine("Carattere non corretto, scegli un numero tra 1 e 90:");
                    a = int.TryParse(Console.ReadLine(), out array[i]);
                }
                for (int j = 0; j < i; j++)
                {
                    while (array[i] == array[j])
                    {
                        Console.WriteLine("Attenzione! numero già inserito! Inseriscine un altro:");
                        a = int.TryParse(Console.ReadLine(), out array[i]);
                        while (a == false || array[i] < 1 || array[i] > 90)
                        {
                            Console.WriteLine("Carattere non corretto, scegli un numero tra 1 e 90:");
                            a = int.TryParse(Console.ReadLine(), out array[i]);
                        }
                    }
                }
            }

            Console.WriteLine("\nHai scelto i seguenti numeri:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }
    }
}
