using System.Windows.Controls;

namespace Ganzenbord
{
    public interface IField
    {
        Image Red { get; set; }
        Image Purple { get; set; }
        Image Green { get; set; }
        Image Blue { get; set; }
        Image Yellow { get; set; }
        Image Orange { get; set; }
        WrapPanel PawnWrap { get; set; }

        Image Background { get; set; }

        Label FieldNumber { get; set; }
        Image GamePiece { get; set; }
        Grid Grid { get; set; }
        int Number { get; set; }
        int X { get; set; }
        int Y { get; set; }

        public int ReturnMove(Player player);
    }
}