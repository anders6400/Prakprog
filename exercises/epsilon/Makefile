CSFLAGS = -warn:2 -optimize-

out.txt : main.exe
	mono $< > $@

main.exe : main.cs approx.dll
	mcs $(CSFLAGS) -reference:approx.dll $<

approx.dll : approx.cs
	mcs -target:library approx.cs

clean:
	rm -f out.txt main.exe
