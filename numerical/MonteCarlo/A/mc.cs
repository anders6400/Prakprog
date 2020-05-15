using System;
using static System.Console;
using static System.Math;

public class montecarlo{

public static double[] plainmc(Func<vector,double> f, vector a, vector b, int N){
    Random rnd = new Random();
    double volume = 1;
    vector dx = b-a;
    for(int i = 0; i<a.size; i = i+1){
        volume*= dx[i];
    } // for

    vector x = new vector(a.size);
    double sum = 0;
    double squaresum = 0;

    for(int i = 0; i<N; i=i+1){
        for(int j=0; j<a.size; j=j+1){
            x[j] = a[j]+rnd.NextDouble()*dx[j];
        } // for
        double fx = f(x);
        sum += fx;
        squaresum += Pow(fx,2);        
    } // for
    double mean = sum/N;
    double std = Sqrt(squaresum/N-Pow(mean,2))/Sqrt(N);
    return new double[] {mean*volume, std*volume};

} // plainmc

} // montecarlo