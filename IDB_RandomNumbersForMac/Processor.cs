using System;
using System.Collections.Generic;

namespace IDB_RandomNumbersForMac
{
    public class Processor
    {
        IText text = null;
        IStatistic statistics = new GetStatistics();
        List<string> list = null;

        public List<string> result = null;

        public Processor(IText _text, List<string> _list)
        {
            text = _text;
            list = _list;

        }

        public Processor(IStatistic _statitistic, List<string> _list)
        {
            statistics = _statitistic;
            list = _list;
        }

        public void Process() {
           
            if (text != null)
            {
                text.Write(list);
            }
        
        }

        public void Statistics() {

            result = new List<string>();
            Console.WriteLine();
            Console.WriteLine("---------------");
            Console.WriteLine();
            Console.WriteLine("Min:" + statistics.GetMin(list).ToString());
            Console.WriteLine("Max:" + statistics.GetMax(list).ToString());
            Console.WriteLine("Mod:" + statistics.GetMod(list).ToString());
            Console.WriteLine("STDEV:" + statistics.GetSTDev(list).ToString());
            Console.WriteLine("Median:" + statistics.GetMedian(list));
            Console.WriteLine();
            Console.WriteLine("---------------");
            result = statistics.Between(list);



        }
       
    }
}
