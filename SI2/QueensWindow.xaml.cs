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
using System.Windows.Shapes;

namespace SI2
{
    /// <summary>
    /// Interaction logic for QueensWindow.xaml
    /// </summary>
    public partial class QueensWindow : Window
    {
        private List<int[,]> solvedBoards;
        public QueensWindow()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //starting Simulation
            int method; //BT or FC
            if (radioButton.IsChecked == true) method = 0; //BT
            else method = 1;
            int N = comboBox.SelectedIndex + 1;
            if (method == 0) //BT
            {
                BTQueens bt = new BTQueens(N);
                var watch = System.Diagnostics.Stopwatch.StartNew(); //counting time
                bt.InsertQueen(0);
                watch.Stop();
                labelTime.Content = watch.ElapsedMilliseconds;
                labelHetmans.Content = bt.GetAssigns();
                labelResults.Content = bt.GetResults();
                labelReturns.Content = bt.GetReturns();
                solvedBoards = bt.GetSolvedBoards();
            }
            else //FC
            {
                FCQueens fc = new FCQueens(N);
                var watch = System.Diagnostics.Stopwatch.StartNew();  //counting time
                List<int> startList = new List<int>();
                for (int i = 0; i < N; i++)
                {
                    startList.Add(i);
                }
                fc.InsertQueen(0, startList);
                watch.Stop();
                labelTime.Content = watch.ElapsedMilliseconds;
                labelHetmans.Content = fc.GetAssigns();
                labelResults.Content = fc.GetResults();
                labelReturns.Content = fc.GetReturns();
                solvedBoards = fc.GetSolvedBoards();
            }

            
            comboBoxResults.Items.Clear(); //cleaning results comboBox

            int j = 0;
            foreach (int[,] board in solvedBoards)
            {
                Label newLabel = new Label();
                newLabel.Content = ++j;
                comboBoxResults.Items.Add(newLabel);
            }
            comboBoxResults.SelectedIndex = 0;

        }

        private void comboBoxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(solvedBoards.Count() > 0 && comboBoxResults.SelectedIndex >= 0)
            {
                int[,] board;
                int selectedIndex = comboBoxResults.SelectedIndex;
                board = solvedBoards[selectedIndex];
                int N = (int)Math.Sqrt(board.Length);
                string text = "";
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (board[i, j] == 1)
                            text += "X\t";
                        else text += "_\t";
                    }
                    text += "\n";
                }
                textBlock.Text = text;
            }
            
        }
    }
}
