#Shogi Bitboard Implementation
Implementating the shogi board state as bitboard, saves memory and also makes it a lot easier and efficient to calculate attacks.
Taking into account a given board state, different bitboards can be overlayed on top of it 
to achieve the end result of finding possible movements.

**Current board state**  
A| 000000000  
B| 000000000  
C| 000000000  
D| 000100000  --> 1 White Players piece   
E| 000111000  --> 3 Black Player's pieces
F| 000000000  
G| 000000000  
H| 000000000  
I .| 000000000  

**Potential Attacks for Black piece at 5e**  
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