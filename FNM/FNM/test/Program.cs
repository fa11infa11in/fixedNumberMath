using System;
using System.Net.Mime;
using FNM;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // float cur = -1.0f;
            //  for (int i = 0; i <= 4096; i++)
            //  {
            //     
            //      double temp = Math.Acos(cur);
            //      temp *= 4096;
            //      int show = (int)Math.Round(temp);
            //      Console.Write(show.ToString() + ",");
            //      cur += 2.0f / 4096;
            // }
            FixedNumber a = new FixedNumber(1.0f);
            FixedNumber b = new FixedNumber(-3.0f);
            FixedNumber ab = new FixedNumber(a * b);
            FixedNumber adb = new FixedNumber(a / b);
            
            Console.WriteLine(a.bigNumber.ToString());
            
            
            Console.WriteLine(b.bigNumber.ToString());
            
            Console.WriteLine(adb.bigNumber);
            
            Console.WriteLine(adb.ToFloat());
            
            FixedNumber c = new FixedNumber(5);
            FixedNumber csqrt = FixedNumber.SquareRoot(c);
            
            Console.WriteLine(csqrt.ToFloat());
            
            FixedNumberVector3 veca = new FixedNumberVector3(2, 2, 2);
            Console.WriteLine(veca.SqMagnitude());
            Console.WriteLine(veca.Magnitude());
            FixedNumberVector3 vecb = new FixedNumberVector3(2, 2, 0);
            Console.WriteLine(vecb.Magnitude());
            
            FixedNumber dot = FixedNumberVector3.DotProduct(veca, vecb);
            Console.WriteLine(dot.ToFloat());
            
            Console.WriteLine(FixedNumber.Arccos( (FixedNumber)0.816496f ));
            
            FixedNumber angle = FixedNumberVector3.Angle(veca, vecb);
            Console.WriteLine(angle.ToFloat());
            
            Console.ReadKey();
        }
    }
}

