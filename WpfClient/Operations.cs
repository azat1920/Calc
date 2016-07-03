using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient
{
    public class Operations
    {

        public double oper(string s, List<double> list, double c)
        {

            switch (s.ElementAt(0))
            {

                case '+': return (list[list.Count - 1] + c);
                case '-': return (list[list.Count - 1] - c);
                case '*': return (list[list.Count - 1] * c);
                case '/': return (list[list.Count - 1] / c);
                case '#':
                    {
                        int k = Int32.Parse(s.Substring(1));
                        if (k > list.Count || k < 0) k = 0;
                        return list[k] * 1;
                    }
                case 'q': Environment.Exit(0); break;
                default: break;
            }

            return 0;
        }

    }
}
