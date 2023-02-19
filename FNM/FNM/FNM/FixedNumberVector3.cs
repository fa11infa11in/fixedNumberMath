using System;
using UnityEngine;

namespace FNM
{
	public struct FixedNumberVector3
	{

		public FixedNumber x;
		public FixedNumber y;
		public FixedNumber z;

		public static FixedNumberVector3 Zero
		{
			get
			{
				return new FixedNumberVector3(0, 0, 0);
			}
		}

		public static FixedNumberVector3 One
		{
			get
			{
				return new FixedNumberVector3(1, 1, 1);
			}
		}

		public FixedNumberVector3( FixedNumber fnx, FixedNumber fny, FixedNumber fnz  )
		{
			x = new FixedNumber(fnx);
			y = new FixedNumber(fny);
			z = new FixedNumber(fnz);
		}

		public FixedNumberVector3(Vector3 vec)
		{
			x = (FixedNumber)vec.x;
			y = (FixedNumber)vec.y;
			z = (FixedNumber)vec.z;
		}

		public FixedNumberVector3(FixedNumberVector3 vec)
		{
			x = vec.x;
			y = vec.y;
			z = vec.z;
		}

		public static FixedNumberVector3 operator +(FixedNumberVector3 a, FixedNumberVector3 b)
		{
			return new FixedNumberVector3(a.x + b.x, a.y + b.y, a.z + b.z);
		}

		public static FixedNumberVector3 operator -(FixedNumberVector3 a, FixedNumberVector3 b)
		{
			return new FixedNumberVector3(a.x - b.x, a.y - b.y, a.z - b.z);
		}

		public static FixedNumberVector3 operator *(FixedNumberVector3 a, FixedNumber multi)
		{
			return new FixedNumberVector3(a.x * multi, a.y * multi, a.z * multi);
		}
		
		public static FixedNumberVector3 operator *( FixedNumber multi,FixedNumberVector3 a)
		{
			return new FixedNumberVector3(a.x * multi, a.y * multi, a.z * multi);
		}

		public static FixedNumberVector3 operator /(FixedNumberVector3 a, FixedNumber divider)
		{
			return new FixedNumberVector3(a.x / divider, a.y / divider, a.z / divider);
		}

		public static bool operator ==(FixedNumberVector3 a, FixedNumberVector3 b)
		{
			return a.x == b.x && a.y == b.y && a.z == b.z;
		}
		
		public static bool operator !=(FixedNumberVector3 a, FixedNumberVector3 b)
		{
			return a.x != b.x || a.y != b.y || a.z != b.z;
		}

		public static FixedNumber DotProduct(FixedNumberVector3 a, FixedNumberVector3 b)
		{
			return new FixedNumber(a.x * b.x + a.y * b.y + a.z * b.z);
		}

		public static FixedNumberVector3 CrossProduct(FixedNumberVector3 a, FixedNumberVector3 b)
		{
			return new FixedNumberVector3( a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
		}
		
		public FixedNumber SqMagnitude()
		{
			return new FixedNumber(x * x + y * y + z * z);
		}

		public FixedNumber Magnitude()
		{
			return FixedNumber.SquareRoot(SqMagnitude());
		}

		public FixedNumberVector3 normalized
		{
			get
			{
				if (Magnitude() > 0)
				{
					return new FixedNumberVector3(this.x / Magnitude(), this.y / Magnitude(), this.z / Magnitude());
				}
				else
				{
					return new FixedNumberVector3(0, 0, 0);
				}
			}
		}

		public void Normalize()
		{
			this.x /= Magnitude();
			this.y /= Magnitude();
			this.z /= Magnitude();
		}

		public Vector3 ToUnityVector3()
		{
			return new Vector3(x.ToFloat(), y.ToFloat(), z.ToFloat());
		}

		public static FixedNumber Angle(FixedNumberVector3 from, FixedNumberVector3 to)
		{
			//measured in degree
			FixedNumber dotProduct = FixedNumberVector3.DotProduct(from, to);
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
			return String.Format("x:{0}, y:{1}, z:{2}.", x.ToFloat(),y.ToFloat(),z.ToFloat());
		}
	}
}

