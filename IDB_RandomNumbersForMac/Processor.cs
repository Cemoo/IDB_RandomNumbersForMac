using System;
using System.Collections.Generic;

namespace IDB_RandomNumbersForMac
{
    public class Processor
    {
        IText text = null;
        List<string> list = null;
        public Processor(IText _text, List<string> _list)
        {
            text = _text;
            list = _list;

        }

        public void Process() {
            if (text != null)
            {
                text.Write(list);
            }

        }
    }
}
