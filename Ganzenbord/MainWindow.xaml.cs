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
        private readonly Game _game;

        public MainWindow()
        {
            InitializeComponent();
            _game = new Game();
            FillBoardGrid();
        }

        public void FillBoardGrid()
        {
            foreach (var field in _game.boardList)
            {
                field.Label1.Content = field.Number;
                field.Label2.Content = field.Special;

                BordGrid.Children.Add(field.Grid);

                Grid.SetRow(field.Grid, field.X);
                Grid.SetColumn(field.Grid, field.Y);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _game.boardList.Where(x => x.Number == 8).FirstOrDefault().Label2.Content = "test";
            _game.boardList.Where(x => x.Number == 63).FirstOrDefault().Background.Source = new BitmapImage(new Uri("/Images/63.jpg", UriKind.Relative));
            _game.boardList.Where(x => x.Number == 62).FirstOrDefault().Background.Source = new BitmapImage(new Uri("/Images/rightunder.jpg", UriKind.Relative));
            _game.boardList.Where(x => x.Number == 62).FirstOrDefault().GamePiece.Source = new BitmapImage(new Uri("/Images/playerBlue.png", UriKind.Relative));

            /* old way ↓
            foreach (var item in _game.boardList)
            {
                if (item.Number == 8)
                {
                    item.Label2.Content = "test";
                }
            }
            */
        }
    }
}