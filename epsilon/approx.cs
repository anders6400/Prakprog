using static System.Math;

public class Comparison{
	public static bool approx(double a, double b, double tau=1e-9, double epsilon=1e-9){
			bool check = false;
			if(Abs(a-b)<tau){check=true;}
			else if(Abs(a-b)/(Abs(a)+Abs(b))<epsilon/2){check=true;}
			return check;
	}
}
