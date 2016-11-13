namespace Core.Shogi
{
    public class ShogiGame
    {
        private readonly IBoardRender _boardRender;
        private readonly IBoardInput _blackPlayer;
        private readonly IBoardInput _whitePlayer;
        private readonly Board _board;

        public ShogiGame(IBoardRender boardRender, IBoardInput blackPlayer, IBoardInput whitePlayer, Board board)
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

        void AskPlayerForNextMove(IBoardInput currentPlayer, IBoardInput nextPlayer)
        {
            if (currentPlayer != null && nextPlayer != null)
            {
                var nextMove = currentPlayer.AskForNextMove();
                var result = Move(currentPlayer.Player, nextMove);
                Render();

                if (result != BoardResult.ValidOperation)
                {
                    _boardRender.InvalidOperation(result);
                    //AskPlayerForNextMove(currentPlayer, nextPlayer);
                }

                if (result == BoardResult.ValidOperation)
                    AskPlayerForNextMove(nextPlayer, currentPlayer);
            }
        }

        private void Render()
        {
            _boardRender?.Refresh(_board.State);
        }

        private BoardResult Move(Player player, string moveDescription)
        {
            return _board.Move(player, moveDescription.Substring(0, 2), moveDescription.Substring(2, 2));
        }
    }
}