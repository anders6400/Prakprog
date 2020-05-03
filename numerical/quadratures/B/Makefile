all: out.txt

out.txt : main.exe
	mono $< 1>$@ 2>log

main.exe: main.cs matlib.dll
	mcs $(word 1, $^) -reference:matlib.dll -out:$@ 

LIBDIR = ../../matlib
SRC = $(LIBDIR)/matrix/matrix.cs
SRC += $(LIBDIR)/matrix/vector.cs
SRC += quad.cs
SRC += clenshaw_curtis.cs
SRC += quado8.cs

matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log *.svg