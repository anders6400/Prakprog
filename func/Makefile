out.txt: main.exe
	mono $< >$@

main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll


SRC = ../integration/quado8.cs
SRC += ../integration/quado4.cs
matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

clean: 
	rm -f *.dll *.exe out*