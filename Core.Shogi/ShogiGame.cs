using System.Text.RegularExpressions;

namespace Core.Shogi
{
    public class ShogiGame
    {
        private readonly IBoardRender _boardRender;
        private readonly IBoardPlayer _blackPlayer;
        private readonly IBoardPlayer _whitePlayer;
        private readonly Board _board;

        public ShogiGame(IBoardRender boardRender, IBoardPlayer blackPlayer, IBoardPlayer whitePlayer, Board board)
        {
            _boardRender = boardRender;
            _blackPlayer = blackPlayer;
            _whitePlayer = whitePlayer;
            _board = board;
        }

        public void Start()
        {
            _board.ResetBoard();
            Render();
            AskPlayerForNextMove(_blackPlayer, _whitePlayer);
        }

        void AskPlayerForNextMove(IBoardPlayer currentPlayer, IBoardPlayer nextPlayer)
        {
            if (currentPlayer != null && nextPlayer != null)
            {
                var nextMove = currentPlayer.AskForNextMove();
                var result = Move(currentPlayer.Player, nextMove);
                Render();

                if (result != BoardResult.ValidOperation)
                {
                    _boardRender.InvalidOperation(result);
                    AskPlayerForNextMove(currentPlayer, nextPlayer);
                }
                else
                    AskPlayerForNextMove(nextPlayer, currentPlayer);
            }
        }

        private void Render()
        {
            _boardRender?.Refresh(_board.State);
        }

        private BoardResult Move(Player player, string moveDescription)
        {
            if (!Regex.IsMatch(moveDescription, "^[1-9]{1}[a-i]{1}[1-9]{1}[a-i]{1}$", RegexOptions.Compiled | RegexOptions.CultureInvariant))
                return BoardResult.InvalidOperation;

            return _board.Move(player, moveDescription.Substring(0, 2), moveDescription.Substring(2, 2));
        }
    }
}