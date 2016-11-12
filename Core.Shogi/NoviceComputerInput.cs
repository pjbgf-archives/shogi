using System.Collections.Generic;
using System.Linq;
using Core.Shogi.Pieces;

namespace Core.Shogi
{
    public class NoviceComputerInput : IBoardInput
    {
        private readonly BoardState _boardState;
        private readonly Player _player;

        public NoviceComputerInput(BoardState boardState, Player player)
        {
            _boardState = boardState;
            _player = player;
        }

        public string AskForNextMove()
        {
            var playerPieces = _boardState.GetAllPiecesFromPlayer(_player);
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