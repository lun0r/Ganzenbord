using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
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
            Grid.Children.Add(AddDropShadow(FieldNumber));
            Grid.Children.Add(CreateDefault());
        }

        public virtual int ReturnMove(Player player)
        {
            return player.CurrentBoardPosition;
        }

        public override string ToString()
        {
            return "You may roll the dice to start your turn.";
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

        private Label AddDropShadow(Label label)
        {
            DropShadowEffect myDropShadowEffect = new DropShadowEffect();
            Color myShadowColor = new Color
            {
                ScA = 100,
                ScB = 0,
                ScG = 0,
                ScR = 0
            };
            myDropShadowEffect.Color = myShadowColor;
            myDropShadowEffect.Direction = 320;
            myDropShadowEffect.ShadowDepth = 3;
            myDropShadowEffect.BlurRadius = 3;
            myDropShadowEffect.Opacity = 1;
            label.Effect = myDropShadowEffect;

            return label;
        }
    }
}