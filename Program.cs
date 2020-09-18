using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kiralyno
{
    class Tabla
    {
        char[,] T;//T="tömb"
        char UresCella;
        int UresOszlopokSzama;
        int UresSorokSzama;
        public Tabla(char ch)
        {
            T = new char[8, 8];
            UresCella = ch;
            for (int i = 0; i < 8; i++)
            {   
                for (int j = 0; j < 8; j++)
                {
                    T[i, j] = UresCella;
                }
            }
        }
        public void Elhelyez(int N)
        {
            //1. Véletlen helyérték létrehozása
            //Random osztály értékek halmaza [0,7]
            //véletlen sor és oszlop
            //elhelyezzük a "K"t csak akkor, ha "#" van 
            Random vel = new Random();          
            for (int i = 0; i < N; i++)
            {
                int sor = vel.Next(0, 8);
                int oszlop = vel.Next(0, 8);
                while (T[sor, oszlop] == 'K')
                {
                    sor = vel.Next(0, 8);
                    oszlop = vel.Next(0, 8);
                }
                T[sor, oszlop] = 'K';
            }
        }
        public void FajlbaIr(StreamWriter fajl)
        {
            //fajl.WriteLine("asd");
            for (int i = 0; i < 8; i++)
            {
                string s = "";
                for (int j = 0; j < 8; j++)
                {
                    s += T[i, j];
                }
                fajl.WriteLine(s);
            }     
        }
        public void Megjelenit()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0,-2}", T[i, j]);
                }
            }
        }
        public bool UresOszlop(int oszlop)
        {
            //Ha talál "K" akkor hamissal tér vissza
            //üres-e a sor
            /*1 ciklus, a soron végig
             * ha T[sor[i] meg T[i, oszlop]
             * */
            bool k = true;
            for (int i = 0; i < 8; i++)
            {
                if (T[i, oszlop]=='K')
                {
                    k=false;
                }           
            }
            
            return k;
            /*int i=0;
              while(i<8)&&(T[i,oszlop]!='K')
              {
                   i++;
              }
              if (i<8)
              {
                 return false;
              }
              else
              {
                   return true;
              }
             */
        }      
        public bool UresSor(int sor)
        {
            /*int i=0;
              while(i<8)&&(T[i,sor]!='K')
              {
                   i++;
              }
              if (i<8)
              {
                 return false;
              }
              else
              {
                   return true;
              }
             */
            bool k = true;
            for (int i = 0; i < 8; i++)
            {
                if (T[i, sor] == 'K')
                {
                    k = false;
                }
            }
            return k;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat");
            Tabla[] tomb=new Tabla[64];
            Tabla t = new Tabla('#');
            Console.WriteLine("Üres tábla:");
            t.Megjelenit();
            t.Elhelyez(8);
            Console.WriteLine();
            t.Megjelenit();
            Console.WriteLine();
            Console.Write("Melyik sor: ");
            int sor=int.Parse(Console.ReadLine());
            if (t.UresSor(sor))
            {
                Console.WriteLine("A megadott sor nem üres.");
	        }
            else
	        {
                Console.WriteLine("A megadott sor üres.");
	        }
             Console.Write("Melyik oszlop: ");
            int oszlop=int.Parse(Console.ReadLine());
            if (t.UresOszlop(oszlop))
            {
                Console.WriteLine("A megadott nem üres.");
	        }
            else
	        {
                Console.WriteLine("A megadott oszlop üres.");
	        }
            Console.WriteLine();
            Console.WriteLine("8.feladat: Az üres oszlopok és sorok száma:");
            int uresSor=0;
            int uresOszlop=0;
            for (int i = 0; i < 8; i++)
			{
                if (t.UresOszlop(i)==true)
	            {

                    uresOszlop++;
	            }
                if (t.UresSor(i)==true)
	            {
                    uresSor++;
	            }
			}
            Console.WriteLine();
            Console.WriteLine("Üres sorok száma:{0}",uresSor);
            Console.WriteLine();
            Console.WriteLine("Üres oszlop száma:{0}",uresOszlop);
            StreamWriter ir=new StreamWriter("adatok.txt");
            for (int i = 0; i < 64; i++)
			{
                tomb[i]=new Tabla('*');
			}
            for (int i = 0; i < 64; i++)
			{
                tomb[i].Elhelyez(i+1);
                tomb[i].FajlbaIr(ir);
                ir.WriteLine();
			}
            ir.Close();
            Console.ReadKey();
        }
    }
}
