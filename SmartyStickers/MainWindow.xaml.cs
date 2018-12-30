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

namespace SmartyStickers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            
            MainGrid.Background = Brushes.Red; 
        }

        private void YellowButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.Yellow;
        }

        private void GreenButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.Green;
        }

        private void BlueButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Background = Brushes.Blue;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
