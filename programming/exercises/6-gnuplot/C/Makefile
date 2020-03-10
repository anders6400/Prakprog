all:complexgamma.svg

complexgamma.svg: complexgamma.gpi out_complexgamma.txt
	gnuplot $<

out_complexgamma.txt: main_complexgamma.exe
	mono $< > $@

main_complexgamma.exe: main_complexgamma.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR1 = ../A/Gamma
LIBDIR2 = ../../matlib
SRC1 = $(LIBDIR1)/gamma.cs
SRC2 = $(LIBDIR2)/complex/complex.cs
SRC2 += $(LIBDIR2)/complex/cmath.cs

matlib.dll: $(SRC1) $(SRC2)
	mcs $^ -target:library -out:$@

clean:
		rm -rf *.exe out* *.svg *.dll