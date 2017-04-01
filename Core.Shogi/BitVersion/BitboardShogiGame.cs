namespace Core.Shogi.BitVersion
{
    public class BitboardShogiGame
    {
        private readonly IBoard _board;
        private readonly IBoardRender _render;
        private BoardState _boardState;

        public BitboardShogiGame(IBoard board, IBoardRender render)
        {
            _board = board;
            _render = render;
        }

        public void Start()
        {
            _board.Reset();
            _render.Refresh(_boardState);
        }
    }
}