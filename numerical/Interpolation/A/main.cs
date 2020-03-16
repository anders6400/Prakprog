using System;
using static System.Math;
using static System.Console;
using static linInterpolation;

class main_linspline{
static void Main(){
    vector[] data = generatedata.read_data("out_dataA.txt");
    vector xs = data[0];
    vector ys = data[1];

    double minx = xs[0];
    double maxx = xs[xs.size-1];
    double z;
    for(z = minx; z<maxx; z+=0.1){
        double lspline = linterp(xs,ys,z);
        double integral = linterpInteg(xs,ys,z);
        WriteLine($"{z} {lspline} {integral}");
    }
   
  

}

}