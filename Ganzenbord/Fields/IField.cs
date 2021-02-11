using System.Windows.Controls;

namespace Ganzenbord
{
    public interface IField
    {
        Image Background { get; set; }
        Label FieldNumber { get; set; }
        Image GamePiece { get; set; }
        Grid Grid { get; set; }
        int Number { get; set; }
        int X { get; set; }
        int Y { get; set; }

        public int ReturnMove(Player player);

        public void UpdateBoardPosition(Player player);
        
    }

}