using System;
using static System.Math;

public partial class ode{

    // Embedded Runge-Kutta solver of the order 1-2
    static vector[] rkstep12(Func<double,vector,vector> f, double x, vector y, double h){
        vector k0 = f(x,y);
        vector k1 = f(x+h/2, y+(h/2)*k0);
        vector yh = y+k1*h;
        vector err = (k1-k0)*h;
        vector [] result = {yh, err};
        return result; 
    } // rkstep12

    // Embedded Runge-Kutta solver of the order 4-5
    static vector[] rkstep45(Func<double, vector, vector> f, double x, vector y, double h){
        vector k0 = f(x,y);
        vector k1 = f(x+0.25*h, y+0.25*k0*h);
        vector k2 = f(x+3.0/8*h, y+3.0/32*k0*h + 9.0/32*k1*h);
        vector k3 = f(x+12.0/13*h, y+1932.0/2197*k0*h-7200.0/2197*k1*h+7296.0/2197*k2*h);
        vector k4 = f(x+1.0*h, y+439.0/216*k0*h-8.0*k1*h+3680.0/513*k2*h-845.0/4104*k3*h);
        vector k5 = f(x+0.5*h, y-8.0/27*k0*h+2.0*k1*h - 3544.0/2565*k2*h+1859.0/4104*k3*h-11.0/40*k4*h);
                
        vector bk5 = 16.0/135*k0 + 6656.0/12825*k2 + 28561.0/56430*k3-9.0/50*k4 + 2.0/55*k5;
        vector bk4 = 25.0/216*k0+1408.0/2565*k2+2197.0/4104*k3-1.0/5*k4;
        vector yh = y + bk5*h;
        vector err = (bk5-bk4)*h;
        vector[] result = {yh,err};
        return result;
    } // rkstep45

} // partial class