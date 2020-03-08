using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;

class Orbit{
static int Main(){
    
    // i
    // double a=0, b=8*PI, eps=0;
    // vector ya = new vector(1,0);

    // ii
    //double a=0, b=8*PI, eps=0;
    //vector ya = new vector(1,-0.5);

    // iii:    
    double a=0, b=8*PI, eps=0.01;
    vector ya = new vector(1,-0.5);
    OrbitEOM(a, ya, b, eps);
    
    return 0;
}

static void OrbitEOM(double a, vector ya, double b,double eps){
    Func<double, vector, vector> orbitODE= delegate(double x, vector y){
        return new vector(y[1],1+eps*y[0]*y[0]-y[0]);
    };

    List<double> xs=new List<double>();
	List<vector> ys=new List<vector>();

    ode.rk23(orbitODE,a,ya,b,xlist:xs,ylist:ys);
    for(int i=0;i<xs.Count;i++)
        WriteLine($"{xs[i]} {ys[i][0]}");
}
}