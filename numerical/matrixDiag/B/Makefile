all: out.txt plotB1.svg plotB2.svg

plotB2.svg: plotB2.gpi out.dataB2.txt
	gnuplot $<

plotB1.svg: plotB1.gpi out.dataB1.txt
	gnuplot $<

out.txt : mainB.exe
	mono $< >$@

mainB.exe: mainB.cs matlib.dll
	mcs $(word 1, $^) -reference:matlib.dll -out:$@ 


LIBDIR = ../../matlib
SRC = $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += ../../LinEquations/QRdecomp.cs
SRC += jacobiAlg.cs
SRC += jacobirow.cs


matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log *.svg