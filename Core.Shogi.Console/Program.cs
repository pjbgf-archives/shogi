using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Shogi.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board(new BoardConsoleRender(), new BoardConsoleInput());
            board.Render();
        }
    }
}