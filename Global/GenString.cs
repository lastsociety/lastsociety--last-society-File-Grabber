using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace last_society
{
    class GenString
    {
        public static string Generate()
        {
            string abc = "acegikmoqsuwyBDFHJLNPRTVXZ";
            string result = "";
            Random rnd = new Random();
            int iter = rnd.Next(0, abc.Length);
            for (int i = 0; i < iter; i++)
                result += abc[rnd.Next(10, abc.Length)];

            return result;
        }

        public static int GeneNumbers()
        {
          
            Random rnd = new Random();

            
            int value = rnd.Next(0, 10);

            return value;
        }

        public static int GeneNumbersTo()
        {
            
            Random rnd = new Random();

            
            int value = rnd.Next(11, 99);

            return value;
        }


    }
}
