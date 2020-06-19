using System;
using static System.Math;


public class biLinearint{
public static double bilinear(double[] x, double[] y, matrix F, double px, double py){
// Calculates a single interpolated value
// algorithm taken from wikipedia.org//wiki/Bilinear_interpolation
    double zval = 0D;
    for(int i=0; i < x.Length-1; i++){
        for(int j=0; j<y.Length-1; j++){
            if(px >= x[i] && px<x[i+1] && py>=y[j] && py<y[j+1]){
                zval = F[i,j]*(x[i+1]-px)*(y[j+1]-py)/(x[i+1]-x[i])/(y[j+1]-y[j])+
                    F[i+1,j]*(px-x[i])*(y[j+1]-py)/(x[i+1]-x[i])/(y[j+1]-y[j])+
                    F[i,j+1]*(x[i+1]-px)*(py-y[j])/(x[i+1]-x[i])/(y[j+1]-y[j])+
                    F[i+1,j+1]*(px-x[i])*(py-y[j])/(x[i+1]-x[i])/(y[j+1]-y[j]);
            } // if
        } // for
    } // for

    return zval;
} // bilinear

public static double[] bilinear(double[] x, double[] y, matrix F, double[] xvals, double[] yvals){
// Calculates multiple interpolated values
    double[] zvals = new double[xvals.Length];
    for(int i=0; i<xvals.Length; i++){
        zvals[i] = bilinear(x, y, F, xvals[i], yvals[i]);
    }
    return zvals;
} // bilinear

} // class
