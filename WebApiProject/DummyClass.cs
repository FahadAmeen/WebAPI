using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject
{
    public class DummyClass
    {
        public bool check()
        {
            return true;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
    }
}
