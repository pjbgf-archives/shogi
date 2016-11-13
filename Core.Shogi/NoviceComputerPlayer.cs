using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using Core.Shogi.Pieces;

namespace Core.Shogi
{
    public class NoviceComputerPlayer : IBoardPlayer
    {
        private readonly Board _board;

        private NoviceComputerPlayer()
        {
        }

        private NoviceComputerPlayer(Player player, Board board)
        {
            Player = player;
            _board = board;
        }

        public static IBoardPlayer CreateFor(Player player, Board board)
        {
            return new NoviceComputerPlayer(player, board);
        }

        public Player Player { get; private set; }

        public string AskForNextMove()
        {
            //TODO: Breaking Demeter's Law
            var playerPieces = _board.State.GetAllPiecesFromPlayer(Player);
            var possibleMovements = CalculatePossibleMovements(playerPieces);
            var bestMovement = GetMovementSuggestion(possibleMovements);

            return bestMovement;
        }

        private static string GetMovementSuggestion(IEnumerable<KeyValuePair<MovementValue, string>> possibleMovements)
        {
            return possibleMovements.OrderByDescending(x => x.Key).Select(x => x.Value).First();
        }

        private static IEnumerable<KeyValuePair<MovementValue, string>> CalculatePossibleMovements(IEnumerable<Piece> playerPieces)
        {
            var possibleMovements = new List<KeyValuePair<MovementValue, string>>();
            foreach (var playerPiece in playerPieces)
            {
                var nonCalculatedMovements = playerPiece.GetPossibleMovements();
                foreach(var nonCalculatedMovement in nonCalculatedMovements)
                    possibleMovements.Add(new KeyValuePair<MovementValue, string>(MovementValue.Exposed, nonCalculatedMovement));
            }

            return possibleMovements;
        }
    }
}