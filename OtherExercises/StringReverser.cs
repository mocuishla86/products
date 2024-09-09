using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherExercises
{
    public class StringReverser
    {
        public static string Reverse(string input)
        {
            String output = "";

            for(int i = input.Length - 1; i >= 0; i--) 
            {
                output += input[i];
            }

            return output;
        }
    }
}
