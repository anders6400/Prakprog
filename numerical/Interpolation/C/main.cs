using System;
using static System.Math;
using static System.Console;


class main_cspline{
static void Main(){
    vector[] data = generatedata.read_data("out_dataC.txt");
    vector xs = data[0];
    vector ys = data[1];

    cspline csplined = new cspline(xs,ys);

    double minx = xs[0];
    double maxx = xs[xs.size-1];
    double z;
    for(z = minx; z<maxx; z+=0.1){
        double cinterp = csplined.spline(z);
        double integral = csplined.integral(z);
        double derivative = csplined.derivative(z);
        WriteLine($"{z} {cinterp} {integral} {derivative}");
    }
   
}
}