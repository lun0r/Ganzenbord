using System.Windows.Controls;

namespace Ganzenbord
{
    public class Field : IField
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Number { get; set; }
        public Grid Grid { get; set; }
        public Label FieldNumber { get; set; }

        public Image Background { get; set; }
        public Image GamePiece { get; set; }

        public Field(int number, int x, int y)
        {
            X = x;
            Y = y;
            Number = number;
            Grid = new Grid();
            FieldNumber = new Label();

            Background = new Image();
            GamePiece = new Image();

            Grid.Children.Add(Background);

            Grid.Children.Add(GamePiece);

            Grid.Children.Add(FieldNumber);
        }

        public virtual int[] ReturnMove(Player player)
        {
            int[] output = new int[] { 0, 0 };
            return output;
        }

        public virtual void UpdateBoardPosition(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}

/* TODO: Game logica methoden voor: while run / dice methodes(sound effects) /
 * field methoden: update gamepiece, (maybe) scramble board?,
 * >? aanmaken nieuwe player? (hoeveel spelers, naam, avatar ingeven, form voor de mainform? of aan de zijkant?)
 * layout.. rechterluik
 * layout.. map pieces instellen
 * layout.. design map pieces
 * Pagina -> spelregels uitleg
 *
 * SpecialField: Field (inheritance) + opbouwen board vanuit Backend.
 * methode execute fixen -> voor elke optie inheriten van executeable methode "Square", functionaliteit zit dan in vakje zelf
 *
 * huidige plaatsen meegeven in venstertje
 */