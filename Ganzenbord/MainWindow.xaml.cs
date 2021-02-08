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
        public MainWindow()
        {
            InitializeComponent();

            int x = 0;
            int y = 0;

            int counter = 0;

            Dictionary<int, StackPanel> field = new Dictionary<int, StackPanel>();

            //field.Add(1,S)
            //StackPanel[,] matrix = new StackPanel[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    StackPanel panel = new StackPanel();

                    Label label1 = new Label();
                    Label label2 = new Label();
                    label1.Content = $"test {i} {j}";
                    label2.Content = $"iets {i} {j}";

                    panel.Children.Add(label1);
                    panel.Children.Add(label2);

                    BordGrid.Children.Add(panel);
                    Grid.SetRow(panel, i);
                    Grid.SetColumn(panel, j);
                    counter++;

                    //Matrix[i, j] = counter;
                    //
                }
            }
        }
    }
}