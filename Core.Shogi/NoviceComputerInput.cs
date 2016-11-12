using System.Collections.Generic;
using System.Linq;
using Core.Shogi.Pieces;

namespace Core.Shogi
{
    public class NoviceComputerInput : IBoardInput
    {
        private readonly Board _board;
        private readonly Player _player;

        private NoviceComputerInput()
        {
        }

        private NoviceComputerInput(Player player, Board board)
        {
            _player = player;
            _board = board;
        }

        public static IBoardInput CreateFor(Player player, Board board)
        {
            return new NoviceComputerInput(player, board);
        }

        public string AskForNextMove()
        {
            //TODO: Breaking Demeter's Law
            var playerPieces = _board.State.GetAllPiecesFromPlayer(_player);
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
            return new List<KeyValuePair<MovementValue, string>>
            {
                new KeyValuePair<MovementValue, string>(MovementValue.CheckMate, "3a")
            };
        }
    }
}