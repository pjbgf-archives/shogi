using System.Collections.Generic;
using System.Linq;
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
            var opponentPlayerPieces =
                _board.State.GetAllPiecesFromPlayer(Player == Player.Black ? Player.White : Player.Black);
            var possibleMovements = CalculatePossibleMovements(playerPieces, opponentPlayerPieces);
            var bestMovement = GetMovementSuggestion(possibleMovements);

            return bestMovement;
        }

        private static string GetMovementSuggestion(IEnumerable<KeyValuePair<MovementValue, string>> possibleMovements)
        {
            return possibleMovements.OrderByDescending(x => x.Key).Select(x => x.Value).First();
        }

        private static IEnumerable<KeyValuePair<MovementValue, string>> CalculatePossibleMovements(
            IEnumerable<Piece> playerPieces, IEnumerable<Piece> opponentPlayerPieces)
        {
            var opponentPossibleMovements = GetOpponentNextMoves(opponentPlayerPieces);
            var valuePossibleMovements = ValuePossibleMovements(playerPieces, opponentPossibleMovements);

            return valuePossibleMovements;
        }

        private static List<KeyValuePair<MovementValue, string>> ValuePossibleMovements(IEnumerable<Piece> playerPieces, List<string> opponentPossibleMovements)
        {
            var possibleMovements = new List<KeyValuePair<MovementValue, string>>();
            foreach (var playerPiece in playerPieces)
            {
                foreach (var nonCalculatedMovement in playerPiece.PossibleMovements)
                {
                    var targetPosition = nonCalculatedMovement.Substring(2, 2);
                    var riskOfCapture = opponentPossibleMovements.Contains(targetPosition);
                    var movementValue = (riskOfCapture) ? MovementValue.AtRiskOfBeingCaptured : MovementValue.Exposed;

                    possibleMovements.Add(new KeyValuePair<MovementValue, string>(movementValue, nonCalculatedMovement));
                }
            }
            return possibleMovements;
        }

        private static List<string> GetOpponentNextMoves(IEnumerable<Piece> opponentPlayerPieces)
        {
            var opponentPossibleMovements = new List<string>();

            foreach (var playerPiece in opponentPlayerPieces)
            {
                foreach (var movement in playerPiece.PossibleMovements)
                    opponentPossibleMovements.Add(movement.Substring(2, 2));
            }

            return opponentPossibleMovements;
        }
    }
}