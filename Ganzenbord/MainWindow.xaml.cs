using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ganzenbord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;

        public MainWindow()
        {
            InitializeComponent();
            _game = new Game();
            CreateBoardFrontEnd();
        }

        public void CreateBoardFrontEnd()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    StackPanel panel = new StackPanel();

                    Label label1 = new Label();
                    Label label2 = new Label();

                    label1.Content = _game.board[i, j].ListIndex;
                    label2.Content = _game.board[i, j].Number;
                    label2.FontSize = 15;
                    label2.Foreground = new SolidColorBrush(Colors.Red);

                    panel.Children.Add(label1);
                    panel.Children.Add(label2);

                    BordGrid.Children.Add(panel);

                    Grid.SetRow(panel, i);
                    Grid.SetColumn(panel, j);
                }
            }
        }

        private void UpdateGrid(Field field)
        {
            StackPanel panel = new StackPanel();
            Label label1 = new Label();

            label1.Content = $"{field.ListIndex}...";

            panel.Children.Add(label1);

            BordGrid.Children.RemoveAt(field.ListIndex);
            BordGrid.Children.Insert(field.ListIndex, panel);

            Grid.SetRow(panel, field.X);
            Grid.SetColumn(panel, field.Y);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //dit is een test

            int x = Convert.ToInt32(textboxje.Text);
            int y = Convert.ToInt32(textboxje1.Text);

            textboxje.Text = "";
            textboxje1.Text = "";

            Field field = new Field();
            field = _game.board[x, y];

            UpdateGrid(field);
        }
    }
}