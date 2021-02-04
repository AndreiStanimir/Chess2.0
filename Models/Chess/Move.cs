namespace Chess20.Models.Chess
{
    public class Move
    {
        public Tile Source;
        public Tile Target;

        public Move(Tile source, Tile target)
        {
            Source = source;
            Target = target;
        }
    }
}