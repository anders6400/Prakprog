using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;

class main{
static int Main(){
    
    Func<double, vector, vector> logisticf= delegate(double x, vector y){
        return new vector(y[0]*(1-y[0]),0);
    };
    double a=0, b=3;
    
    vector ya= new vector(0.5,0);

    List<double> xs=new List<double>();
	List<vector> ys=new List<vector>();

    ode.rk23(logisticf,a,ya,b,xlist:xs,ylist:ys);

    for(int i=0;i<xs.Count;i++){
        double trueVal=1/(1+Exp(-xs[i]));
        WriteLine($"{xs[i]} {ys[i][0]} {trueVal}");
    }
    return 0;
}

}