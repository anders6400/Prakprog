using System;
using static System.Math;
using static System.Console;
using System.IO;

class main{
    public static void Main(){

        WriteLine("Problem A:");

        Func<vector, double> cos = (x) => Pow(Cos(x[0]),2);
        vector a = new vector(0.0);
        vector b = new vector(PI);
        int N = 10000;
        double[] integral = montecarlo.plainmc(cos, a, b, N);
        double exact = PI/2;
        WriteLine($"\nFirst a test on an easy integral:");
        WriteLine($"MC integral of Cos^2(x) from {a[0]} to {b[0]}");
        WriteLine($"Numerical result:           {integral[0]}");
        WriteLine($"Analytical result:          {exact}");
        WriteLine($"Estimated error:            {integral[1]}");
        WriteLine($"Actual error:               {Abs(exact-integral[0])}");
        if(Abs(exact-integral[0])<integral[1]) WriteLine("Test Passed!");
        else WriteLine("Test Failed!");
        
        WriteLine($"\nMoving on to a move advanced integral:");
        Func<vector, double> advanced = (x) => 1.0/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]))*1/(Pow(PI,3));
        N = 50000;
        a = new vector(0.0,0.0,0.0);
        b = new vector(PI,PI,PI);
        double[] integral2 = montecarlo.plainmc(advanced,a,b,N);
        double exact2 = Pow(math.gamma(0.25),4)/(4*Pow(PI,3));        
        WriteLine($"MC integral of (1-cos(x)cos(y)cos(z))^(-1)");
        WriteLine($"Integration limits of each component:");
        a.print("a = ");
        b.print("b = ");
        WriteLine($"Numerical result:           {integral2[0]}");
        WriteLine($"Analytical result:          {exact2}");
        WriteLine($"Estimated error:            {integral2[1]}");
        WriteLine($"Actual error:               {Abs(exact2-integral2[0])}");
        if(Abs(exact2-integral2[0])<integral2[1]) WriteLine("Test Passed!");
        else WriteLine("Test Failed!");



    } // Main

} // main