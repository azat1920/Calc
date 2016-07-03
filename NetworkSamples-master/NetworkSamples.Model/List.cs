using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkSamples.Model
{
    public class List
    {
        public List<double> list = new List<double>();

        public void Add(double a)
        {
            list.Add(a);
        }

        public double get(int i)
        {
            return list.ElementAt(i);
        }

        public int Count()
        {
            return list.Count;
        }

    }
}
