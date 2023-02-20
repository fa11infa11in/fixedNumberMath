using System;
using UnityEngine;

namespace FNM
{
	public struct FixedNumberVector2
	{

        public FixedNumber x;
        public FixedNumber y;

        public FixedNumberVector2(FixedNumber fnx, FixedNumber fny)
        {
            x = new FixedNumber(fnx);
            y = new FixedNumber(fny);
            
        }

        public FixedNumberVector2(Vector2 vec)
        {
            x = (FixedNumber)vec.x;
            y = (FixedNumber)vec.y;
        }


        public static FixedNumberVector2 operator +(FixedNumberVector2 a, FixedNumberVector2 b)
        {
            return new FixedNumberVector2(a.x + b.x, a.y + b.y);
        }

        public static FixedNumberVector2 operator -(FixedNumberVector2 a, FixedNumberVector2 b)
        {
            return new FixedNumberVector2(a.x - b.x, a.y - b.y);
        }

        public static FixedNumberVector2 operator *(FixedNumberVector2 a, FixedNumber multi)
        {
            return new FixedNumberVector2(a.x * multi, a.y * multi);
        }

        public static FixedNumberVector2 operator *(FixedNumber multi, FixedNumberVector2 a)
        {
            return new FixedNumberVector2(a.x * multi, a.y * multi);
        }

        public static FixedNumberVector2 operator /(FixedNumberVector2 a, FixedNumber divider)
        {
            return new FixedNumberVector2(a.x / divider, a.y / divider);
        }

        public static bool operator ==(FixedNumberVector2 a, FixedNumberVector2 b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(FixedNumberVector2 a, FixedNumberVector2 b)
        {
            return a.x != b.x || a.y != b.y;
        }

        public static FixedNumber DotProduct(FixedNumberVector2 a, FixedNumberVector2 b)
        {
            return new FixedNumber(a.x * b.x + a.y * b.y);
        }

        public FixedNumber SqMagnitude()
        {
            return new FixedNumber(x * x + y * y);
        }

        public FixedNumber Magnitude()
        {
            return FixedNumber.SquareRoot(SqMagnitude());
        }

        public FixedNumberVector2 normalized
        {
            get
            {
                if (Magnitude() > 0)
                {
                    return new FixedNumberVector2(this.x / Magnitude(), this.y / Magnitude());
                }
                else
                {
                    return new FixedNumberVector2(0, 0);
                }
            }
        }

        public void Normalize()
        {
            this.x /= Magnitude();
            this.y /= Magnitude();
        }

        public Vector3 ToUnityVector2()
        {
            return new Vector2(x.ToFloat(), y.ToFloat());
        }


        public static FixedNumber Angle(FixedNumberVector2 from, FixedNumberVector2 to)
        {
            //measured in degree
            FixedNumber dotProduct = FixedNumberVector2.DotProduct(from, to);
            FixedNumber magnitudeProduct = from.Magnitude() * to.Magnitude();

            if (magnitudeProduct == 0)
                throw new Exception();

            FixedNumber cosValue = dotProduct / magnitudeProduct;
            FixedNumber radiusValue = FixedNumber.Arccos(cosValue);
            FixedNumber degree = radiusValue / FixedNumber.Pi * 180;

            return degree;

        }

        public override string ToString()
        {
            return String.Format("x:{0}, y:{1}.", x.ToFloat(), y.ToFloat());
        }
    }
}

