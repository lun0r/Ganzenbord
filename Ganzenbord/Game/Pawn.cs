namespace Ganzenbord
{
    public class Pawn
    {
        public string Name { get; set; }
        public PawnColor PawnColor { get; set; }

        public Pawn(string name, PawnColor color)
        {
            Name = name;
            PawnColor = color;
        }
    }
}