using System;

namespace Fraction_drob_drib
{
	class Program
	{
		static void Main(string[] args)
		{
			Fraction fraction = new Fraction();
			fraction.Numerator = 2;
			fraction.Denominator = 3;
			fraction.Print();

			Fraction fraction2 = new Fraction(3, 0);
			fraction2.Print();

			fraction2.Flip();
			fraction2.Print();

			Fraction fraction3 = fraction.Flip(fraction);
			fraction3.Print();
			fraction.Print();

			Fraction fraction4 = fraction.Add(fraction3);
			fraction4.Print();

			fraction3 = Fraction.Add(fraction2, fraction4);
			fraction3.Print();

			Fraction fraction5 = Fraction.Multiply(new Fraction(2, 5), new Fraction(5, 4));
			fraction5.Flip();
			fraction5.Print();

			Console.WriteLine(fraction5.ToString());

			Int32 q = new Int32();
			q = 5;
			Console.WriteLine(q.ToString());
		}
	}
}
