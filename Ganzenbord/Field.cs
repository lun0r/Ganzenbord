using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Ganzenbord
{
    public class Field
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Number { get; set; }
        public string Special { get; set; }
        public Grid Grid { get; set; }
        public Label Label1 { get; set; }
        public Label Label2 { get; set; }

        public Image Background { get; set; }
        public Image GamePiece { get; set; }
        public bool HasGoose { get; set; }

        public Field(int number, int x, int y)
        {
            X = x;
            Y = y;
            Number = number;
            Grid = new Grid();
            Label1 = new Label();
            Label2 = new Label();
            Background = new Image();
            GamePiece = new Image();
            Grid.Children.Add(Background);
            Grid.Children.Add(GamePiece);
            Grid.Children.Add(Label1);
            Grid.Children.Add(Label2);
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
 *
 *
 *
 */