using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeExamples.Services
{
    public class DataContext
    {
        static readonly Random _rand = new Random();
        public DataContext()
        {
            //The class will return the same random number for its lifetime
            RowCount = _rand.Next(1, 1_000_000_000);
        }

        public int RowCount { get; }
    }

    public class TransientDataContext : DataContext { }
    public class ScopedDataContext : DataContext { }
    public class SingletonDataContext : DataContext { }

}
