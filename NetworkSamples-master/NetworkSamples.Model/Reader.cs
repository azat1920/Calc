using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkSamples.Model
{
   public class Reader
    {   
        Info msg = new Info();
        

        public string readNum()
        {
                
            double d;
            string s;
            do
            {
               
                msg.writeN();
                s = Console.ReadLine();
            }
            while (Double.TryParse(s, out d) == false);
        

           return d.ToString();
        }

        public string readOper()
        {   string s = "0";
            string k = "";

            do
            {
            msg.writeO();

            do k = Console.ReadLine(); while (k == "");
            switch (k.ElementAt(0))
	        {
                case '+': s = "+"; break;
                case '-': s = ("-"); break;
                case '*': s = ("*"); break;
                case '/': s = ("/"); break;
                case '#':
                    {   
                        int n;
                        if (!Int32.TryParse(k.Substring(1, k.Length - 1), out n)) s = "0";
                        else s = k;
                       // i *= -1;
                    } 
                    break;
                case 'q': s = ("q"); break;

                default: s = "0"; break;
	        }   
            } while (s.Equals("0"));

            return s;
        }


    }
}
