namespace Core.Shogi.BitVersion
{
    public class BitboardShogiGame
    {
        private readonly IBoard _board;
        private readonly IBoardRender _render;
        private BitboardState _boardState;

        public BitboardShogiGame(IBoard board, IBoardRender render)
        {
            _board = board;
            _render = render;
            _boardState = new BitboardState();
        }

        public void Start()
        {
            _board.Reset();
            _render.Refresh(_boardState);
        }
    }
}