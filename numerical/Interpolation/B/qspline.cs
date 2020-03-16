using System;
using static System.Console;
using static System.Math;

public class qspline {
	vector x,y,c,p;
	public qspline(vector xs,vector ys){
	x = xs;
	y = ys;
	
	// First calculating the p[i]:
	p = new vector(xs.size-1);
	for(int i=0; i<xs.size-1;i=i+1){
		p[i] = (y[i+1]-y[i])/(x[i+1]-x[i]);
	}

	// Then proceeding to c[i+1]  forwards looping

	c = new vector(xs.size-1);
	c[0]=0;
	for(int i=0; i<c.size-1;i=i+1){
		c[i+1]=(p[i+1]-p[i]-c[i]*(x[i+1]-x[i]))/(x[i+2]-x[i+1]);
	}

	// c[i] backwards looping
	c[c.size-1] = c[c.size-1]/2;

	for(int i =c.size-2; i>=0; i--){
		c[i]=(p[i+1]-p[i]-c[i+1]*(x[i+2]-x[i+1]))/(x[i+1]-x[i]);
	}

	/*b = new vector(xs.size-1);
	// finally the b coefficients
	for(int i=0; i<b.size; i=i+1){
		b[i] = p[i] - c[i]*(x[i+1]-x[i]);
	*/
	}
	
	
	public double spline(double z){
		int i = Bsearch(x,z);
		return y[i] + (p[i]-c[i]*(x[i+1]-x[i]))*(z-x[i])+c[i]*(z-x[i])*(z-x[i]);	
	}
	
	public double derivative(double z){
		int i = Bsearch(x,z);
		return (p[i]-c[i]*(x[i+1]-x[i]))+2*c[i]*(z-x[i]); 

	}
	public double integral(double z){
		int iz = Bsearch(x,z);
   		double intspline = 0.0;
   		for(int i=0;i<iz; i=i+1){
      		double delta_xi = x[i+1]-x[i];
      		intspline+=y[i]*delta_xi+0.5*(p[i]-c[i]*(x[i+1]-x[i]))*Pow(delta_xi,2)+1.0/3*c[i]*Pow(delta_xi,3);
   		}
   		
   		intspline += y[iz]*(z-x[iz])+0.5*(p[iz]-c[iz]*(x[iz+1]-x[iz]))*Pow(z-x[iz],2)+1.0/3*c[iz]*Pow(z-x[iz],3);
   		return intspline;
	}



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