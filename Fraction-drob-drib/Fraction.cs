using System;

namespace Fraction_drob_drib
{
	class Fraction
	{
		private int numerator;
		private int denominator;

		public int Numerator { get => numerator; set => numerator = value; }
		public int Denominator { get => denominator; set => this.denominator = value != 0 ? value : 1; }

		public void Print()
		{
			Console.WriteLine(numerator);
			Console.WriteLine("---");
			Console.WriteLine(denominator);
		}

		override public string ToString()
		{
			return " " + this.numerator + "\n---\n " + this.denominator;
		}

		public Fraction()
		{
		}

		public Fraction(Fraction fraction)
		{
			this.numerator = fraction.numerator;
			this.Denominator = fraction.denominator;
		}

		public Fraction(int numerator, int denominator)
		{
			this.numerator = numerator;
			Denominator = denominator;
		}

		public void Flip()
		{
			int temp = this.numerator;
			this.numerator = this.denominator;
			this.denominator = temp;
		}

		public Fraction Flip(Fraction fraction)
		{
			Fraction tmpFraction = new Fraction(fraction);
			tmpFraction.Flip();
			return tmpFraction;
		}
		/// <summary>
		/// Поиск наибольший общего делителя
		/// </summary>
		/// <param name="_numerator">Числитель</param>
		/// <param name="_denumerator">Знаменатель</param>
		/// <returns>Возвращает НОД или 0, если таковой не найден</returns>
		private  int Rduction()
		{
			this.numerator = Math.Abs(this.numerator);
			this.denominator = Math.Abs(this.denominator);
			while (this.denominator != 0 && this.numerator != 0)
			{
				if (this.numerator % this.denominator > 0)
				{
					var temp = this.numerator;
					this.numerator = denominator;
					this.denominator = temp % this.denominator;
				}
				else break;
			}
			
		}
		public Fraction Add(Fraction fraction)
		{
			/*
			 2        4    2*5 + 4*3   
			---   +   --- = ---------
			 3        5      15
			 */
		  int commonDenominator = this.denominator * fraction.denominator;
		  int commonNumerator = this.numerator * fraction.denominator + fraction.numerator * this.denominator;
		  return new Fraction(commonNumerator, commonDenominator);
		}

		public static Fraction Add(Fraction fraction1, Fraction fraction2)
		{
			int commonDenominator = fraction1.denominator * fraction2.denominator;
			int commonNumerator = fraction1.numerator * fraction2.denominator + fraction2.numerator * fraction1.denominator;
			return new Fraction(commonNumerator, commonDenominator);
		}

		public static Fraction Subtract(Fraction fraction1, Fraction fraction2)
		{
			int commonDenominator = fraction1.denominator * fraction2.denominator;
			int commonNumerator = fraction1.numerator * fraction2.denominator - fraction2.numerator * fraction1.denominator;
			return new Fraction(commonNumerator, commonDenominator);
		}

		public static Fraction Multiply(Fraction fraction1, Fraction fraction2)
		{
			int commonDenominator = fraction1.denominator * fraction2.denominator;
			int commonNumerator = fraction1.numerator * fraction2.numerator;
			return new Fraction(commonNumerator, commonDenominator);
		}
		public static Fraction Division(Fraction fraction1, Fraction fraction2)
		{
			if (fraction2.numerator == 0)
			{
				throw new DivideByZeroException();
			}
			return new Fraction(fraction1.numerator * fraction2.denominator,
				fraction1.denominator * fraction2.numerator);
		}

		//Перегрузка операторов + ; - ; * ; / 

		public static Fraction operator +(Fraction fraction1, Fraction fraction2)
	   => new Fraction(fraction1.numerator * fraction2.denominator + fraction2.numerator * fraction1.denominator, fraction1.denominator * fraction2.denominator);

		public static Fraction operator- (Fraction fraction1, Fraction fraction2)
		{
			int commonDenominator = fraction1.denominator * fraction2.denominator;
			int commonNumerator = fraction1.numerator * fraction2.denominator - fraction2.numerator * fraction1.denominator;
			return new Fraction(commonNumerator, commonDenominator);
		}

		public static Fraction operator *(Fraction a, Fraction b)
			=> new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);

		public static Fraction operator / (Fraction a, Fraction b)
		{
			if (b.numerator == 0)
			{
				throw new DivideByZeroException();
			}
			return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
		}
	}
}
