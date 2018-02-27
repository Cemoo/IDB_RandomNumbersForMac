using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;


namespace IDB_RandomNumbersForMac
{
    
    public class MainClass
    {
        private const int value = 60000;
        static List<string> list = new List<string>();
        static List<string> rndList = new List<string>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press 0 -- Numbers write to excel \n Press 1 -- Numbers write to text");
                string param = Console.ReadLine();
                Console.WriteLine("Processing...");
                var list = ListOfNumbers();
                if (list.Count > 0)
                {
                    List<string> randomList = GetRandomFor(value);
                    Processor pro = new Processor(CreateTextWriter(int.Parse(param)), randomList);
                    pro.Process();
                    Console.ReadLine();
                }
            }
         
        }

        //Gives a writer to write numbers
        public static IText CreateTextWriter(int param)
        {
            IText text;
            if (param == 1) // Text write
            {
                text = new TextWrite();
            } else if (param == 0) {
                Console.WriteLine("Sorry we cant support Excel now. We ll see soon.");
                text = new ExcelWrite();
            }
            else
            {
                Console.WriteLine("Please enter 1 or 0.");
                text = null;
            }
            return text;
        }

        //Number list between 0-16
        public static List<string> ListOfNumbers()
        {
            list.Clear();
            for (double i = 0; i <= 15; i = i + 0.1)
            {
                list.Add(Truncate(i));
            }
            return list;
        } 

        //this is for getting one digit after comma
        public static string Truncate(double num)
        {
            var arrCount = num.ToString().Split('.');
            if (arrCount.Length > 1)
            {
                var numBeforeComma = num.ToString().Split('.')[0];
                var numAfterComma = num.ToString().Split('.')[1];
                numAfterComma = numAfterComma.Substring(0, 1);
                return numBeforeComma + "." + numAfterComma;
            }
            else
            {
                return num.ToString();
            }
        }

        //random numbers is chosen here from list that is between 0-16
        public static List<string> GetRandomFor(int times)
        {
            rndList.Clear();
            var rnd = new Random();
            for (int i = 0; i < times; i++)
            {
                int index = rnd.Next(list.Count);
                rndList.Add(list[index]);
            }

            return rndList;
        }

    }
}
