all: out.txt plotA_rk12.svg plotA_rk45.svg

plotA_rk45.svg: plotA_rk45.gpi
	gnuplot $<

plotA_rk12.svg: plotA_rk12.gpi
	gnuplot $<

out.txt : main.exe
	mono $< 1>$@ 2>log

main.exe: main.cs matlib.dll
	mcs $(word 1, $^) -reference:matlib.dll -out:$@ 

LIBDIR = ../../matlib
SRC = $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += rkstepXY.cs
SRC += driver.cs

matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log *.svg