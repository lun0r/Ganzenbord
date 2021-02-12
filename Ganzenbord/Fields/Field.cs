using System;
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
        public Grid Grid { get; set; }
        public Label FieldNumber { get; set; }

        public Image Background { get; set; }
        public Image GamePiece { get; set; }
        public Image Red { get; set; }
        public Image Purple { get; set; }
        public Image Green { get; set; }
        public Image Blue { get; set; }
        public Image Yellow { get; set; }
        public Image Orange { get; set; }
        public WrapPanel PawnWrap { get; set; }

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
            Grid.Children.Add(CreatePawns());
        }

        public virtual int ReturnMove(Player player)
        {
            return player.CurrentBoardPosition;
        }

        public override string ToString()
        {
            return "You arrived on a normal field, pass dice to next player.";
        }

        public WrapPanel CreatePawns()
        {
            PawnWrap = new WrapPanel();
            PawnWrap.Orientation = Orientation.Horizontal;
            PawnWrap.HorizontalAlignment = HorizontalAlignment.Center;
            PawnWrap.VerticalAlignment = VerticalAlignment.Center;
            Red = new Image();
            Green = new Image();
            Blue = new Image();
            Purple = new Image();
            Orange = new Image();
            Yellow = new Image();

            
            Red.Source = new BitmapImage(new Uri($"/Images/pawnred.png", UriKind.Relative));
            Red.Stretch = Stretch.None;
            Green.Source = new BitmapImage(new Uri($"/Images/pawngreen.png", UriKind.Relative));
            Green.Stretch = Stretch.None;
            Blue.Source = new BitmapImage(new Uri($"/Images/pawnblue.png", UriKind.Relative));
            Blue.Stretch = Stretch.None;
            Purple.Source = new BitmapImage(new Uri($"/Images/pawnpurple.png", UriKind.Relative));
            Purple.Stretch = Stretch.None;
            Orange.Source = new BitmapImage(new Uri($"/Images/pawnorange.png", UriKind.Relative));
            Orange.Stretch = Stretch.None;
            Yellow.Source = new BitmapImage(new Uri($"/Images/pawnyellow.png", UriKind.Relative));
            Yellow.Stretch = Stretch.None;

            Red.Visibility = Visibility.Collapsed;
            Green.Visibility = Visibility.Collapsed;
            Blue.Visibility = Visibility.Collapsed;
            Purple.Visibility = Visibility.Collapsed;
            Orange.Visibility = Visibility.Collapsed;
            Yellow.Visibility = Visibility.Collapsed;
            PawnWrap.Children.Add(Red);
            PawnWrap.Children.Add(Green);
            PawnWrap.Children.Add(Blue);
            PawnWrap.Children.Add(Orange);
            PawnWrap.Children.Add(Purple);
            PawnWrap.Children.Add(Yellow);
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