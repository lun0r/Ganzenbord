using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Ganzenbord
{
    internal class Field
    {
        public int ListIndex { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Number { get; set; }
        public string Special { get; set; }
        public Grid _grid { get; set; }
        public Label _label1 { get; set; }
        public Label _label2 { get; set; }

        public Field()
        {
            _grid = new Grid();
            _label1 = new Label();
            _label2 = new Label();
            _grid.Children.Add(_label1);
            _grid.Children.Add(_label2);
        }
    }
}