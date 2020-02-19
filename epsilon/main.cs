using static System.Console;
using static System.Math;
class main{
	static int Main(){
		int i=0;
		int max=int.MaxValue/2; 
	/*	while(i+1>i) {i++;}
		Write("my max int = {0}\n",i);
		Write("My max val = "+int.MaxValue+"\n");

		
		while(i-1<i) {i++;}
		Write("my min. int = {0}\n",i);
		Write("My min. val = "+int.MinValue+"\n");

		double x=1;
		while(1+x!=1){x/=2;}
		Write("Epsilon machine double = {0}\n",x);

		float y=1F;
		while((float)(1F+y) != 1F){y/=2;}
		Write("Epislon machine float = {0}\n",y);

		
		float float_sum_up=1F;
		for(i = 2; i<max;i++)float_sum_up+=1F/i;
		Write("float_sum_up={0}\n",float_sum_up);
	
		float float_sum_down=1F/max;
		for(i=max-1;i>0;i--)float_sum_down+=1F/i;
		Write("float_sum_down={0}\n",float_sum_down);
	
		double double_sum_up=1d;
		for(i = 2; i<max;i++)double_sum_up+=1d/i;
		Write("double_sum_up={0}\n",double_sum_up);

		double double_sum_down=1d/max;
		for(i=max-1;i>0;i--)double_sum_down+=1d/i;
		Write("double_sum_down={0}\n",double_sum_down);
	*/	
		double a=1;
		double b=1;
		bool Check = Comparison.approx(a,b);
		Write(Check+"\n");
	return 0;
	}

}
