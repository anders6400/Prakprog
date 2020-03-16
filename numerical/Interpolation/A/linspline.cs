using System;
using static System.Math;


public class linInterpolation{
public static double linterp(vector x, vector y, double z){
int i =Bsearch(x,z);
return y[i]+((y[i+1]-y[i])/(x[i+1]-x[i]))*(z-x[i]);
}


public static double linterpInteg(vector x, vector y, double z){
   int iz = Bsearch(x,z);
   double intspline = 0.0;
   for(int i=0;i<iz; i=i+1){
      double delta_yi = y[i+1]-y[i];
      double delta_xi = x[i+1]-x[i];
      double p_i = delta_yi/delta_xi;
      intspline+=y[i]*delta_xi+0.5*p_i*Pow(delta_xi,2);
   }
   double p_iz=(y[iz+1]-y[iz])/(x[iz+1]-x[iz]);
   intspline += y[iz]*(z-x[iz])+0.5*p_iz*Pow(z-x[iz],2);
   return intspline;

}

// Making a binary seach option
public static int Bsearch(vector x, double z) {
   int minNum = 0;
   int maxNum = x.size - 1;

   while (minNum <=maxNum) {
      int mid = (int) Floor((minNum + maxNum) / 2.0);
      if(x[mid]<z) {
         minNum = mid;
      } 
      else {
         maxNum = mid;
      }
      if(maxNum-minNum == 1) {
        return minNum;
      }
   }
   return -1;
}


}