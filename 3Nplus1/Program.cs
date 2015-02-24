/*---------------------------------------------
Hailstorm: The Collatz Conjecture simulator
-----------------------------------------------
By Andrew Pinion

this program computes the 3N+1 problem (collatz conjecture) for every number
between two numbers you input, and returns which one took the largest number of
iterations
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Nplus1
{
    class Program
    {
        static void Main(string[] args)
        {
            //get input
            Console.Write("Hailstorm: A collatz conjecture calculator\n\n");
            Console.Write("Lower Bound>");
            int input = Int32.Parse(Console.ReadLine());
            Console.Write("Upper Bound>");
            int input2 = Int32.Parse(Console.ReadLine());

            //send input
            between(input, input2);
        }

        //find which number between the two inputs that has the largest number of iterations to reach 1.
        static void between(int one, int two)
        {
            int biggest = 0;
            int biggesti = 0;
            int temp;
            totali = 0;

            for(int i=one;i<=two;i++)
            {
                temp = doMainLoop(i);
                if (temp > biggest) { biggesti = i; biggest = temp; }
                if (temp == -1) Console.WriteLine("Failure computing iterations for number " + i);
            }
            Console.WriteLine("\nBIGGEST = " + biggesti + " with " + biggest + " hailstone numbers (iterations)");
            Console.WriteLine("TOTAL ITERATIONS = " + totali);
            Console.Write("\nPress any key to exit.");
            Console.ReadLine();
        }

        static ulong totali = 0;

        //return number of iterations
        //this is currently capped at 5000 to prevent the program (or my celeron laptop) from hanging indefinitely.
        static int doMainLoop(int num)
        {
            int count = 1;
            ulong number = (ulong)num;
            while (number != 1)
            {
                if (number % 2 != 0) number = (3 * number) + 1;
                else number = number / 2;
                count++;
                if (count > 5000) { number = 1; count = -1; }
            }
            totali += (ulong)count;
            return count;
        }
    }
}
