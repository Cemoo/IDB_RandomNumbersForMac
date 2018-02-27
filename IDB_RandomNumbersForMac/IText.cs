using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace IDB_RandomNumbersForMac
{
    public interface IText
    {
        void Read();
        void Write(List<string> list);
    }

    public class ExcelWrite: IText {
        public void Write(List<string> list) {
            Console.WriteLine("This feature will be added soon");
        }

        public void Read() {
            Console.WriteLine("This feature will be added soon");
        }
             
    }

    public class TextWrite : IText
    {
        string textPath = "/Users/cemalbayri/Desktop/randomNumbers.txt";

        public void Write(List<string> list)
        {
            string text = "";
            File.WriteAllText(textPath,String.Empty);
            if (list.Count != 0)
            {
                foreach (var listItem in list)
                {
                    text = text + listItem + "\n";
                }
                File.WriteAllText(textPath, text);
                Console.WriteLine("Wrote in text");
            }
        }

        public void Read()
        {
            Console.WriteLine("This feature will be added soon");
        }
    }

}
