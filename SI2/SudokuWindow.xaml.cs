﻿using System;
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
    /// Interaction logic for SudokuWindow.xaml
    /// </summary>
    public partial class SudokuWindow : Window
    {
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
            if (method == 0) //BT
            {

            }
            else //FC
            {

            }
        }

        private void comboBoxN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxM.Items.Clear(); //cleaning results comboBox

            //int j = 0;
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
            //TODO change displayed sudoku
        }

        private void comboBoxHeuristic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
