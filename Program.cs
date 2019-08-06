using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            var iterations = int.Parse(args[0]);
            var overlapsUnitCircle = 0;

            for (int i = 0; i < iterations; i++)
            {
                var (x, y) = RandomPair(rand);
                var hypotenuse = CalculateHypotenuse(x, y);

                if (hypotenuse <=1)
                {
                    overlapsUnitCircle++;
                }
            }
          

            var  piEstimate = 4.0 * overlapsUnitCircle / iterations; 

            Console.WriteLine($"our estimate: {piEstimate}");
            Console.WriteLine($"Delta pi: {Math.Abs(piEstimate - Math.PI)}");
        
        }  
            static double CalculateHypotenuse(double x, double y)
                => Math.Sqrt(x * x + y * y);

             static (double, double) RandomPair(Random r) 
            =>  (r.NextDouble(), r.NextDouble());
           
    }
}
     
            



              

