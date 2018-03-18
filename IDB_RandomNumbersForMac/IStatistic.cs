using System;
using System.Collections.Generic;
using System.Linq;


namespace IDB_RandomNumbersForMac
{
    public interface IStatistic
    {

        double GetMin(List<string> list);
        double GetMax(List<string> list);
        double GetMod(List<string> list);
        double GetSTDev(List<string> list);
        decimal GetMedian(List<string> list);
        List<string> Between(List<string> list);

    }

    public class GetStatistics : IStatistic
    {
        public List<string> listForChart = new List<string>();

        private Convertion convert = new Convertion();
        public double GetMax(List<string> list)
        {
            return convert.ConvertDouble(list).Max();
        }

        public decimal GetMedian(List<string> list)
        {
            decimal median = 0;
            int size = list.Count();
            int mid = size / 2;
            median = (size % 2 != 0) ? (decimal)convert.ConvertInt(list)[mid] : ((decimal)convert.ConvertInt(list)[mid] + (decimal)convert.ConvertInt(list)[mid] + 1) / 2;
            return Convert.ToInt32(Math.Round(median));
        }

        public double GetMin(List<string> list)
        {
            return convert.ConvertDouble(list).Min();
        }

        public double GetMod(List<string> list)
        {
            
            int mode = convert.ConvertInt(list).GroupBy(x => x).OrderByDescending(y => y.Count()).First().Key;
            return mode;
        }

        public double GetSTDev(List<string> list)
        {
            var doubleList = convert.ConvertDouble(list);
            double average = doubleList.Average();
            double sumOfSquaresOfDifferences = doubleList.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / doubleList.Count());
            return sd;
        }

        public List<string> Between(List<string> list)
        {
            var total = 0;
            var betweenList = convert.ConvertDouble(list);
            listForChart.Clear();
            for (int i = 0; i < 15; i++)
            {
                int count = (from item in betweenList where item >= i && item <= i + 0.99 select item).Count();
                Console.WriteLine("Between " + i.ToString() + " and " + (i + 0.99).ToString() + "-----" + count.ToString());
                total = total + count;

                if (i<4)
                {
                    listForChart.Add(count.ToString());
                }

            }

            //Console.WriteLine("TOTAL: " + total.ToString());

            return listForChart;

        }
    }

    public class Convertion : IConvert
    {
        private List<double> doubleList = new List<double>();
        private List<int> intList = new List<int>();

        public List<double> ConvertDouble(List<string> list)
        {
            doubleList.Clear();
            if (list.Count()!=0)
            {
                foreach (var item in list)
                {
                    doubleList.Add(Double.Parse(item));
                }
            }

            return doubleList;
        }

        public List<int> ConvertInt(List<string> list)
        {
            intList.Clear();
            if (list.Count() != 0)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    intList.Add(Convert.ToInt32(Math.Floor(Convert.ToDouble(list[i]))));
                }
            }

            return intList;
        }
    }


}
