using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkSamples.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Info msg = new Info();
            Reader reader = new Reader();
            List list = new List();
            Operations oper = new Operations();

            msg.writeInf();

            
            int i = 1;
            list.Add(0);
            list.Add(reader.readNum());
            msg.writeStep(i, list.get(i));
            oper.operate(ref list, reader, msg, i);


            Console.Read();

        }
    }
}
