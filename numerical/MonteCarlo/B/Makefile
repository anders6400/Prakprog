all: out.txt plotB.svg

plotB.svg: plotB.gpi out.txt
	gnuplot $<


out.txt : main.exe
	mono $< 1>$@ 2>log

main.exe: main.cs matlib.dll
	mcs $(word 1, $^) -reference:matlib.dll -out:$@ 

LIBDIR = ../../matlib
SRC = $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/QRdecomp.cs
SRC += $(LIBDIR)/complex/cmath.cs
SRC += $(LIBDIR)/complex/complex.cs
SRC += mc.cs
SRC += gamma.cs

matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log *.svg