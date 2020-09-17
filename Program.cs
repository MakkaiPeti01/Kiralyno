using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiralyno
{
    class Tabla
    {
        char[,] T;
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
        public void FajlbaIr()
        {

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
            if (k==false)
            {
                Console.WriteLine("Van királynő az oszlopban");
            }
            else
            {
                Console.WriteLine("Nincs Királynő az oszlopban");
            }
            return k;
        }      
        public bool UresSor(int sor)
        {
            bool k = true;
            for (int i = 0; i < 8; i++)
            {
                if (T[i, sor] == 'K')
                {
                    k = false;
                }
            }
            if (k == true)
            {
                Console.WriteLine("Van királynő a sorban");
            }
            else
            {
                Console.WriteLine("Nincs Királynő a sorban");
            }
            return k;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat");
            Tabla t = new Tabla('#');
            Console.WriteLine("Üres tábla:");
            t.Megjelenit();
            t.Elhelyez(8);
            Console.WriteLine();
            t.Megjelenit();
            t.UresOszlop(3);
            t.UresSor(5);
            Console.ReadKey();
        }
    }
}
