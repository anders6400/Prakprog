using System;
using static System.Console;
using static System.Math;
using static cmath;
class main{
	static int Main(){

		double x = 2;
		WriteLine($"Sqrt(2) = {Sqrt(x)}");
		
		complex I = new complex(0,1);
		WriteLine($"I.pow(I)={I.pow(I)}");
		WriteLine($"exp(i)={exp(I)}");
		WriteLine($"exp(i*pi)={exp(I*PI)}");
		WriteLine($"Sin(i*pi)={sin(I*PI)}");
	return 0;
	}
}
