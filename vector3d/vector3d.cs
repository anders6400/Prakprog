using System;
public struct vector3d{
	public double x,y,z;
	
	//Constructor
	public vector3d(double a,double b,double c){
		x=a;
		y=b;
		z=c;
	}
	
	//Operator
	public static vector3d operator *(vector3d v, double c){
		return new vector3d(c*v.x,c*v.y,c*v.z);
	}
	
	public static vector3d operator *(double c, vector3d v){
		return new vector3d(c*v.x,c*v.y,c*v.z);
	}

	public static vector3d operator +(vector3d u, vector3d v)
	{
		return new vector3d(u.x+v.x, u.y+v.y, u.z+v.z);
	}

	public static vector3d operator -(vector3d u, vector3d v)
	{
		return new vector3d(u.x-v.x, u.y-v.y, u.z-v.z);
	}
	
	//Methods
	public static double dotproduct(vector3d u, vector3d v){
		return u.x*v.x + u.y*v.y + u.z*v.z;	
	}
	
	public static vector3d vectorproduct(vector3d u, vector3d v){
		return new vector3d(u.y*v.z - u.z*v.y, -u.x*v.z + u.z*v.x, u.x*v.y - u.y*v.x);	
	}

	public double magnitude(){
	return Math.Sqrt(dotproduct(this,this));	
	}


	//Override to string
	public override string ToString(){
		return x+", "+y+", "+z;
	}

	
}
