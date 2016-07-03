using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient
{
    public class Info
    {
        public List<string> Inf(string s)
        {   
            List<string> msg = new  List<string>();
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(s);
            
            msg.Add(MyResources.m1); msg.Add(MyResources.m2); msg.Add(MyResources.m3); msg.Add(MyResources.m4);
            msg.Add(MyResources.m5); msg.Add(MyResources.m6); msg.Add(MyResources.m7); msg.Add(MyResources.m8);
            
            return msg;
            
        }

        public string writeStep(int i, double d)
        {

            return String.Format("a[{0}]={1}", i, d);
        }

        public string writeN()
        {
            return (">");
        }

        public string writeO()
        {
            return ("@");
        }

    }
}
