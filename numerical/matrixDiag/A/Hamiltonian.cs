using System;
using static System.Math;
public class Hamiltonian{
public static matrix boxHamilton(int n){
    double s=1.0/(n+1);
    matrix H = new matrix(n,n);
    for(int i=0;i<n-1;i++){
        matrix.set(H,i,i,-2);
        matrix.set(H,i,i+1,1);
        matrix.set(H,i+1,i,1);
    }
    matrix.set(H,n-1,n-1,-2);
    matrix.scale(H,-1/s/s);
    return H;
}//Hamilton

}