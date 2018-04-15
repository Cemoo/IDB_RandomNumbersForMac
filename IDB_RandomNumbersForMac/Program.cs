using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Diagnostics.Contracts;
using Newtonsoft.Json;

namespace IDB_RandomNumbersForMac
{
    
    public class MainClass
    {
        public List<string> chart = new List<string>();
        private const int value = 60000;
        static List<string> list = new List<string>();
        static List<string> rndList = new List<string>();

        public static List<string> testArr = null;
 
        public static void Main(string[] args)
        {
            string a = AppDomain.CurrentDomain.BaseDirectory;
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



                    Console.WriteLine("STATISTICS!!!");
                    Processor st = new Processor(CreateStatistic(), randomList);
                    st.Statistics();
                    var json = JsonConvert.SerializeObject(st.result);
                    testArr = st.result;
                    //foreach (var item in st.result)
                    //{
                    //    str = str + item + ",";
                    //}
                    Console.WriteLine("Press 2 for getting the chart of data");
                   // string url = "/Users/erencanevren/Desktop/CEMAL/IDB_RandomNumbersForMac/IDB_RandomNumbersForMac/chart.html";
                    string url = AppDomain.CurrentDomain.BaseDirectory + "chart.html";
                    if (Convert.ToInt32(Console.ReadLine()) == 2)
                    {
                        System.Diagnostics.Process.Start(url);
                    }

                    Console.ReadLine();

                }
            }
         
        }

        public static List<string> GetArr() {
            return testArr;
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

        public static IStatistic CreateStatistic() {
            return new GetStatistics();
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
