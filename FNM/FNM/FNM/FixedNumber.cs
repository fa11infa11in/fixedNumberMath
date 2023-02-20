using System;

namespace FNM
{
    public struct FixedNumber
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
            bigNumber = (value * Multiple);
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
           

            temp = (a.bigNumber << MultipleBits) / b.bigNumber;
            

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
        
        public static FixedNumber operator <<(FixedNumber val, int moveCount)
        {
            return new FixedNumber(val.bigNumber << moveCount);
        }
        
        public static FixedNumber operator >>(FixedNumber val, int moveCount)
        {
            if( val.bigNumber >=0 )
            {return new FixedNumber(val.bigNumber >> moveCount);}
            else
            {
                return new FixedNumber(-(-val.bigNumber >> moveCount));
            }
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

        public static FixedNumber SquareRoot( FixedNumber val, int iteratorCount = 8 )
        {
            if (val == FixedNumber.Zero)
                return 0;

            if (val < FixedNumber.Zero)
                throw new Exception();
            FixedNumber result = val;
            FixedNumber preRes;
            int count = 0;
            do
            {
                preRes = result;
                result = (result + val / result) >> 1;
                count += 1;
            } while (preRes != result&& count < iteratorCount);
            
            return result;
        }


        public static FixedNumber Clamp(FixedNumber val,FixedNumber min ,FixedNumber max )
        {
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
            
            val = (val * ArccosValueTable.Count / 2 + ArccosValueTable.Count / 2);
            FixedNumber temp = Clamp( val, Zero, ArccosValueTable.Count );
            FixedNumber result = new FixedNumber((long)ArccosValueTable.ValueTable[temp.ToInt()]);
            return result;
        }
        

    }
}

