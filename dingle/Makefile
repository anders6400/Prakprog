CSFLAGS = -optimize+ -platform:arm

#.PHONEY:all
#all: out.txt
#	cat out.txt

out.txt : Constants.exe
	mono Constants.exe > out.txt
Constants.exe : Constants.cs
	mcs $(CSFLAGS) -out:Constants.exe Constants.cs
clean:
	rm --force out.txt Constants.exe
