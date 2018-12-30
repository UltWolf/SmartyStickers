using System;
using System.Collections.Generic;
using System.IO;
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
            if (!Directory.Exists("Data"))
            {
                FirstLaunch();
            }
            using (FileStream fs = new FileStream("Data\\MainData.data", FileMode.Open))
            {
                byte[] byteArray = new byte[fs.Length];
                fs.Read(byteArray, 0, byteArray.Length);
                Notes.Text = new String(Encoding.UTF8.GetChars(byteArray));

            }
        }
        private void FirstLaunch()
        {
            Directory.CreateDirectory("Data");
         
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

        private void Notes_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
 

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("Data\\MainData.data", FileMode.Create))
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(Notes.Text);
                fs.Write(byteArray, 0, byteArray.Length);
            }
            MessageBox.Show("File have been saved");
        }
    }
}
