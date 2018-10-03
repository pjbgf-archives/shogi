using Core.Shogi.BitVersion;

namespace Core.Shogi.Adapters.Console
{
    public class BoardConsoleRender : IBoardRender
    {
        public void Refresh(IBoardState boardState)
        {
            PrintHeader();
            PrintRow("a", "9a", "8a", "7a", "6a", "5a", "4a", "3a", "2a", "1a", boardState);
            PrintRow("b", "9b", "8b", "7b", "6b", "5b", "4b", "3b", "2b", "1b", boardState);
            PrintRow("c", "9c", "8c", "7c", "6c", "5c", "4c", "3c", "2c", "1c", boardState);
            PrintRow("d", "9d", "8d", "7d", "6d", "5d", "4d", "3d", "2d", "1d", boardState);
            PrintRow("e", "9e", "8e", "7e", "6e", "5e", "4e", "3e", "2e", "1e", boardState);
            PrintRow("f", "9f", "8f", "7f", "6f", "5f", "4f", "3f", "2f", "1f", boardState);
            PrintRow("g", "9g", "8g", "7g", "6g", "5g", "4g", "3g", "2g", "1g", boardState);
            PrintRow("h", "9h", "8h", "7h", "6h", "5h", "4h", "3h", "2h", "1h", boardState);
            PrintRow("i", "9i", "8i", "7i", "6i", "5i", "4i", "3i", "2i", "1i", boardState);
            PrintFooter();
        }

        public void InvalidOperation(BoardResult boardResult)
        {
            System.Console.WriteLine($"Invalid movement: {System.Enum.GetName(typeof(BoardResult), boardResult)}");
        }

        private void PrintFooter()
        {
            System.Console.WriteLine("-----------------------------------------");
        }

        private static void PrintHeader()
        {
            System.Console.WriteLine("-------------------------------------");
            System.Console.WriteLine($"| 9 | 8 | 7 | 6 | 5 | 4 | 3 | 2 | 1 |  ");
        }

        private static void PrintRow(string rowName, string column1, string column2, string column3, string column4, string column5, string column6, string column7, string column8, string column9, IBoardState boardState)
        {
            System.Console.WriteLine("-----------------------------------------");
            System.Console.WriteLine($"| {GetPieceShortName(column1, boardState)} | {GetPieceShortName(column2, boardState)} | {GetPieceShortName(column3, boardState)} | {GetPieceShortName(column4, boardState)} | {GetPieceShortName(column5, boardState)} | {GetPieceShortName(column6, boardState)} | {GetPieceShortName(column7, boardState)} | {GetPieceShortName(column8, boardState)} | {GetPieceShortName(column9, boardState)} | {rowName} ");
        }

        private static char GetPieceShortName(string pieceLocation, IBoardState boardState)
        {
            var piece = boardState.GetPiece(pieceLocation);
            if (piece != null)
                return piece.ShortName;

            return ' ';
        }
    }
}