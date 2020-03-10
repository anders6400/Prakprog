all: lngamma.svg

lngamma.svg: lngamma.gpi out_lngamma.txt 
	gnuplot $<

out_lngamma.txt: main_lngamma.exe
	mono $< > $@

main_lngamma.exe: main_lngamma.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = ../A/Gamma
SRC = $(LIBDIR)/gamma.cs

matlib.dll: $(SRC)
	mcs $< -target:library -out:$@

clean:
		rm -rf *.exe out* *.svg *.dll