using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SwapTwoVariables
{
    class Program
    {
        static void Main(string[] args)
        {
			//This programs swaps two variables without using a temporary variable
           int a = 7; // binary: 0000‭0111‬
           int b = 4; // binary: 00000100

            //Let's start by XOR a with b:
            a ^= b;
            //a = a ^ b;
            // a = 0000‭0111 ^ 00000100;
            // a = 00000011;

            //Then XOR b with a:
            b ^= a;
            //b = b ^ a;
            // b = 00000100 ^ 00000011
            // b = 00000111;

            //and then XOR a with b:
            a ^= b;
            //a = a ^ b;
            //a = 00000011 ^ 00000111;
            //a = 00000100;

            Console.ReadLine();

        }
    }
}
