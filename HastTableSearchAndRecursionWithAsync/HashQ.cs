using System;

namespace HastTableSearchAndRecursionWithAsync
{
    class Program
    {
        public static string[] check =
    {
            "Nomlanga Dorsey",
            "Nomlanga Gentry",
            "Damian Hays",
             "Olga Fisher",
             "Kermit Valentine",
             "Ulla Foreman",
                "Jelani Rasmussen",
                "Zena Thompson",
                "Cruz Santana",
                "Doris Browning",
                "Christopher Barlow",
                "Nell Bishop",
                "Elmo Gentry",
                "Alec Mercer",
                "Sage Fisher",
                "Katell Norris",
                "Olga Cabrera",
                "Hakeem Craft",
                "Abraham Elliott",
                "Brenna Rosa",
                "Adria Bishop",
                "Nomlanga Walsh",
                "Philip Baxter",
                "Philip Tanner",
                "Nora Finch"
        };

        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            int surasta = 0;
            int operacijos = 0;
            long laikas = 0; ;
            for (int i = 1; i <= 10; i++)
            {
                int size = 520 * i;

                HashTableQ hash = new HashTableQ(size);

                Data data = new Data();
                data.generate(size, ref hash);

                for (int k = 0; k < check.Length; k++)
                {
                    string[] arr = check[k].Split(' ');
                    watch.Start();
                    hash.Find(arr[0], arr[1]);
                    watch.Stop();

                    laikas += watch.ElapsedMilliseconds;
                    if (hash.Find(arr[0], arr[1])) { surasta++; }
                    operacijos += hash.FindCount(arr[0], arr[1]);
                }
                //Console.WriteLine("Vidutinis paieskos laikas --> {0,10}, Surasnta reiksmiu --> {1}, Atlikta Operaciju --> {2} --> imtis {3}", laikas / check.Length, surasta, operacijos/check.Length,size);
                Console.WriteLine("{0}  {1}  {2}  {3}", laikas / check.Length, surasta, operacijos / check.Length, size);
                surasta = 0;
                laikas = 0;
                operacijos = 0;

            }
            Console.ReadLine();
        }
    }
}
