all: out.txt

out.txt : main.exe
	mono $< 1>$@ 2>log

main.exe: main.cs matlib.dll
	mcs $(word 1, $^) -reference:matlib.dll -out:$@ 

LIBDIR = matlib/matrix
SRC = $(LIBDIR)/matrix.cs
SRC += $(LIBDIR)/vector.cs
SRC += bilin.cs

matlib.dll : $(SRC)
	mcs -target:library -out:$@ $^

clean: 
		rm -f *.txt *.dll *.exe *log *.svg