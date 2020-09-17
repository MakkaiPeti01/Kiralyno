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
        public int UresOszlop()
        {
            return 0;
        }
        public int UresSor()
        {
            return 0;
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
            Console.ReadKey();
        }
    }
}
