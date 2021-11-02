using System;
using System.Collections.Generic;
using System.Threading;

namespace H2Threading
{
    class Program
    {
        static char Key = '*';
        static void Main(string[] args)
        {
            Thread t = new Thread(Printer);
            Thread t2 = new Thread(Reader);
            t.Start();
            t2.Start();
            //while (t.IsAlive)
            //{
            //    Thread.Sleep(10000);
            //    if (t.IsAlive == false)
            //    {
            //        Console.WriteLine("Alarm - tråd termineret");

            //    }
            //}
            Console.ReadKey();

        }
        //Method that writes out the current threads name
        static void WorkThreadFunction()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
            }
        }
        //Prints out a text
        static void CsharpIsEasy()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("C#-trådning er nemt!");
                Thread.Sleep(5000);
            }
        }
        //Prints out a text
        static void MoreThreads()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Også med flere tråde…");
                Thread.Sleep(5000);
            }
        }
        //Method to calculate temperatur, and warns if alarm goes off
        static void TempReader()
        {
            int alarmcount = 0;
            //While alarmcount is not 3
            while (alarmcount != 3)
            {
                //Creates random and gets a random temp
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int temp = r.Next(-20, 120);
                //If alarmcount is less than 3 and temp is higher than 0 and less than 100 celcius set alarmcount, otherwise resume
                if (alarmcount < 3)
                {
                    if (temp < 0 || temp > 100)
                    {
                        alarmcount++;
                        Console.WriteLine($"Alarm hit: count {alarmcount}");
                    }
                    Thread.Sleep(2000);
                }
            }

        }
        static void Printer()
        {
            char ch = '*';
            while (true)
            {
                ch = Key;
                Console.WriteLine(ch);
                Thread.Sleep(1000);
            }
        }
        static void Reader()
        {
            while (true)
            {
                
                Key = Convert.ToChar(Console.ReadLine());
                Thread.Sleep(2000);
            }
        }
    }
}
