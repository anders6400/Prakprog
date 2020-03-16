using System;
using static System.Math;
using static System.Console;


class main_qspline{
static void Main(){
    vector[] data = generatedata.read_data("out_dataB.txt");
    vector xs = data[0];
    vector ys = data[1];

    qspline qsplined = new qspline(xs,ys);

    double minx = xs[0];
    double maxx = xs[xs.size-1];
    double z;
    for(z = minx; z<maxx; z+=0.1){
        double qinterp = qsplined.spline(z);
        double integral = qsplined.integral(z);
        double derivative = qsplined.derivative(z);
        WriteLine($"{z} {qinterp} {integral} {derivative}");
    }
   
}
}