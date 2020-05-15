all: out.txt higgs.svg

higgs.svg: higgs.gpi out.results.txt
	gnuplot $<

out.txt : main.exe
	mono $< 1>$@ 2>log 

main.exe: main.cs higgs.data matlib.dll
	mcs $(word 1, $^) -reference:matlib.dll -out:$@ 

LIBDIR = ../../matlib
SRC = $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += $(LIBDIR)/QRdecomp.cs
SRC += qnewton.cs


matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log *.svg