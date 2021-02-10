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
        public SpecialFields Special { get; set; }
        public Grid Grid { get; set; }
        public Label FieldNumber { get; set; }

        public Image Background { get; set; }
        public Image GamePiece { get; set; }
        public Image SpecialImage { get; set; }
        public bool HasGoose { get; set; }

        public Field(int number, int x, int y)
        {
            X = x;
            Y = y;
            Number = number;
            Grid = new Grid();
            FieldNumber = new Label();

            Background = new Image();
            GamePiece = new Image();
            SpecialImage = new Image();

            Grid.Children.Add(Background);
            Grid.Children.Add(SpecialImage);
            Grid.Children.Add(GamePiece);

            Grid.Children.Add(FieldNumber);
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