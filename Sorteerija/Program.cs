using System;
using System.Collections.Generic;

namespace Sorteerija
{
    class Program
    {
        //public Tuple<string, int>
        static void Main(string[] args)
        {
            List<string> Output = new List<string>();

            Console.WriteLine("N");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Numbrite list");
            string Numbrid = Console.ReadLine();

            string[] NumbridVabamad = Numbrid.Split(" ");

            //Console.WriteLine(NumbridVabamad);

            var Variable = Rekursiivne(NumbridVabamad);
            string SorteerimataNumbrid = Variable.Item1;
            int VaikseimSorteeritudArv = Variable.Item2;
            Output.Add(Convert.ToString(VaikseimSorteeritudArv));

            do
            {
                Variable = Rekursiivne(SorteerimataNumbrid.Split(" "));
                SorteerimataNumbrid = Variable.Item1;
                VaikseimSorteeritudArv = Variable.Item2;

                Output.Add(Convert.ToString(VaikseimSorteeritudArv));
            } while (SorteerimataNumbrid.Length > 0);

            string[] str = Output.ToArray();
            string Tulemus = string.Join(" ", str);

            Console.WriteLine(Tulemus);
        }


        public static Tuple<string,int> Rekursiivne(string[] NumbridVabamad)
        {
            int VaikseimArvHetkel = 0;
            int EelmineVaikseimArv = 2147483647;

            foreach (var v in NumbridVabamad)
            {
                if (v != "")
                {
                    if (Convert.ToInt32(v) < EelmineVaikseimArv)
                    {
                        VaikseimArvHetkel = Convert.ToInt32(v);
                        EelmineVaikseimArv = Convert.ToInt32(v);
                    }
                }
            }

            //Console.WriteLine(VaikseimArvHetkel);

            List<string> Nimekiri = new List<string>();

            bool jubaleitud = false;

            foreach (var v in NumbridVabamad)
            {
                if (v != "")
                {
                    if (Convert.ToInt32(v) == VaikseimArvHetkel)
                    {
                        if (jubaleitud == true)
                        {
                            Nimekiri.Add(v);
                        }
                        jubaleitud = true;
                    }
                    else
                    {
                        Nimekiri.Add(v);
                    }
                }
            }

            string[] str = Nimekiri.ToArray();
            string Tulemus = string.Join(" ", str);

            //Console.WriteLine(Tulemus, VaikseimArvHetkel);

            var Valjund = Tuple.Create(Tulemus, VaikseimArvHetkel);

            return Valjund;
        }
    }
}
