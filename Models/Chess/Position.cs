using Chess20.Common;

namespace Chess20.Models.Chess.Pieces
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position()
        {
            X = Y = -1;
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        private bool IsInside()
        {
            return X is >= 0 and < CONSTANTS.MAX_X &&
                   Y is >= 0 and < CONSTANTS.MAX_Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y;
        }
    }
}