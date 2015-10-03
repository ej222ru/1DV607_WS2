using _1DV607_WS2.View;
using _1DV607_WS2.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_WS2
{
    class Program
    {
        static void Main(string[] args)
        {
            
           Menu menu = new Menu();
           Control controller = new Control(menu);
           controller.start();
        }
    }
}
