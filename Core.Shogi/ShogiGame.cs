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
            AskCurrentPlayerForNextMove();
        }

        void AskCurrentPlayerForNextMove()
        {
            var nextMove = _blackPlayer?.AskForNextMove();
            Move(nextMove);
        }

        private void Render()
        {
            _boardRender?.Refresh(_board.State);
        }

        public BoardResult Move(string moveDescription)
        {
            return BoardResult.ValidOperation;
//            return _board.Move(CurrentTurn, moveDescription.Substring(0, 2), moveDescription.Substring(2, 2));
        }
    }
}