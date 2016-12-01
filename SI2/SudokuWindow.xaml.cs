using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for SudokuWindow.xaml
    /// </summary>
    public partial class SudokuWindow : Window
    {
        private Sudoku sudoku;
        int[,] boardCopy;
        public SudokuWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Let's solve that
            int method; //BT or FC
            if (radioButton.IsChecked == true) method = 0; //BT
            else method = 1;
            int N = comboBoxN.SelectedIndex + 1;
            int heuristic = comboBoxHeuristic.SelectedIndex;
            boardCopy = (int[,])sudoku.GetBoard().Clone(); //creating copy
            if (method == 0) //BT
            {
                BTSudoku bt= new BTSudoku((Sudoku)sudoku.Clone(), heuristic);
                var watch = System.Diagnostics.Stopwatch.StartNew(); //counting time
                bt.Solve();
                watch.Stop();
                //displaying results
                labelTime.Content = watch.ElapsedMilliseconds;
                labelAssigns.Content = bt.GetAssigns();
                labelReturns.Content = bt.GetReturns();
                //displaying sudoku
                textBlock.Text = bt.GetSudoku().ToString();
            }
            else //FC
            {
                //TODO FC :(
            }
        }

        private void comboBoxN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //modyfing comboBoxM
            if (comboBoxM != null)
                comboBoxM.Items.Clear(); //cleaning results comboBox
            else comboBoxM = new ComboBox();
            //adding new labels to comboBoxM
            for (int j = 0; j< Math.Pow(comboBoxN.SelectedIndex + 2, 4) - 1; j++)
            {
                Label newLabel = new Label();
                newLabel.Content = j+1;
                comboBoxM.Items.Add(newLabel);
            }
            comboBoxM.SelectedIndex = 0;
        }

        private void comboBoxM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //loading new sudoku
            sudoku = new Sudoku(comboBoxN.SelectedIndex + 2);
            sudoku.LoadSudoku();
            sudoku.DeleteCells(comboBoxM.SelectedIndex + 1);
            //displaying sudoku
            textBlock.Text = sudoku.ToString();

        }

        private void comboBoxHeuristic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_Restore_Click(sender, e);
        }

        private void button_Restore_Click(object sender, RoutedEventArgs e)
        {
            if (boardCopy != null)
            {
                sudoku = new Sudoku(comboBoxN.SelectedIndex + 2, boardCopy); //getting sudoku from a copy
                textBlock.Text = sudoku.ToString();
                //deleting displayed results
                labelTime.Content = "";
                labelAssigns.Content = "";
                labelReturns.Content = "";
            }
        }
    }
}
