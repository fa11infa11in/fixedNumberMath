using System;
using FNM;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
            
            FixedNumberVector3 veca = new FixedNumberVector3((FixedNumber)0.7f, 0, (FixedNumber)(-1.0f * 0.5f));
            Console.WriteLine(veca.normalized);
            Console.WriteLine(veca.SqMagnitude());
            Console.WriteLine(veca.Magnitude());
            
            Console.WriteLine("root : 0.74f:" +  FixedNumber.SquareRoot((FixedNumber)0.74f));
            
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

