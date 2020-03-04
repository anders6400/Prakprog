using System;
using static System.Console;
using static System.Math;
using static cmath;
class main{
	static int Main(){
/*	
		double x=1;
			char c='ø';			
		string s="hello";		
		Write("sin({0})={1}\n",x,Sin(x));
		Write($"sin({x})={Sin(x)}\n");
		int i=100;
		Write($"i={i}\n");
		double y=x*Exp(x);
		Write($"y={y} E={E}\n");
*/
		complex I = new complex(0,1);
		Write($"I*I={I*I}\n");
		Write($"sin(I)={sin(I)}\n");
		Write($"I.pow(I)={I.pow(I)}, exp(-PI/2)={Exp(-PI/2)}\n");
	return 0;
	}
}
