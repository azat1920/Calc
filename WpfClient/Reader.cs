using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient
{
   public class Reader
    {   
        Info msg = new Info();
        

        public string readNum(string s)
        {
            double d;    
            return (Double.TryParse(s, out d))? d.ToString() : "";
        }

        public string readOper(string str)
        {   string s = "0";
            string k = "";

            k = str;
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
            

            return s;
        }


    }
}
