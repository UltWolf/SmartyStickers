using SmartyStickers.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        private string PathToStickerManager = "Data\\InfoStickers.data";
        private Sticker sticker = new Sticker();
        BinaryFormatter bf = new BinaryFormatter();
        public MainWindow(uint IdSticker)
        {
            InitializeComponent();
            this.sticker =  new Sticker(IdSticker); 
        }
        private void WriteDataToSticker()
        { 
            if (File.Exists("Data//Stickers//" + sticker.IdSticker))
            {
                
                using (FileStream fs = new FileStream("Data//Stickers//" + sticker.IdSticker, FileMode.Open))
                {
                    bf.Serialize(fs, sticker);
                }
            }
            
        }
        public MainWindow( )
        {
            InitializeComponent(); 

        }
        private uint GetLastNumberArray()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(PathToStickerManager, FileMode.Open))
            {
                var array =  (uint[])bf.Deserialize(fs);
                return (uint)array[array.Length - 1];
            }
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

         
 

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            WriteDataToSticker();
            MessageBox.Show("File have been saved");
        }

        private void AddSticker_Click(object sender, RoutedEventArgs e)
        {
            var windows = new MainWindow(GetLastNumberArray());
            windows.Show();
        }

        private void CloseSticker_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
