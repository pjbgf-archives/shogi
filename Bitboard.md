Shogi Bitboard Implementation
=============================
Implementating the shogi board state as bitboard, saves memory and also makes it a lot easier and efficient to calculate attacks and make movements.
Taking into account a given board state, different bitboards can be overlayed on top of it through binary operations
to achieve the end result of finding potential movements.

Finding out attack movements
---------------
The example below shows how to calculate the best attack movement for a given piece. It will go through legal movements

**Bitboard with the current board state.**  
A| 000000000  
B| 000000000  
C| 000000000  
D| 000100000  --> 1 White Player's piece   
E| 000111000  --> 3 Black Player's pieces  
F| 000000000  
G| 000000000  
H| 000000000  
I .| 000000000  

**Bitboard with Potential Attacks for a Black Golden General piece located at 5e.**  
A| 000000000  
B| 000000000  
C| 000000000  
D| 000111000  
E| 000101000  
F| 000010000  
G| 000000000  
H| 000000000  
I .| 000000000  

**Negative of Black Pieces**  
A| 111111111  
B| 111111111  
C| 111111111  
D| 111111111    
E| 111000111  
F| 111111111  
G| 111111111  
H| 111111111  
I .| 111111111  

**Legal movements for 5e** (Result of Potential Attacks for piece at 5e AND Negative of Black Pieces)  
Shogi does not allow two pieces to be placed in the same cell. Also, a player cannot capture their own pieces, therefore in order to calculate potential movements a binary AND needs to be executed:

A| 000000000  
B| 000000000  
C| 000000000  
D| 000111000  
E| 000000000  
F| 000010000  
G| 000000000  
H| 000000000  
I .| 000000000 

**Legal movement capturing enemy piece**  
Overlaying the previous bitboard with the actual location for white pieces, would result on all legal movements that would capture a piece from White:

A| 000000000  
B| 000000000  
C| 000000000  
D| 000100000  
E| 000000000  
F| 000000000  
G| 000000000  
H| 000000000  
I .| 000000000 



For moving pieces, the approach is quite similar.

**Bitboard with the current board state.**  
A| 000000000  
B| 000000000  
C| 000000000  
D| 000100000  --> 1 White Player's piece   
E| 000111000  --> 3 Black Player's pieces  
F| 000000000  
G| 000000000  
H| 000000000  
I .| 000000000 

**Position where the piece is currently on**  
A| 000000000  
B| 000000000  
C| 000000000  
D| 000000000  
E| 000010000  
F| 000000000  
G| 000000000  
H| 000000000  
I .| 000000000  

**Flip bits of the position the piece is currently on**  
```c#
var inversionPiecePostion = ~currentPosition;
```  
A| 111111111  
B| 111111111  
C| 111111111  
D| 111111111  
E| 111101111  
F| 111111111  
G| 111111111  
H| 111111111  
I .| 111111111  

**Current board state AND Inversion of the position the piece is currently on**  
```c#
var boardWithoutOriginalPiece = currentState & inversionPiecePostion;
```  
A| 000000000  
B| 000000000  
C| 000000000  
D| 000100000  --> 1 White Player's piece   
E| 000101000  --> 2 Black Player's pieces  
F| 000000000  
G| 000000000  
H| 000000000  
I .| 000000000 

**Target board position**  
A| 000000000  
B| 000000000  
C| 000000000  
D| 000100000  
E| 000000000  
F| 000000000  
G| 000000000  
H| 000000000  
I .| 000000000 

**Final board**  
```c#
var boardAfterMovement = boardWithoutOriginalPiece ^ targetPosition;
```  
A| 000000000  
B| 000000000  
C| 000000000  
D| 000100000  --> 1 Black Player's piece   
E| 000101000  --> 2 Black Player's pieces  
F| 000000000  
G| 000000000  
H| 000000000  
I .| 000000000 