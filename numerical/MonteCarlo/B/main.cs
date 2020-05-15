using System;
using static System.Math;
using static System.Console;
using System.IO;

class main{
    public static void Main(){
    
    // Checking that the estimated error follows a 1/sqrt(N) dependence
    int N = 10000;                              // maximum limit
    Func<vector,double> f = (x) => Sin(x[0]);   // test function
    vector a = new vector(0.0);                 // lower limit
    vector b = new vector(PI);                  // upper limit
    double exact = 2;                           // result

    for(int i = 10; i<N; i+=10){
        double[] integral = montecarlo.plainmc(f,a,b,i);            // Performing the integral and error estimate
        WriteLine($"{i} {integral[1]} {Abs(integral[0]-exact)}");   // Writing out the values
    }

    } // Main

} // main