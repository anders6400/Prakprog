using System;
using static System.Console;
using static System.Math;

public class cspline {
	vector x,y,b,c,d;
	public cspline(vector xs,vector ys){
	x = xs;
	y = ys;
	
	// First calculating the p[i]:
	vector dx = new vector(xs.size-1);
    vector dy = new vector(xs.size-1);
    vector p = new vector(xs.size-1);
	
    for(int i=0; i<xs.size-1;i=i+1){
        dx[i]=x[i+1]-x[i];
        dy[i]=y[i+1]-y[i];
		p[i] = dy[i]/dx[i];
	}

    vector D, Q, B; // diagonal, sup-diagonal, below-diagonal values
    D = new vector(x.size);
    D[0] = 2; D[x.size-1]=2;
    for(int i=0; i<x.size-2;i++){
        D[i+1]=2*dx[i]/dx[i+1]+2;
    }

    Q = new vector(x.size-1);
    Q[0]=1;
    for(int i=0; i<x.size-2;i++){
        Q[i+1]=dx[i]/dx[i+1];
    }

        
    B = new vector(x.size);
    B[0]=3*p[0];
    B[x.size-1]=3*p[x.size-2];
	for(int i=0; i<x.size-2;i++){
        B[i+1]=3*(p[i]+p[i+1]*dx[i]/dx[i+1]);
    }

    for(int i=1; i<x.size;i++){
        D[i]-=Q[i-1]/D[i-1];
        B[i]-=B[i-1]/D[i-1];
    }

    // Linear coefficient b
    b = new vector(xs.size);
	b[x.size-1]=B[x.size-1]/D[x.size-1];
	for(int i=x.size-2; i>=0; i--){
		b[i] = (B[i]-Q[i]*b[i+1])/D[i];
    }
        
    // Then proceeding to quadratic and cubic coefficients

	c = new vector(xs.size-1);
	d = new vector(xs.size-1);
	for(int i=0; i<x.size-1;i=i+1){
        c[i]=(-2*b[i]-b[i+1]+3*p[i])/dx[i];
        d[i]=(b[i]+b[i+1]-2*p[i])/(dx[i]*dx[i]);
	}

	}
		
	public double spline(double z){
		int i = Bsearch(x,z);
		return y[i] + b[i]*(z-x[i])+c[i]*(z-x[i])*(z-x[i])+d[i]*(z-x[i])*(z-x[i])*(z-x[i]);	
	}
	
	public double derivative(double z){
		int i = Bsearch(x,z);
		return b[i]+2*c[i]*(z-x[i])+3*d[i]*(z-x[i])*(z-x[i]); 

	}
	public double integral(double z){
		int iz = Bsearch(x,z);
   		double intspline = 0.0;
   		for(int i=0;i<iz; i=i+1){
      		double delta_xi = x[i+1]-x[i];
      		intspline+=y[i]*delta_xi+0.5*b[i]*Pow(delta_xi,2)+1.0/3*c[i]*Pow(delta_xi,3)+1.0/4*d[i]*Pow(delta_xi,4);
   		}
   		
   		intspline += y[iz]*(z-x[iz])+0.5*b[iz]*Pow(z-x[iz],2)+1.0/3*c[iz]*Pow(z-x[iz],3)+1.0/4*d[iz]*Pow(z-x[iz],4);
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