using System;
using System.IO;

namespace Game
{
    internal class DocsReader
    {
        private string Information = @"------------- Mathematical Patterns - Algrebra --------------

This application was build with focus on pattern generation.
Conducted from research of algrebra and polynomials.

To Break down the application algorithms is not really complex unless
you do not have the full understanding of algorithms and pattern designs.

The following will enlighten how the algorithm for the uncovering of 
the patterns was approached and reduced to computational sequencing.

For passion of mathematics, I deliberately chose linear algreba and 
patterns.

Let's break down the algorithms:

In patterns: we have few well known sequences which are closely related
to polynomials under the hood.

What could a polynomial be: well, In mathematics, a polynomial is an expression
consisting of indeterminates and coefficients that involves only the operations
of addition, substraction, multiplication and non-negative integer 
exponentiation of variables.

With example relating to the theory making up.

A polynomial would look like this: 5xy² + 3x + 9 with this being and equation 
assigned to its result. 

Example y = 5xy² + 3x + 9

In Patterns or sequences, this would be adjusted to a term and position written as

T(n) = 5n² + 3n + 9

The above being known as a quadratic sequence.
Solving the above is simply having the position as positive numbers or negative.

To convert the equation to an algorithm, all thats need is method used to have the equation;

For quadratic being: 
2a = difference
3a+b = first term of second layer
a+b+c = first term of the sequence

Becomes easy to break convert to an algorithm.

I hope by far the story telling is great.

For more detail breakdown, get the source code from:  


To enhance yourself with the application backend.

Thanks you for reading.

------------ Document End ----------------------------------";
        public string Print()
        {
            return Information;
        }
    }
}
