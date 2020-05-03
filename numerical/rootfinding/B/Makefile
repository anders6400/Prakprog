all: out.txt plotB.svg

plotB.svg: plotB.gpi
	gnuplot $<

out.txt : main.exe
	mono $< 1>$@ 2>log

main.exe: main.cs matlib.dll
	mcs $(word 1, $^) -reference:matlib.dll -out:$@ 

LIBDIR = ../../matlib
SRC = $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/driver.cs
SRC += $(LIBDIR)/rkstepXY.cs
SRC += $(LIBDIR)/QRdecomp.cs
SRC += newton.cs


matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log *.svg