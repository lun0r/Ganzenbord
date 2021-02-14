using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    public class Field : IField
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Number { get; set; }
        public Grid Grid { get; set; } = new Grid();
        public Label FieldNumber { get; set; } = new Label();

        public Image Background { get; set; } = new Image();
        public Image Red { get; set; } = new Image() { Name = "red" };
        public Image Purple { get; set; } = new Image() { Name = "purple" };
        public Image Green { get; set; } = new Image() { Name = "green" };
        public Image Blue { get; set; } = new Image() { Name = "blue" };
        public Image Yellow { get; set; } = new Image() { Name = "yellow" };
        public Image Orange { get; set; } = new Image() { Name = "orange" };
        public WrapPanel PawnWrap { get; set; }

        public Field(int number, int x, int y)
        {
            X = x;
            Y = y;
            Number = number;
            Grid.Children.Add(Background);
            Grid.Children.Add(FieldNumber);
            Grid.Children.Add(CreateDefault());
        }

        public virtual int ReturnMove(Player player)
        {
            return player.CurrentBoardPosition;
        }

        public override string ToString()
        {
            return "You arrived on a normal field, pass dice to next player.";
        }

        public WrapPanel CreateDefault()
        {
            PawnWrap = new WrapPanel();

            List<Image> PawnList = new List<Image> { Red, Green, Blue, Yellow, Orange, Purple };

            PawnWrap.Orientation = Orientation.Horizontal;
            PawnWrap.HorizontalAlignment = HorizontalAlignment.Center;
            PawnWrap.VerticalAlignment = VerticalAlignment.Center;

            foreach (var item in PawnList)
            {
                item.Source = Board.SetImage($"pawn{ item.Name}.png");
                item.Stretch = Stretch.None;
                item.Visibility = Visibility.Collapsed;
                PawnWrap.Children.Add(item);
            }

            return PawnWrap;
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