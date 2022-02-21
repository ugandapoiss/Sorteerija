using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Sorteerija
{
    class Program
    {
        //public Tuple<string, int>
        static void Main(string[] args)
        {
            //List<string> Output = new List<string>();
            string Output;

            Console.WriteLine("N");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Numbrite list või täpne .txt faili path");
            string Sisend = Console.ReadLine();

            string Numbrid;

            string Asukoht = Path.GetFullPath(Sisend);

            if (File.Exists(Asukoht) == true)
            {
                Numbrid = System.IO.File.ReadAllText(Sisend);
            }
            else
            {
                Numbrid = Sisend;
            }
            
            
            string[] NumbridVabamad = Numbrid.Split(" ");

            //Console.WriteLine(NumbridVabamad);

            var Variable = Rekursiivne(NumbridVabamad);
            string SorteerimataNumbrid = Variable.Item1;
            int VaikseimSorteeritudArv = Variable.Item2;
            //Output.Add(Convert.ToString(VaikseimSorteeritudArv));
            Output = Convert.ToString(VaikseimSorteeritudArv);

            do
            {
                Variable = Rekursiivne(SorteerimataNumbrid.Split(" "));
                SorteerimataNumbrid = Variable.Item1;
                VaikseimSorteeritudArv = Variable.Item2;

                //Output.Add(Convert.ToString(VaikseimSorteeritudArv));
                Output = Output + " " + Convert.ToString(VaikseimSorteeritudArv);
            } while (SorteerimataNumbrid.Length > 0);

            //string[] str = Output.ToArray();
            //string Tulemus = string.Join(" ", str);

            //Console.WriteLine(Tulemus)
            Console.WriteLine(Output);
            Console.WriteLine("Sorteeritud");
            Console.Read();
        }


        public static Tuple<string,int> Rekursiivne(string[] NumbridVabamad)
        {
            int VaikseimArvHetkel = 0;
            int EelmineVaikseimArv = 2147483647;
            string Nimekiri = "";
            bool jubaleitud = false;

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

            //List<string> Nimekiri = new List<string>();2

            foreach (var v in NumbridVabamad)
            {
                if (v != "")
                {
                    if (Convert.ToInt32(v) == VaikseimArvHetkel)
                    {
                        if (jubaleitud == true)
                        {
                            //Nimekiri.Add(v);
                            Nimekiri = Nimekiri + " " + v;
                        }
                        jubaleitud = true;
                    }
                    else
                    {
                        //Nimekiri.Add(v);
                        Nimekiri = Nimekiri + " " + v;
                    }
                }
            }

            //string[] str = Nimekiri.ToArray();
            //string Tulemus = string.Join(" ", str);

            //Console.WriteLine(Tulemus, VaikseimArvHetkel);

            string Tulemus = Nimekiri;

            var Valjund = Tuple.Create(Tulemus, VaikseimArvHetkel);

            return Valjund;
        }
    }
}
