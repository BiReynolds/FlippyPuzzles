# FlippyPuzzles
"Flippy Puzzles" are a 2D equivalent of "Twisty Puzzles" like the Rubik's Cube and related puzzles.  This repository provides a simple API and some attempts at constructing an optimal solver for such puzzles

## Example: The Standard 3x3 Flippy Puzzle
Flippy Puzzles can come in any whole number of dimensions, and there are at least two intuitive move-sets one can consider when looking into them.  Before we get into full generality, let's look at a good example: the "standard" 3x3 Flippy Puzzle

The solved state of this puzzle is just a 3x3 grid with each square labeled with the numbers 0-8 (in order).  We zero-index the labels because it makes both the math and the code a bit easier.  
| | | |
| --- | --- | --- |
| 0 | 1 | 2 |
| 3 | 4 | 5 |
| 6 | 7 | 8 |

There are 3 types of moves for any Flippy Puzzle: **row-flips**, **column-flips**, and **rotations**.  These are fairly self-explanatory, but we will look at an example of each 

### Row-Flips
A row-flip takes a row and, well, flips it.  Since there are N rows in the NxN case, there are exactly N such moves you can perform on the puzzle.  We use the notation R[k] to denote the move which flips row k.  Below, you can see the result of applying move R[1] to the solved state of the 3x3 puzzle (remember that the rows are zero-indexed, so row 1 is the middle row of the puzzle).

| | | |
| --- | --- | --- |
| 0 | 1 | 2 |
| 5 | 4 | 3 |
| 6 | 7 | 8 |

### Column-Flips
Given what a row-flip is, a column-flip follows pretty easily.  We use the notation C[k] to denote the move which flips column k, and below you can see the result of applying the move C[1] to the solved state of the 3x3 puzzle.
| | | |
| --- | --- | --- |
| 0 | 7 | 2 |
| 3 | 4 | 5 |
| 6 | 1 | 8 |

### Rotations
Finally, a rotation is a rotation of the puzzle.  There are 2 or 3 of these (depending if you want to include a 180 degree rotation as a single move or as two applications of either of the other rotations), regardless of the dimensions of the puzzle.  We denote the clockwise rotation of the puzzle by S[0] and the counter-clockwise rotation of the puzzle by S[1].  If we include the full rotation of the puzzle, we denote that move by S[2].  Below, you can see the result of applying the move S[0] to the solved state of the 3x3 puzzle. 
| | | |
| --- | --- | --- |
| 6 | 3 | 0 |
| 7 | 4 | 1 |
| 8 | 5 | 2 |

## Other Terminology
### Permutations vs States vs Scrambles
These terms are very closely related - so much so that it can be easy to lump them all together in your brain.  However, keeping the difference in mind is essential to studying these puzzles, as well as other "permutation puzzles" like the Rubik's Cube.  
- A **permutation**, for our purposes, is a function which rearranges the elements of an array.  More precisely, it is a bijective function from our set of pieces back into our set of pieces.  Each of our moves is an example of a permutation
- A **state** is the term we use to denote a particular arrangement of pieces of our puzzle.  All of the grids we've included above are what we call states.  It is easy to think of permutations and the effect they have on our solved state as being the same, but *this is not true*.  More accurately, **permutations transition the puzzle from one state to another**.  
- A **scramble** is an ordered sequence of moves.  Every scramble has a corresponding **permutation**, which describes the effect of performing those moves in that order on our puzzle.  However, a scramble is *not* the same as the permutation it resolves to.  

One way to help make this clear is to note that there are only finitely many permutations for a given set of pieces (in fact, there are N! for a puzzle with N pieces).  However, there are infinitely many scrambles, since we can just keep applying moves until the sun burns out.  This also helps lead us to another key relationship between scrambles and permutations: while every scramble has exactly one corresponding permutation, a permutation may have many (indeed, infinitely many) scrambles which end up corresponding to it.  This is at the heart of what makes these puzzles both difficult and interesting.  We can apply millions of moves to one of these puzzles, and it may take only a handful to restore it to the solved state!