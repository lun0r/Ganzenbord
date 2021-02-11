using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Ganzenbord
{
    internal class FieldGoose : Field
    {
        public Image SpecialImage { get; set; }

        public FieldGoose(int number, int x, int y, BitmapImage image)
            : base(number, x, y)
        {
            SpecialImage = new Image();
            SpecialImage.Source = image;
            Grid.Children.Add(SpecialImage);
        }

        public override SpecialFields ReturnMove()
        {
            return SpecialFields.Goose;
        }
    }
}