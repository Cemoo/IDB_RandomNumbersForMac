using System;
using System.Collections.Generic;

namespace IDB_RandomNumbersForMac
{
    public interface IConvert
    {
        List<double> ConvertDouble(List<string> list);
        List<int> ConvertInt(List<string> list);
    }
}
