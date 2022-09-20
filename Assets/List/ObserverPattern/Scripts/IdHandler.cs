using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ObserverPattern
{
    class IdHandler
    {
        static int id = 0;
        static readonly object _lock = new object();

        public static int GetNewId()
        {
            int v = 0;

            lock(_lock)
            {
                v = id;
                id++;
            }

            return v;
        }
    }
}
