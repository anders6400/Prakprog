using System;
using System.IO;
using static System.Console;
using static System.Math;


class main{

static void Main(){


Func<double, double>[] fs = new Func<double, double>[]{t => 1, t => t};
vector xs = new vector(new double[]{1,2,3,4,6,9,10,13,15});
vector ys = new vector(new double[]{117,100,88,72,53,29.5,25.2,15.2,11.1});
vector dys = 0.05*ys;
int n = xs.size;
vector x = new vector(n);
vector y = new vector(n);
vector dy = new vector(n);

for(int i=0; i<n; i=i+1){
    x[i]=xs[i];
    y[i] = Log(ys[i]);
    dy[i] = dys[i]/ys[i];
}


OrdLeastSquares myfit = new OrdLeastSquares(x, y, dy, fs);

// Exercise A

vector c = myfit.fit(); // calculating c coefficient

double lambda = c[1];
double T = -Log(2.0)/lambda;

WriteLine("--------Problem A--------");
WriteLine("\nCalculating the relevant parameters for Least Squares Fit:");
c.print("\nc = ");
WriteLine("\nThe half-life time of ThX from my fit has been found to be: ");
WriteLine($"\nT_(1/2) = {T:f2} days");

// Creating document with fitted results
StreamWriter results = new StreamWriter("results.txt");

for(double t = 1; t<=15; t=t+0.25){
    results.WriteLine($"{t} {Exp(c[0])*Exp(c[1]*t)}");
}
results.Close();

// Creating document with data
StreamWriter data = new StreamWriter("data.txt");

for(int i=0; i<xs.size; i=i+1){
    data.WriteLine($"{x[i]} {ys[i]} {dys[i]}");
}
data.Close();


// Exercise B
WriteLine("\n--------Problem B--------");

matrix cov = myfit.covMat();
cov.print("\nCovariance Matrix: ");

vector unc = myfit.calUncertainty();
unc.print("\nUncertainty on fitting parameters = ");

double unclambda = Sqrt(cov[1,1]);
double dT = Abs(unclambda/Pow(lambda,2));
WriteLine("\nCalculating the half-life time of ThX with uncertainty: ");
WriteLine($"\nT_(1/2) = {T:f2} +- {dT:f2} days");
WriteLine("\nThis result is not far away from the modern result of ThX which is known as Ra-224: ");
WriteLine("\nT_(1/2) = 3.6319(23) days");



StreamWriter resultsWithUnc = new StreamWriter("resultsWithUnc.txt");

for(double t = 1; t<=15; t=t+0.25){
    resultsWithUnc.WriteLine($"{t} {Exp(c[0])*Exp(c[1]*t)} {Exp(c[0]+unc[0])*Exp((c[1]+unc[1])*t)} {Exp(c[0]-unc[0])*Exp((c[1]-unc[1])*t)}");
}

resultsWithUnc.Close();


}
}