using System.Collections.Generic;
using System.Linq;
using Core.Shogi.Pieces;

namespace Core.Shogi
{
    public class MoveAdvisor
    {
        private readonly Dictionary<string, Piece> _boardState;
        private readonly Player _player;

        public MoveAdvisor(Dictionary<string, Piece> boardState, Player player)
        {
            _boardState = boardState;
            _player = player;
        }

        public string GetBestMove()
        {
            var playerPieces = _boardState.Values.Where(x => x.OwnerPlayer == _player);
            var possibleMovements = new List<KeyValuePair<MovementValue, string>>();
            
            foreach (var piece in playerPieces)
            {
                foreach(var possibleMovement in piece.PossibleMovements)
                    possibleMovements.Add(new KeyValuePair<MovementValue, string>(
                        possibleMovement.Key,
                        possibleMovement.Value));
            }

            var bestMovement = possibleMovements.OrderByDescending(x => x.Key).Select(x => x.Value).First();
            return bestMovement;
        }
    }
}