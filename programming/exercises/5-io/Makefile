all: out-cmdline.txt out-file.txt out-stdout.txt

INPUT=input.txt

out-cmdline.txt: read-cmdline.exe $(INPUT) Makefile
	mono $< $$(cat $(INPUT)) >$@

out-file.txt: read-file.exe $(INPUT) Makefile
	mono $< $(INPUT) $@

out-stdout.txt: read-stdin.exe $(INPUT) Makefile
	mono $< <$(INPUT) >out-stdout.txt

read-cmdline.exe: read-cmdline.cs
	mcs $<

read-file.exe: read-file.cs
	mcs $<

read-stdin.exe: read-stdin.cs
	mcs $<


clean:
		rm -f out* *.exe