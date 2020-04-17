using System;
using static System.Console;
using static System.Math;
using System.IO;

public class jacobi{

public static int jacobi_cyclic(matrix A, vector e, matrix V){
    
    // Initializing parameters
    int sweeps = 0;
    int n = A.size1;
    bool changed;
    int p,q;
    double app, aqq, apq, theta, c, s, app1, aqq1, aip, aiq, api, aqi, vip, viq;
    

    for(int i = 0; i<n; i++){
        e[i] = A[i,i];
        V[i,i] = 1.0;
        for(int j=i+1; j<n; j++){
            V[i,j]=0;
            V[j,i]=0;
        }
    }
    do{
        sweeps++;
        changed = false;
        for(q=n-1; q>0; q--){
        for(p=0; p<q; p++){
        app = e[p];
        aqq = e[q];
        apq = A[p,q];
        theta = 0.5*Atan2(2*apq,aqq-app);
        c = Cos(theta);
        s = Sin(theta);
        app1 = Pow(c,2)*app-2*s*c*apq+Pow(s,2)*aqq;
        aqq1 = Pow(s,2)*app+2*s*c*apq+Pow(c,2)*aqq;
        if(app1!=app || aqq1!=aqq){
		    changed=true;
			e[p]=app1;
			e[q]=aqq1;
			A[p,q]=0.0;
			for(int i=0;i<p;i++){
				aip=A[i,p];
				aiq=A[i,q];
				A[i,p]=c*aip-s*aiq;
				A[i,q]=c*aiq+s*aip;
			}
			for(int i=p+1;i<q;i++){
				api=A[p,i];
				aiq=A[i,q];
				A[p,i]=c*api-s*aiq;
				A[i,q]=c*aiq+s*api;
			}
			for(int i=q+1;i<n;i++){
				api=A[p,i];
				aqi=A[q,i];
				A[p,i]=c*api-s*aqi;
				A[q,i]=c*aqi+s*api;
			}
			for(int i=0;i<n;i++){
				vip=V[i,p];
				viq=V[i,q];
				V[i,p]=c*vip-s*viq;
				V[i,q]=c*viq+s*vip;
			}// loop over i
        }// if
        }// loop over p
		}// loop over q
    } // do
    while(changed);
    return sweeps;
}// jacobi_cyclic


}