using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FNM
{
    public class FixedNumber
    {
        public long bigNumber;

        public static readonly int MultipleBits = 12;

        public static readonly uint Multiple = 4096;

        public static FixedNumber One
        {
            get
            {
                return new FixedNumber(1);
            }
        }

        public static FixedNumber Zero
        {
            get { return new FixedNumber(0); }
        }

        public static FixedNumber Pi
        {
            get { return new FixedNumber(3.1416f); }
        }

        #region constructor


        public FixedNumber(long bigNumber)
        {
            this.bigNumber = bigNumber;
        }



        public FixedNumber( int value )
        {
            bigNumber = (value << MultipleBits);
        }

        public FixedNumber( float value )
        {
            bigNumber = (long)Math.Round(value * Multiple);
        }

        public FixedNumber( FixedNumber fn )
        {
            this.bigNumber = fn.bigNumber;
        }

        public static implicit operator FixedNumber( int value )
        {
            return new FixedNumber(value);
        }

        public static explicit operator FixedNumber(float value)
        {
            return new FixedNumber(value);
        }

        
        #endregion

        #region operator override
        public static FixedNumber operator + ( FixedNumber a, FixedNumber b )
        {
            return new FixedNumber(a.bigNumber + b.bigNumber);
        }

        public static FixedNumber operator -( FixedNumber a, FixedNumber b )
        {
            return new FixedNumber(a.bigNumber - b.bigNumber);
        }

        public static FixedNumber operator *(FixedNumber a, FixedNumber b)
        {

            long temp = a.bigNumber * b.bigNumber;

            if (temp < 0)
            {
                temp = -1 * temp;
                temp = temp >> MultipleBits;
                temp *= -1;
            }
            else
            {
                temp = temp >> MultipleBits;
            }
            
            
            return new FixedNumber(temp); 
        }

        public static FixedNumber operator /( FixedNumber a, FixedNumber b )
        {
            long temp = 0;
            if (b.bigNumber == 0)
                throw new Exception();
            else
            {

                 temp = (a.bigNumber << MultipleBits) / b.bigNumber;
            }

            return new FixedNumber(temp);
        }

        public static bool operator == ( FixedNumber a, FixedNumber b )
        {
            return ( a.bigNumber == b.bigNumber) ;
        }

        public static bool operator !=(FixedNumber a, FixedNumber b)
        {
            return ( a.bigNumber != b.bigNumber );
        }

        public static bool operator > (FixedNumber a, FixedNumber b)
        {
            return a.bigNumber > b.bigNumber;
        }

        public static bool operator >=(FixedNumber a, FixedNumber b)
        {
            return a.bigNumber >= b.bigNumber;
        }

        public static bool operator <(FixedNumber a, FixedNumber b)
        {
            return a.bigNumber < b.bigNumber;

        }

        public static bool operator <=(FixedNumber a, FixedNumber b)
        {
            return a.bigNumber <= b.bigNumber;
        }
        #endregion

        public float ToFloat()
        {
            return this.bigNumber * 1.0f / Multiple;
        }

        public int ToInt()
        {
            return (int)(bigNumber / Multiple);
        }


        public override string ToString()
        {
            return ToFloat().ToString();
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            FixedNumber val = (FixedNumber)obj;
            return this == val;
        }

        public static FixedNumber SquareRoot( FixedNumber val )
        {
            if (val.bigNumber < 0)
                throw new Exception();
            
            long resultSqrt = val.bigNumber;
            
            while ((resultSqrt * resultSqrt) / Multiple > val.bigNumber)
            {
                resultSqrt = (resultSqrt + val.bigNumber*Multiple / resultSqrt ) /2;
            }

            return new FixedNumber(resultSqrt);
        }


        public static FixedNumber Clamp(FixedNumber val,FixedNumber min ,FixedNumber max )
        {
            if (max < min)
                throw new Exception();

            if (val >= max)
            {
                return new FixedNumber( max);
            }
            else if (val <= min)
            {
                return new FixedNumber(min);
            }
            else
            {
                return new FixedNumber(val);
            }
            
        }

        public static FixedNumber Arccos(FixedNumber val)
        {
            //measured in radius
            if (val > FixedNumber.One || val < -1)
            {
                throw new Exception();
            }

            #region 会溢出
            
            // FixedNumber temp = new FixedNumber(val);
            // Console.WriteLine("输入："+temp.ToFloat());
            // Console.WriteLine("count:" + new FixedNumber(ArccosValueTable.Count / 2));
            // temp = temp * ArccosValueTable.Count / 2;
            // Console.WriteLine(temp.ToFloat());
            // temp += ArccosValueTable.Count / 2;
            // Console.WriteLine(temp.ToFloat());
            //
            // temp = Clamp(temp, ArccosValueTable.Count,0 );
            //
            // Console.WriteLine( "temp: " + temp.ToInt());
            // Console.WriteLine( "查表得：" + ArccosValueTable.ValueTable[temp.ToInt()]);
            #endregion
            
            long tempval = val.bigNumber;
           
            tempval *= ArccosValueTable.Count / 2;
            tempval /= Multiple;
            tempval += ArccosValueTable.Count / 2;
            FixedNumber result = new FixedNumber((long)ArccosValueTable.ValueTable[tempval]);
            return result;
        }
        

    }
}

