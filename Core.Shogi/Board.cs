using System.Text.RegularExpressions;
using Core.Shogi.Pieces;

namespace Core.Shogi
{
    public class Board
    {
        private readonly IBoardRender _boardRender;
        private readonly IBoardInput _boardInputBlackPlayer;
        readonly BoardState _boardState = new BoardState();
        public Player CurrentTurn = Player.Black;

        public Board()
        {
        }

        public Board(IBoardRender boardRender, IBoardInput boardInputBlackPlayer) : this()
        {
            _boardRender = boardRender;
            _boardInputBlackPlayer = boardInputBlackPlayer;
        }

        public Board(BoardState boardState, Player currentTurn)
        {
            _boardState = boardState;
            CurrentTurn = currentTurn;
        }

        private void ResetBoard()
        {
            CurrentTurn = Player.Black;
            _boardState.Reset();
        }

        //TODO: Refactor to align domain abstraction level
        public BoardResult Move(string moveDescription)
        {
            return Move(CurrentTurn, moveDescription.Substring(0, 2), moveDescription.Substring(2, 2));
        }

        public BoardResult Move(Player player, string fromPosition, string toPosition)
        {
            if (!Regex.IsMatch(toPosition, "^[1-9]{1}[a-i]{1}$", RegexOptions.Compiled | RegexOptions.CultureInvariant))
                return BoardResult.InvalidOperation;

            if (player != CurrentTurn)
                return BoardResult.NotPlayersTurn;

            var piece = _boardState.GetPiece(fromPosition);
            if (player != piece.OwnerPlayer)
                return BoardResult.NotPlayersPiece;

            var targetPiece = _boardState.GetPiece(toPosition);
            if (piece.IsMoveLegal(toPosition) && (targetPiece == null || targetPiece?.OwnerPlayer != player))
            {
                piece.Move(toPosition);

                _boardState.Remove(fromPosition);
                _boardState.Add(piece);

                //TODO: SRP
                Render();

                return BoardResult.ValidOperation;
            }

            return BoardResult.InvalidOperation;
        }

        public void AskPlayerForNextMove()
        {
            var nextMove = _boardInputBlackPlayer?.AskForNextMove();
            // Move(nextMove);
        }

        public void StartGame()
        {
            ResetBoard();
            Render();
            AskPlayerForNextMove();
        }

        private void Render()
        {
            _boardRender?.Refresh(_boardState);
        }
    }
}