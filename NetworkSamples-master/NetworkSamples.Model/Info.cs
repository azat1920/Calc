using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkSamples.Model
{
    public class Info
    {
        public void writeInf()
        {
            Console.WriteLine("Когда первый символ строки '>' - введите операнд (число)");
            Console.WriteLine("Ввод вещественных чисел осуществляется при помощи запятой");
            Console.WriteLine("Когда первый символ строки '@' - введите операцию");
            Console.WriteLine("Доступные операции:");
            Console.WriteLine("+ - * /");
            Console.WriteLine("#i - переход к данному шагу i, где i - это номер шага");
            Console.WriteLine("q  - выход из программы");
            writeStep(1, 1);
        }

        public string writeStep(int i, double d)
        {

            return String.Format("a[{0}]={1}", i, d);
        }

        public void writeN()
        {
            Console.Write("> ");
        }

        public void writeO()
        {
            Console.Write("@: ");
        }

    }
}
