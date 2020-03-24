all: out.txt


out.txt: main.exe
	mono $< > $@ 2> log

main.exe: main.cs QRdecomp.cs matlib.dll
	mcs $< -reference:matlib.dll -out:$@ 


LIBDIR = ../matlib
SRC = $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += QRdecomp.cs

matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log