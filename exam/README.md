My student number is: 201607909

The last two digits are X = 09

My exam question is thus i = X mod N = 9 mod 22 = 9

The title of the assignment is "Bi-linear interpolation on a rectilinear grid in two dimensions"

-------------------------------------------------------------------------------------------------

Structure:

- bilin.cs: Contains the bi-linear interpolation routine. The algorithm used is the one found on
https://en.wikipedia.org/wiki/Bilinear_interpolation#Algorithm 

- main.cs: Contains the instruction to check if the bi-linear interpolation routine works as
intended. Furthermore it compares the interpolated value with the actual value.

- out.txt: Contains output of our main.cs file. It gives the interpolated value of a random point
within our 2D grid. The functions defined on the 2D grid is cos(x)*sin(y) and the Rosenbrock 
function.

- matlib: Folder that contains the library used throughout the course. The important codes for
this project are matrix.cs and vector.cs
