using System;
using static System.Math;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
public class errorf{

    public static void erf(double a, double b, double dx){
        
        Func<double,double> myerf = (x) => 2/Sqrt(PI)*Exp(-Pow(x,2));
        double result;
        for(double x=a;x<=b;x+=dx){
            //if(x<0){return -myerf(-x);}
            result=quad.o8av(myerf,0,x,acc:1e-6,eps:1e-6);
            WriteLine($"{x} {(result)}");
        }
    }


}