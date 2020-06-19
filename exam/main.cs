using System;
using static System.Math;
using static System.Console;
using System.IO;


class main{
static void Main(){

    int N = 200;                        // number of grid points
    double delta = 0.05;                // spacing between each grid point
    double[] xdata = new double[N];   
    double[] ydata = new double[N];

    for(int i=0; i<N; i++){             // Making a linspace such that we have gridsize of 10x10
        xdata[i]=i*delta;               // with a total of 200x200 grid points
        ydata[i]=i*delta;
    }
    
    // Defining a random function of two variables
    Func<double, double, double> cossin = delegate(double x, double y){
        double f = Cos(x)*Sin(y);
        return f;
    };
    
    Func<double, double, double> rosenbrock = delegate(double x, double y){
        double h = (1-x)*(1-x)+100*(y-x*x)*(y-x*x);
            return h;
        };

    // Matrix containing the values of the tabulated function f and h.
    matrix F = new matrix(N,N);
    matrix H = new matrix(N,N);
    for(int i=0; i<N; i++){
        for(int j=0; j<N; j++){
            F[i,j] = cossin(i*delta,j*delta);
            H[i,j] = rosenbrock(i*delta,j*delta);
        } // for
    } // for
    //F.print();

    int n = 1;                          // number of 2D points we want to have interpolated
    var rnd = new Random();                          
    double[] px = new double[n];     
    double[] py = new double[n];     
    for(int i=0; i<n; i++){             // Generating n number of random points within our grid size 
        px[i]=10*rnd.NextDouble();      // which we want the interpolated values for
        py[i]=10*rnd.NextDouble();
    }
    
    vector _px = px;
    vector _py = py;
    matrix z1 = new matrix(n,n);        // defining the matrix z that will contain our interpolated values
    matrix z2 = new matrix(n,n);
    for(int i=0; i<n; i++){
        for(int j=0; j<n; j++){
            z1[i,j] = biLinearint.bilinear(xdata, ydata, F, px[i], py[j]);   // z(x_i,y_j)
            z2[i,j] = biLinearint.bilinear(xdata, ydata, H, px[i], py[j]);
            // looping over each x and y point and calculating the bilinear interpolated value
        } // for
    } // for
    Console.WriteLine("Bi-linear interpolation on a rectilinear grid in two dimensions");
    Console.WriteLine("\nThe goal is to find the function value at a random point within our 2D grid");
    Console.WriteLine($"The size of our 2D grid will be {N*delta}x{N*delta}");
    Console.WriteLine("The functions defined on our grid is cos(x)*sin(y) and the Rosenbrock function");
    Console.WriteLine("\nThe x and y coordinate that we want an interpolated value for is:");
    _px.print("x\t=");
    _py.print("y\t=");
    z1.print("\nInterpolated value z(x,y) for the cos(x)*sin(x):");
    WriteLine("Analytical result:");
    WriteLine("z(x,y) = {0:g5}", Cos(_px[0])*Sin(_py[0]));
    z2.print("\nInterpolated value z(x,y) for the Rosenbrock function:");
    WriteLine("Analytical result:");
    WriteLine("z(x,y) = {0:g5}", (1-_px[0])*(1-_px[0])+100*(_py[0]-_px[0]*_px[0])*(_py[0]-_px[0]*_px[0]));

} // Main

} // main